using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models.Entities;
using SalesWebMvc.Models.Exceptions;
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

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller seller)
        {
            _context.Add(seller);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int sellerId)
        {
            return await _context.Seller.Include(x => x.Department)
                                       .FirstOrDefaultAsync(x => x.Id == sellerId);
        }

        public async Task RemoveAsync(int sellerId)
        {
            var sellerExclude = await FindByIdAsync(sellerId);
            _context.Seller.Remove(sellerExclude);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Seller seller)
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == seller.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Seller not found.");
            }

            try
            {
                _context.Update(seller);
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException e)
            { 
                throw new DbConcurrencyException(e.Message);
            }
        }


    }
}
