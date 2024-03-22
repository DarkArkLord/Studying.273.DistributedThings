using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartitionTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            using (var db = new ApplicationContext())
            {
                Console.WriteLine("Db content after creating");
                WriteRecords(db.RecordsMain.ToArray());

                var record1 = new TRecordMain { id = 1, value = 111 };
                db.RecordsMain.Add(record1);
                var record2 = new TRecordMain { id = 1, value = 444 };
                db.RecordsMain.Add(record2);
                var record3 = new TRecordMain { id = 1, value = 777 };
                db.RecordsMain.Add(record3);

                db.SaveChanges();

                Console.WriteLine("Db content after add records");
                WriteRecords(db.RecordsMain.ToArray());
            }

            Console.WriteLine("\n----------\nEnd!");
        }

        static void WriteRecords(IEnumerable<TRecordMain> records)
        {
            foreach (var record in records)
            {
                Console.WriteLine($"{record.id}) {record.value}");
            }
        }
    }
}
