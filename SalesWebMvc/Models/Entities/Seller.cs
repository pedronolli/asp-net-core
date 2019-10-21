using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models.Entities
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double BaseSalary { get; set; }
        public DateTime BirthDate { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> SalesRecords { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, double baseSalary, DateTime birthDate, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BaseSalary = baseSalary;
            BirthDate = birthDate;
            Department = department;
        }

        public void addSales(SalesRecord sale)
        {
            SalesRecords.Add(sale);
        }

        public void RemoveSales(SalesRecord sale)
        {
            SalesRecords.Remove(sale);
        }

        public double TotalSales(DateTime init, DateTime end)
        {
            return SalesRecords.Where(sale => sale.Date >= init && sale.Date <= end)
                    .Sum(sale => sale.Amount);
        }
    }
}
