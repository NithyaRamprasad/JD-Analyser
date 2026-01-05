namespace JDAnalyser.Domain.Models.User
{
    public class UserModel
    {
        public int UserId { get; set; }

        public string EmailId { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public DateTime LastAccessed { get; set; }

        public int Role { get; set; }

        public string RoleName { get; set; } = null!;
    }
}
