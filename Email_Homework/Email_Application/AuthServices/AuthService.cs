using Email_Domen.Entity.AuthModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;




namespace Email_Application.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> GenerateToken(User user)
        {
            // Foydalanuvchi mavjudligi tekshiriladi
            if (user == null)
                return "User Not Found";

            // Foydalanuvchi autentifikatsiya amaliyoti muvaffaqiyatli bajarilganligi tekshiriladi
            if (UserExits(user))
            {
                // Foydalanuvchi uchun JWT ma'lumotlar to'plami yaratiladi
                List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Role , user.Role), // Foydalanuvchi huquqi
            new Claim("UserName", user.UserName), // Foydalanuvchi nomi
            new Claim("UserID", user.Id.ToString()), // Foydalanuvchi identifikatori
            new Claim("CreateDate", DateTime.UtcNow.ToString())  // Foydalanuvchi yaratilgan vaqti
        };

                // JWT yaratish uchun ma'lumotlar to'plami bilan yana bir marta funksiya chaqiriladi
                return await GenerateToken(claims);
            }
            else
            {
                // Foydalanuvchi autentifikatsiyadan o'tkazilganligi xabari
                return "User Unauthorized 401";
            }
        }



        public async Task<string> GenerateToken(IEnumerable<Claim> additionalClaims)
        {
            // Xavfsizlik kaliti (key) yaratiladi
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Token muddati (expiry date) olinadi
            var expiryMinutes = Convert.ToInt32(_configuration["JWT:ExpireDate"] ?? "10");

            // Tokenning bazaviy ansambl ma'lumotlari yaratiladi
            var baseClaims = new List<Claim>
    {
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // Tokenning ID si
        new Claim(JwtRegisteredClaimNames.Iat, EpochTime.GetIntDate(DateTime.UtcNow).ToString(CultureInfo.InvariantCulture), ClaimValueTypes.Integer64) // Tokenning yaratilgan vaqti
    };

            // Qo'shimcha ansambl ma'lumotlari tokenning bazaviy ansambliga qo'shiladi
            if (additionalClaims?.Any() == true)
                baseClaims.AddRange(additionalClaims);

            // JWT token yaratiladi
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"], // Token ishlab chiqaruvchisi
                audience: _configuration["JWT:ValidAudience"], // Token qabul qiluvchisi
                claims: baseClaims, // Ansambl ma'lumotlari
                expires: DateTime.UtcNow.AddMinutes(expiryMinutes), // Tokenning muddati
                signingCredentials: credentials // Xavfsizlik kaliti
            );

            // JWT token stringga o'zgartiriladi va qaytariladi
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        private bool UserExits(User model)
        {
            var login = "admin";
            var password = "123";

            if (model.Login == login && model.Password == password)
                return true;
            return false;
        }
    }
}
 