namespace jwtapp.back.Core.Domain
{
    public class AppUser
    {
        public AppUser()
        {
            this.AppRole = new AppRole();
        }
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }

        public int AppRoleId { get; set; }
        public AppRole AppRole { get; set; } 
    }
}