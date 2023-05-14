using Microsoft.EntityFrameworkCore;
using MVVM_Lb4.Domain.Models;
using MVVM_Lb4.EF.DTOs;

namespace MVVM_Lb4.EF;

public class ApplicationDbContext : DbContext
{
    public DbSet<Group> Groups { get; set; }
    public DbSet<Student> Students { get; set; }
    

    public ApplicationDbContext(DbContextOptions options) : base(options) {}
}