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
                foreach(var record in db.RecordsMain)
                {
                    db.RecordsMain.Remove(record);
                }

                db.SaveChanges();

                Console.WriteLine("Main content after cleaning");
                WriteRecords(db.RecordsMain.ToArray());

                var record1 = new TRecordMain { id = 1, value = 111 };
                db.RecordsMain.Add(record1);
                var record2 = new TRecordMain { id = 2, value = 444 };
                db.RecordsMain.Add(record2);
                var record3 = new TRecordMain { id = 3, value = 777 };
                db.RecordsMain.Add(record3);

                db.SaveChanges();

                Console.WriteLine("Main content after add records");
                WriteRecords(db.RecordsMain.ToArray());

                Console.WriteLine("Repl 1 content after add records");
                WriteRecords(db.RecordsRepl1.ToArray());

                Console.WriteLine("Repl 2 content after add records");
                WriteRecords(db.RecordsRepl2.ToArray());

                Console.WriteLine("Repl 3 content after add records");
                WriteRecords(db.RecordsRepl3.ToArray());
            }

            Console.WriteLine("\n----------\nEnd!");
        }

        static void WriteRecords(IEnumerable<IRecord> records)
        {
            foreach (var record in records)
            {
                Console.WriteLine($"{record.id}) {record.value}");
            }
        }
    }
}
