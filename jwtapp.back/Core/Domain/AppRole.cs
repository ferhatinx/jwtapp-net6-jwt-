namespace jwtapp.back.Core.Domain
{
    public class AppRole
    {
        public AppRole()
        {
            this.AppUsers =new List<AppUser>();
        }
        public int Id { get; set; }
        public string? Definition { get; set; }
        public ICollection<AppUser> AppUsers { get; set; }
    }
}