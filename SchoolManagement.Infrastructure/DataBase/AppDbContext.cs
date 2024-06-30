using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.DataBase
{
    public class AppDbContext:DbContext
    {
        public DbSet<SchoolYear> SchoolYears { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<UserModule> UsersModules { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        private readonly ClientApp clientApp;
        
        public AppDbContext(DbContextOptions<AppDbContext> option, ClientApp clientApp) : base(option) {
            this.clientApp = clientApp;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (string.IsNullOrWhiteSpace(clientApp.ConnectionString))
            {
                throw new ArgumentNullException("mysql connectionString must not be null");
            }
            optionsBuilder.UseMySQL(clientApp.ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModule>(
                    eb =>
                    {
                        eb.HasKey("UserId", "ModuleId");
                    });
            modelBuilder.Entity<User>()
                .HasMany(u => u.Modules)
                .WithMany(u => u.Users)
                .UsingEntity<UserModule>();
        }
    }

}
