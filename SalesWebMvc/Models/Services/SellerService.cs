using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller seller)
        {
            _context.Add(seller);
            _context.SaveChanges();
        }

        public Seller FindById(int sellerId)
        {
            return _context.Seller.Include(x => x.Department)
                                       .FirstOrDefault(x => x.Id == sellerId);
        }

        public void Remove(int sellerId)
        {
            var sellerExclude = FindById(sellerId);
            _context.Seller.Remove(sellerExclude);
            _context.SaveChanges();
        }


    }
}
