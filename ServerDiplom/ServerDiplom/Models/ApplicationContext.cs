using Microsoft.EntityFrameworkCore;

namespace ServerDiplom.Models
{
    public class ApplicationContext:DbContext
    {
        public DbSet<TypeUser> TypeUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DocumentCategory> DocumentCategory { get; set; }

        public ApplicationContext(DbContextOptions options): base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region связи

            modelBuilder
                .Entity<User>()
                .HasOne(u => u.TypeUser)
                .WithMany(tu => tu.Users)
                .HasForeignKey(tu => tu.TypeUserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
                .Entity<TypeUser>()
                .HasMany(tu => tu.Users)
                .WithOne(u => u.TypeUser)
                .HasForeignKey(tu => tu.TypeUserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
                .Entity<Document>()
                .HasMany(d => d.Categories)
                .WithMany(c => c.Documents)
                .UsingEntity<DocumentCategory>(
                    j => j
                        .HasOne(d => d.Category)
                        .WithMany(dc => dc.DocumentCategories)
                        .HasForeignKey(d => d.CategoryId)
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasOne(c => c.Document)
                        .WithMany(dc => dc.DocumentCategories)
                        .HasForeignKey(c => c.DocumentId)
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasKey(k => new { k.DocumentId, k.CategoryId })
                );

            #endregion

            #region ограничения

            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasIndex(d => d.Name).IsUnique();
            });

            modelBuilder.Entity<Category>(entity => 
            {
                entity.HasIndex(c => c.Name).IsUnique();
            });

            modelBuilder.Entity<TypeUser>(entity =>
            {
                entity.HasIndex(tu => tu.Name).IsUnique();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(u => u.UserLogin).IsUnique();
            });

            #endregion
        }
    }
}
