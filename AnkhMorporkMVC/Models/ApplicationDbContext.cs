using System.Data.Entity;

namespace AnkhMorporkMVC.Models
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<UserModel> User { get; set; }
        public virtual DbSet<GameEntityModel> GameEntities { get; set; }
        public virtual DbSet<AssasinModel> Assasins { get; set; }
        public virtual DbSet<ThieveModel> Thieves { get; set; }
        public virtual DbSet<BeggarModel> Beggars { get; set; }
        public virtual DbSet<PubModel> Pubs { get; set; }
        public virtual DbSet<FoolModel> Fools { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}