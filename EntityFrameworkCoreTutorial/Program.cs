using System;
using System.Linq;
using EntityFrameworkCoreTutorial.Models;

namespace EntityFrameworkCoreTutorial {
    class Program {
        static void Main(string[] args) {

            var _context = new SalesDbContext();

            var custOrder = from o in _context.Orders
                            join c in _context.Customers
                            on o.CustomerId equals c.Id
                            select new {
                                o,
                                c.Name
                            };

            foreach (var oc in custOrder) {
                Console.WriteLine($"{oc.o.Description} | {oc.Name}");
            }

            var customers = _context.Customers
                                        .Where(c => c.City == "Cincinnati" && c.Sales >= 50000)
                                        .OrderByDescending(c => c.Name)
                                        .ToList();

            foreach (var c in customers) {
                Console.WriteLine($"{c.Name} | {c.City} | {c.Sales}");
            }
        }
    }
}
