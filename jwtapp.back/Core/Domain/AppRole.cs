namespace jwtapp.back.Core.Domain
{
    public class AppRole
    {
     
        public int Id { get; set; }
        public string? Definition { get; set; }
        public ICollection<AppUser>? AppUsers { get; set; }
    }
}