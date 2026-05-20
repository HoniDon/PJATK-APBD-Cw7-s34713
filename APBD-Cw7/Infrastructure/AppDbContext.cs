using APBD_Cw7.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_Cw7.Infrastructure;

public class AppDbContext(DbContextOptions opt) : DbContext(opt)
{
    public DbSet<PC> PCs { get; set; }
    public DbSet<Component> Components { get; set; }
    public DbSet<PCComponent> PCComponents { get; set; }
    public DbSet<ComponentType> ComponentTypes { get; set; }
    public DbSet<ComponentManufacturer> ComponentManufacturers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PC>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Weight).IsRequired();
            entity.Property(e => e.Warranty).IsRequired();
            entity.Property(e => e.CreatedAt).IsRequired();
            entity.Property(e => e.Stock).IsRequired();
            
        });

        modelBuilder.Entity<ComponentType>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Abbreviation).IsRequired().HasMaxLength(30);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(150);
        });

        modelBuilder.Entity<ComponentManufacturer>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Abbreviation).IsRequired().HasMaxLength(30);
            entity.Property(e => e.FullName).IsRequired().HasMaxLength(300);
            entity.Property(e => e.FoundationDate).HasColumnType("date").IsRequired();
        });

        modelBuilder.Entity<Component>(entity =>
        {
            entity.HasKey(e => e.Code);
            entity.Property(e => e.Code).HasMaxLength(10).HasColumnType("char(10)");
            entity.Property(e => e.Name).IsRequired().HasMaxLength(300);
            entity.Property(e => e.Description).IsRequired();
            
            entity.HasOne(c => c.ComponentType)
                .WithMany(m => m.Components)
                .HasForeignKey(c => c.ComponentTypeId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.ComponentManufacturer)
                .WithMany(t => t.Components)
                .HasForeignKey(c => c.ComponentManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<PCComponent>(entity =>
        {
            entity.HasKey(e => new { e.PCId, e.ComponentCode });
            entity.Property(e => e.ComponentCode).HasMaxLength(10).HasColumnType("char(10)");
            entity.Property(e => e.Amount).IsRequired();
            
            entity.HasOne(pc => pc.PC)
                .WithMany(p => p.PCComponents)
                .HasForeignKey(pc => pc.PCId)
                .OnDelete(DeleteBehavior.Cascade);
            
            entity.HasOne(pc => pc.Component)
                .WithMany(c => c.PCComponents)
                .HasForeignKey(pc => pc.ComponentCode)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}

/*
    public int PCId { get; set; }
   public string ComponentCode { get; set; } = null!;
   public int Amount { get; set; }
   
   public PC PC { get; set; } = null!;
   public Component Component { get; set; } = null!;
*/