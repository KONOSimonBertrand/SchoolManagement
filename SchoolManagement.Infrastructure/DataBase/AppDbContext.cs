using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.DataBase
{
    public class AppDbContext : DbContext
    {
        public DbSet<SchoolYear> SchoolYears { get; set; }
        public DbSet<SchoolGroup> SchoolGroups { get; set; }
        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<SchoolRoom> ShoolRooms { get; set; }
        public DbSet<CashFlowType> CashFlowTypes { get; set; }
        public DbSet<PaymentMean> PaymentMeans { get; set; }
        public DbSet<SchoolingCost> SchoolingCosts { get; set; }
        public DbSet<SchoolingCostItem> SchoolingCostItems { get; set; }
        public DbSet<SubscriptionFee> SubscriptionFees { get; set; }
        public DbSet<SubjectGroup> SubjectGroups { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<EvaluationType> EvaluationTypes { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<UserModule> UsersModules { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        private readonly ClientApp clientApp;

        public AppDbContext(DbContextOptions<AppDbContext> option, ClientApp clientApp) : base(option)
        {
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
                    entity =>
                    {
                        entity.HasKey("UserId", "ModuleId");
                    });
            modelBuilder.Entity<User>()
                .HasMany(u => u.Modules)
                .WithMany(u => u.Users)
                .UsingEntity<UserModule>();
            modelBuilder.Entity<SchoolGroup>(
                entity =>
                {
                    entity.HasKey(e => e.Id);
                    entity.Property(e => e.Id).ValueGeneratedOnAdd();
                }
                );
            modelBuilder.Entity<SchoolClass>(
               entity =>
               {
                   entity.HasKey(e => e.Id);
                   entity.Property(e => e.Id).ValueGeneratedOnAdd();
                   entity.HasOne(d => d.Group).WithMany(p => p.Classes);
               }
               );
            modelBuilder.Entity<SchoolRoom>(
               entity =>
               {
                   entity.HasKey(e => e.Id);
                   entity.Property(e => e.Id).ValueGeneratedOnAdd();
                   entity.HasOne(d => d.SchoolClass).WithMany(p => p.Rooms);
               }
               );
            modelBuilder.Entity<SchoolingCost>(entity =>
            {
                entity.HasKey(e => new { e.Id });

                entity.HasOne(d => d.CashFlowType)
                    .WithMany(p => p.SchoolingCosts)
                    .HasForeignKey(d => d.CashFlowTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.SchoolClass)
                    .WithMany(p => p.SchoolingCosts)
                    .HasForeignKey(d => d.SchoolClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.SchoolYear)
                    .WithMany(p => p.SchoolingCosts)
                    .HasForeignKey(d => d.SchoolYearId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<SchoolingCostItem>(entity =>
            {
                entity.HasKey(e => new { e.Id });
                entity.HasOne(e => e.SchoolingCost)
                .WithMany(e => e.SchoolingCostItems)
                 .HasForeignKey(d => d.SchoolingCostId);
            });

            modelBuilder.Entity<SubscriptionFee>(entity =>
            {
                entity.HasKey(d => new { d.Id });
                entity.HasOne(e => e.CashFlowType).WithMany(e => e.SubscriptionFees).HasForeignKey(e => e.CashFlowTypeId);
                entity.HasOne(e => e.SchoolYear).WithMany(e => e.SubscriptionFees).HasForeignKey(e => e.SchoolYearId);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => new { e.Id });
            });

            modelBuilder.Entity<SubjectGroup>(entity => { 
                entity.HasKey(e => new { e.Id });
            });
            modelBuilder.Entity<EvaluationType>(entity => {
                entity.HasKey(e => new { e.Id });
            });

        }
    }

}
