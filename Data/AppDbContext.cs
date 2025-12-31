using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TransactionEntity> Transactions { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.HasKey(u => u.Id);

                entity.Property(u => u.Email).IsRequired().HasMaxLength(128);

                entity.HasIndex(u => u.Email).IsUnique();

                entity.Property(u => u.Balance).HasColumnType("decimal(18,2)");

            });
            modelBuilder.Entity<TransactionEntity>(entity =>
            {
                entity.HasKey(t => t.Id);

                entity.Property(t => t.Amount).HasColumnType("decimal(18,2)").IsRequired();

                entity.HasOne(t => t.SenderUser).WithMany(u => u.SentTransactions).HasForeignKey(t => t.SenderID).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.ReceiverUser).WithMany(u => u.ReceivedTransactions).HasForeignKey(t => t.ReceiverID).OnDelete(DeleteBehavior.Restrict);

            });
            

        }
      
    }
}
