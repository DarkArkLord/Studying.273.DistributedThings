using Microsoft.EntityFrameworkCore;

namespace ReplicationTest
{
    public class ApplicationContext : DbContext
    {
        public DbSet<TRecord> Records { get; set; }

        private DbInstance instance;

        public ApplicationContext(DbInstance instance, bool delete, bool create)
        {
            bool? wasDeleted = null;
            bool? wasCreated = null;

            if (delete)
            {
                wasDeleted = Database.EnsureDeleted();
            }

            if (create)
            {
                wasCreated = Database.EnsureCreated();
            }

            this.instance = instance;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(instance.GetConnectionString());
        }
    }

    public class TRecord
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }

    public enum DbInstance
    {
        Master = 0,
        Slave = 1,
    }

    public static class DbInstanceExt
    {
        public static string GetConnectionString(this DbInstance instance)
        {
            switch (instance)
            {
                case DbInstance.Master:
                    return "Host=localhost; Port=6601; Database=db; Username=postgres; Password=pospas";
                case DbInstance.Slave:
                    return "Host=localhost; Port=6602; Database=db; Username=postgres; Password=pospas";
            }
            return null;
        }
    }
}
