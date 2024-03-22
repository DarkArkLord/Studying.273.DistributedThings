using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace PartitionTest
{
    public class ApplicationContext : DbContext
    {
        public DbSet<TRecordMain> RecordsMain { get; set; }
        public DbSet<TRecordRepl_1> RecordsRepl1 { get; set; }
        public DbSet<TRecordRepl_2> RecordsRepl2 { get; set; }
        public DbSet<TRecordRepl_3> RecordsRepl3 { get; set; }

        public ApplicationContext()
        {
            //
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost; Port=6601; Database=postgres; Username=postgres; Password=pospas");
        }
    }

    public interface IRecord
    {

        public int id { get; }
        public int value { get; }
    }

    [Table("partition_test_main")]
    public class TRecordMain : IRecord
    {
        public int id { get; set; }
        public int value { get; set; }
    }

    [Table("partition_test_1")]
    public class TRecordRepl_1 : IRecord
    {
        public int id { get; set; }
        public int value { get; set; }
    }

    [Table("partition_test_2")]
    public class TRecordRepl_2 : IRecord
    {
        public int id { get; set; }
        public int value { get; set; }
    }

    [Table("partition_test_3")]
    public class TRecordRepl_3 : IRecord
    {
        public int id { get; set; }
        public int value { get; set; }
    }
}
