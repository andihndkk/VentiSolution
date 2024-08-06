using Microsoft.EntityFrameworkCore;

public class DBkonteks : DbContext
{
    public DBkonteks(DbContextOptions<DBkonteks> options)
        : base(options)
    {
    }

    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<Kategori> Kategoris { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Konfigurasi primary key untuk entitas Inventory
        modelBuilder.Entity<Inventory>()
            .HasKey(i => i.id_inventory);


        // Konfigurasi primary key untuk entitas Kategori
        modelBuilder.Entity<Kategori>()
           .ToTable("kategori")
           .HasKey(k => k.id_kategori);



        // Konfigurasi pemetaan tabel untuk entitas Inventory
        modelBuilder.Entity<Inventory>()
            .ToTable("inventory")
            .HasOne(i => i.kategori)
            .WithMany()
            .HasForeignKey(i => i.id_kategori);


        base.OnModelCreating(modelBuilder);
    }
}
