using Microsoft.EntityFrameworkCore;
using EquipmentManagementSystem.Models;

namespace EquipmentManagementSystem.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Equipment> Equipments => Set<Equipment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Equipment>()
            .HasIndex(e => e.SerialNumber)
            .IsUnique();
    }
}