using Microsoft.EntityFrameworkCore;

namespace WebShouts.Entities
{
    public class ApplicationDbContent : DbContext
    {
        public ApplicationDbContent(DbContextOptions<ApplicationDbContent> options)
           : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<FollowUser> FollowUsers { get; set; }
        public DbSet<WebShout> WebShouts { get; set; }
    }
}
