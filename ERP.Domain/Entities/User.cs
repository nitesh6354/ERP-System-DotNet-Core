namespace ERP.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public string Role { get; set; } = "User";

        public bool IsActive { get; set; } = true;
    }
}

//Why in Domain?
/*
User is a core business concept
Domain must be framework-independent
*/
