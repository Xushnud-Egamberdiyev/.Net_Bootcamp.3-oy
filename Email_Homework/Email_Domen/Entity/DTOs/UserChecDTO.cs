namespace Email_Domen.Entity.DTOs
{
    public class UserChecDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ChecPassword { get; set; }
    }
}
