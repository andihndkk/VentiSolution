using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

public class DBkonteks : DbContext
{
    public DBkonteks(DbContextOptions<DBkonteks> options)
        : base(options)
    {
    }
    public DbSet<inventory> Inventories { get; set; }


    }

