using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TransactionEntity> Transactions { get; set; }
        public DbSet<DepositEntity> Deposits { get; set; }
        public DbSet<WithdrawEntity> Withdraws { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.HasKey(u => u.Id);

                entity.Property(u => u.IBAN).IsRequired().HasMaxLength(32);

                entity.Property(u => u.Email).IsRequired().HasMaxLength(128);

                entity.HasIndex(u => u.Email).IsUnique();

                entity.Property(u => u.Balance).HasColumnType("decimal(18,2)");

            });
            modelBuilder.Entity<TransactionEntity>(entity =>
            {
                entity.HasKey(t => t.Id);

                entity.Property(t => t.Amount).HasColumnType("decimal(18,2)").IsRequired();

                entity.HasOne(t => t.SenderUser).WithMany().HasForeignKey(t => t.SenderID).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.ReceiverUser).WithMany().HasForeignKey(t => t.ReceiverID).OnDelete(DeleteBehavior.Restrict);

            });
            modelBuilder.Entity<WithdrawEntity>(entity =>
            {
                entity.HasKey(w => w.Id);

                entity.Property(w => w.Amount).HasColumnType("decimal(18,2)").IsRequired();

                entity.HasOne(w => w.User).WithMany(u => u.Withdraws).HasForeignKey(w => w.UserId).OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<DepositEntity>(entity =>
            {
                entity.HasKey(d => d.Id);

                entity.Property(w => w.Amount).HasColumnType("decimal(18,2)").IsRequired();

                entity.HasOne(d => d.User).WithMany(u => u.Deposits).HasForeignKey(d => d.UserId).OnDelete(DeleteBehavior.Restrict);

            });

        }
      
    }
}
