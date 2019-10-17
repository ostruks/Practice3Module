using Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace MyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Worker> workers = new List<Worker>();
            List<Salary> salaries = new List<Salary>();

            string[] Workers = File.ReadAllLines("Workers.txt");
            string[] Salaries = File.ReadAllLines("Salary.txt");

            foreach (var str in Workers)
            {
                string[] data = str.Split(';');
                workers.Add(new Worker(int.Parse(data[0]), data[1], data[2], data[3], int.Parse(data[4])));
            }
            foreach (var str in Salaries)
            {
                string[] data = str.Split(';');
                salaries.Add(new Salary(int.Parse(data[0]), double.Parse(data[1]), double.Parse(data[2])));
            }

            foreach(var worker in workers.Where(wor => (DateTime.Now.Year - wor.Year) > 35))
            {
                Console.WriteLine(worker.FIO);
            }

            var salaryWorkers = workers.Join(salaries,
             p => p.ID,
             t => t.ID,
             (p, t) => new { ID = p.ID, FIO = p.FIO, Salary1 = t.Salary1, Salary2 = t.Salary2 });

            Console.WriteLine(salaryWorkers.Where(wor => wor.Salary2 == salaryWorkers.Max(sal => sal.Salary2)).First());
            foreach(var worker in salaryWorkers.Where(wor => wor.Salary1 + wor.Salary2 < salaryWorkers.Average(sal => sal.Salary1 + sal.Salary2)))
            {
                Console.WriteLine(worker);
            }

            XDocument doc = XDocument.Load("PurchaseOrder.xml");

            var items = doc.Element("PurchaseOrder").Element("Items").Elements("Item")
                .Where(d => (double)d.Element("USPrice") > 100)
                .OrderBy(d => d.Attribute("PartNumber").Value).Select(d => new
                {
                    PartNumber = d.Attribute("PartNumber").Value
                });

            foreach (var item in items)
            {
                Console.WriteLine($"PartNumber: {item.PartNumber}");
            }

            using (XmlWriter xw = XmlWriter.Create("Output.xml"))
            {
                doc = new XDocument(
                    new XElement("Items",
                        new XElement("Item",
                            new XAttribute("PartNumber", items.First().PartNumber)
                        )
                    )
                );
                doc.WriteTo(xw);
            }

            Console.ReadKey();
        }
    }
}
