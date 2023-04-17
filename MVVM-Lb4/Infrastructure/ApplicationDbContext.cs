using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityLb4.Model;

namespace MVVM_Lb4.Infrastructure
{
    class ApplicationDbContext : DbContext
    {
		public DbSet<Student> Students { get; set; } = null!;
		public DbSet<Group> Groups { get; set; } = null!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source=lb4app.db");
		}
	}
}
