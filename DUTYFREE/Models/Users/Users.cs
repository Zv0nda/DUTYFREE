namespace DUTYFREE.Models.Users
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public Role Role { get; set; }
    }

    public enum Role
    {
        User = 1,
        Admin = 2
    }
}
