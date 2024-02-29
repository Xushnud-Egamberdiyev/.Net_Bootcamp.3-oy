using Email_Application;
using Email_Infrustructur;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;


namespace Email_Homework
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddApplication();

            builder.Services.AddInfrustructure(builder.Configuration);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                // Swagger versiyasini va ma'lumotlarini sozlaymiz
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Lesson Auth", Version = "v1.0.0", Description = "Lesson Auth API" });

                // Xavfsizlik schema (Bearer) uchun OpenAPI ma'lumotlarini sozlaymiz
                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                // Xavfsizlik schema-ni qo'shish
                c.AddSecurityDefinition("Bearer", securitySchema);

                // Xavfsizlik talablarini qo'shish
                var securityRequirement = new OpenApiSecurityRequirement
    {
        { securitySchema, new[] { "Bearer" } }
    };
                c.AddSecurityRequirement(securityRequirement);
            });



            //builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //   .AddJwtBearer(
            //       options =>
            //       {
            //           options.TokenValidationParameters = GetTokenValidationParameters(builder.Configuration);

            //           options.Events = new JwtBearerEvents
            //           {
            //               OnAuthenticationFailed = (context) =>
            //               {
            //                   if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
            //                   {
            //                       context.Response.Headers.Add("IsTokenExpired", "true");
            //                   }
            //                   return Task.CompletedTask;
            //               }
            //           };
            //       });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer(
           options =>
           {
               // JWT tokenini tekshirish uchun parametrlarni olish
               options.TokenValidationParameters = GetTokenValidationParameters(builder.Configuration);

               // Autentifikatsiya jarayonida yuz beradigan hodisalarni sozlash
               options.Events = new JwtBearerEvents
               {
                   OnAuthenticationFailed = (context) =>
                   {
                       // Agar token muddati o'tgan bo'lsa
                       if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                       {
                           // "IsTokenExpired" sarlavhasi bilan javob qaytarish
                           context.Response.Headers.Add("IsTokenExpired", "true");
                       }
                       return Task.CompletedTask;
                   }
               };
           });


            //static TokenValidationParameters GetTokenValidationParameters(IConfiguration configuration)
            //{
            //    return new TokenValidationParameters()
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = configuration["JWT:ValidIssuer"],
            //        ValidAudience = configuration["JWT:ValidAudience"],
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])),
            //        ClockSkew = TimeSpan.Zero,
            //    };
            //}

            static TokenValidationParameters GetTokenValidationParameters(IConfiguration configuration)
            {
                return new TokenValidationParameters()
                {
                    // Token issuerini tekshirish
                    ValidateIssuer = true,
                    // Tokenni qabul qiluvchini tekshirish
                    ValidateAudience = true,
                    // Token muddatini tekshirish
                    ValidateLifetime = true,
                    // Token imzosi tekshirish
                    ValidateIssuerSigningKey = true,
                    // Tokenning yaroqligi (issuer)
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    // Tokenni qabul qiluvchi (audience)
                    ValidAudience = configuration["JWT:ValidAudience"],
                    // Token imzolash uchun xavfsizlik kaliti (key)
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])),
                    // Vaqt farqini belgilash (Zero, bu orqali vaqt farqi bo'lmaydi)
                    ClockSkew = TimeSpan.Zero,
                };
            }






            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
