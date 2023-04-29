using Microsoft.EntityFrameworkCore;
using MVVM_Lb4.Domain.Models;

namespace MVVM_Lb4.EF;

public class ApplicationDbContext : DbContext
{
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Group> Groups { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=lb4app.db");
    }
}