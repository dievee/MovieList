using Microsoft.AspNet.Identity.EntityFramework;

namespace MovieList.Models
{
    public class UserInfo : IdentityUser
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}