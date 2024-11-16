using Microsoft.EntityFrameworkCore;
using RATA.Shared.Models;

namespace RATA.Shared.Services
{
    public class TenantDatabase : DbContext
    {
        public static string File { get; protected set; }
        public static bool Initialized { get; protected set; }


        public DbSet<Tenant> TenantSet { get; set; }
        public DbSet<TenantMaintenance> TenantMaintenanceSet { get; set; }

        public TenantDatabase()
        {
            File = Path.Combine("../", "UsedByMigratorOnly1.db3");
            Initialize();
        }

        public TenantDatabase(string databasePath)
        {
            File = databasePath;
            Initialize();
        }

        void Initialize()
        {
            if (!Initialized)
            {
                Initialized = true;

                SQLitePCL.Batteries_V2.Init();

                Database.Migrate();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite($"Filename={File}");
        }
        public void Reload()
        {
            Database.CloseConnection();
            Database.OpenConnection();
        }

    }
}
