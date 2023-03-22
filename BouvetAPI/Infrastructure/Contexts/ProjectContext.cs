using Microsoft.EntityFrameworkCore;
using BouvetAPI.Models;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Reflection.Emit;


namespace BouvetAPI.Infrastructure.Contexts
{
    public class ProjectContext : DbContext
    {

        protected readonly IConfiguration Configuration;

        public ProjectContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<Project> Projects { get; set; } = null!;
        public DbSet<Epic> Epics { get; set; } = null!;

        public DbSet<Worktask> Worktasks { get; set; } = null!; 
    }
}
