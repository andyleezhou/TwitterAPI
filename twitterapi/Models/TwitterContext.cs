using Microsoft.EntityFrameworkCore;
namespace twitterapi.Models
{
    public class TwitterContext : DbContext
    {
        public TwitterContext(DbContextOptions<TwitterContext> options)
            : base(options)
        {
        }
        public DbSet<Twitter> TwitterTweets { get; set; }
    }
}