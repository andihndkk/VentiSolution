using Microsoft.EntityFrameworkCore;

public class DBkonteks : DbContext
{
    public DBkonteks(DbContextOptions<DBkonteks> options)
        : base(options)
    {
    }

    public DbSet<Inventory> Inventories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Konfigurasi primary key untuk entitas Inventory
        modelBuilder.Entity<Inventory>()
            .HasKey(i => i.id_inventory);

        // Konfigurasi pemetaan tabel untuk entitas Inventory
        modelBuilder.Entity<Inventory>()
            .ToTable("inventory"); // Pastikan nama tabel sesuai dengan nama tabel di database

        base.OnModelCreating(modelBuilder);
    }
}
