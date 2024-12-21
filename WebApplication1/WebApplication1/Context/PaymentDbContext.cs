using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Context;

public sealed class PaymentDbContext : DbContext
{

    public PaymentDbContext()
    {
        Database.EnsureCreated();
    }
    public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    public DbSet<PaymentDetailsViewModel> PaymentDetails { get; set; }

    private void OnModelBuilding(ModelBuilder modelBuilder){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.HasDefaultSchema("public");
        modelBuilder.HasPostgresExtension("uuid-ossp");
        
        modelBuilder.Entity<PaymentDetailsViewModel>(entity =>
        {
            entity.Property(p => p.PaymentDetailsId).HasDefaultValueSql("uuid_generate_v4()");
        });
    }
}