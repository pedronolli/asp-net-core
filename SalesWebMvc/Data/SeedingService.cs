using SalesWebMvc.Models;
using SalesWebMvc.Models.Entities;
using SalesWebMvc.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
            {
                return; //Database has been seeded
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Tools");
            Department d3 = new Department(3, "Games");
            Department d4 = new Department(4, "Books");

            Seller s1 = new Seller(1, "Peter Jackson", "peter@core.com", 2.000, new DateTime(1990, 4, 21), d1);
            Seller s2 = new Seller(2, "Bob Lazar", "blazar@core.com", 10.000, new DateTime(1976, 7, 15), d2);
            Seller s3 = new Seller(3, "Arnold McCoin", "coinmc@core.com", 1.000, new DateTime(1998, 7, 9), d3);
            Seller s4 = new Seller(4, "Frodo Skywalker", "sw_loveto@core.com", 8.000, new DateTime(1995, 10, 2), d4);
            Seller s5 = new Seller(5, "Mr Blue", "dogs@core.com", 12.000, new DateTime(1973, 7, 3), d1);
            Seller s6 = new Seller(6, "Machete Libre", "matamata@core.com", 3.000, new DateTime(1983, 10, 8), d1);
            Seller s7 = new Seller(7, "Donuts Tirump", "icangoputin@core.com",100.000, new DateTime(1995, 10, 2), d1);

            SalesRecord sr1 = new SalesRecord(1, new DateTime(2015, 9, 8), 500, SaleStatus.BILLED, s1);
            SalesRecord sr2 = new SalesRecord(2, new DateTime(2015, 11, 7), 560, SaleStatus.BILLED, s2);
            SalesRecord sr3 = new SalesRecord(3, new DateTime(2016, 1, 2), 1.999, SaleStatus.PENDING, s1);
            SalesRecord sr4 = new SalesRecord(4, new DateTime(2017, 5, 4), 5.050, SaleStatus.BILLED, s3);
            SalesRecord sr5 = new SalesRecord(5, new DateTime(2017, 3, 12), 500, SaleStatus.PENDING, s4);
            SalesRecord sr6 = new SalesRecord(6, new DateTime(2019, 3, 3), 500, SaleStatus.CANCELED, s2);
            SalesRecord sr7 = new SalesRecord(7, new DateTime(2019, 5, 30), 500, SaleStatus.PENDING, s7);
            SalesRecord sr8 = new SalesRecord(8, new DateTime(2019, 7, 19), 500, SaleStatus.BILLED, s5);
            SalesRecord sr9 = new SalesRecord(9, new DateTime(2019, 1, 11), 500, SaleStatus.PENDING, s6);
            SalesRecord sr10 = new SalesRecord(10, new DateTime(2018, 1, 22), 500, SaleStatus.PENDING, s3);
            SalesRecord sr11 = new SalesRecord(11, new DateTime(2018, 6, 28), 500, SaleStatus.CANCELED, s3);
            SalesRecord sr12 = new SalesRecord(12, new DateTime(2014, 2, 1), 500, SaleStatus.PENDING, s4);
            SalesRecord sr13 = new SalesRecord(13, new DateTime(2014, 3, 8), 500, SaleStatus.BILLED, s1);

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4);
            _context.SalesRecord.AddRange(sr1, sr2, sr3, sr4, sr5, sr6, sr7, sr8, sr9, sr10, sr11, sr12, sr13);
            _context.SaveChanges();

        }
    }
}
