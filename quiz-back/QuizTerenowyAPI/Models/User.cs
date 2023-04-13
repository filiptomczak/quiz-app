namespace QuizTerenowyAPI.Models
{
    public enum Role
    {
        User,
        Admin
    }
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int? Score { get;set; }
        public int? TimeTaken { get; set; } 
        public Role Role { get; set; }
    }
}
