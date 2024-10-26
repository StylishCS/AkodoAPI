using Microsoft.EntityFrameworkCore;

namespace AkodoAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Ad> Ads { get; set; }
        public DbSet<AdBedroom> AdBedrooms { get; set; }
        public DbSet<AdImage> AdImages { get; set; }
        public DbSet<AdReport> AdReports { get; set; }
        public DbSet<AdUserView> AdUserViews { get; set; }
        public DbSet<AdUserWishlist> AdUserWishlists { get; set; }
        public DbSet<AdBedroomUserOccupancy> AdBedroomUserOccupancies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserDocument> UserDocuments { get; set; }
        public DbSet<UserFeedback> UserFeedbacks { get; set; }
        public DbSet<UserTransaction> UserTransactions { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<AdminLog> AdminLogs { get; set; }
    }
}
