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
            optionsBuilder.UseNpgsql("Host=localhost; Port=6601; Database=db; Username=postgres; Password=pospas");
        }
    }

    [Table("partition_test_main")]
    public class TRecordMain
    {
        public int id { get; set; }
        public int value { get; set; }
    }

    [Table("partition_test_1")]
    public class TRecordRepl_1 : TRecordMain { }

    [Table("partition_test_2")]
    public class TRecordRepl_2 : TRecordMain { }

    [Table("partition_test_3")]
    public class TRecordRepl_3 : TRecordMain { }
}
