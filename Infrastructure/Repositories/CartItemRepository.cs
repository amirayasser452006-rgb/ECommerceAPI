using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly AppDbContext _context;

        public CartItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CartItem>> GetAllAsync()
        {
            return await _context.CartItems
                .Include(ci => ci.Product)
                .ToListAsync();
        }

        public async Task<CartItem?> GetByIdAsync(int id)
        {
            return await _context.CartItems
                .Include(ci => ci.Product)
                .FirstOrDefaultAsync(ci => ci.Id == id);
        }

        public async Task AddAsync(CartItem cartItem)
        {
            await _context.CartItems.AddAsync(cartItem);
        }

        public void Update(CartItem cartItem)
        {
            _context.CartItems.Update(cartItem);
        }

        public void Delete(CartItem cartItem)
        {
            _context.CartItems.Remove(cartItem);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
