using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Module7Dapper.Models;

namespace Module7Dapper.DataContext;

public class DataContext : DbContext
{
    public DataContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public DbSet<User> Users => Set<User>();

    public DbSet<Promotion> Promotions => Set<Promotion>();

    public DbSet<Good> Goods => Set<Good>();

    public DbSet<Category> Categories => Set<Category>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=mailings.sqlite;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Good>()
            .HasOne(g => g.GoodsPromotion)
            .WithMany(p => p.Goods)
            .HasForeignKey(g => g.PromotionId);
    }
}
