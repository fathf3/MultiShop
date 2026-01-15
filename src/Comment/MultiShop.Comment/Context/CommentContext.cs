using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Context
{
    public class CommentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
   "Server=localhost,1442;" +
   "Initial Catalog=MultishopCommentDb;" +
   "User Id=sa;" +
   "Password=123456Aa*;" +
   "Encrypt=True;" +
   "TrustServerCertificate=True;");
        }
        public DbSet<UserComment> UserComments { get; set; }
    }
}
