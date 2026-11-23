using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTOs.Cart;
using Domain.Entities;
using Domain.ServiceInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class CartService : ICartService
    {
        private readonly AppDbContext _context;

        public CartService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CartDto>> GetAllAsync()
        {
            return await _context.Carts
                .Select(c => new CartDto
                {
                    Id = c.Id,
                    UserId = c.UserId
                })
                .ToListAsync();
        }

        public async Task<CartDto?> GetByIdAsync(int id)
        {
            var cart = await _context.Carts.FindAsync(id);
            if (cart == null) return null;

            return new CartDto
            {
                Id = cart.Id,
                UserId = cart.UserId
            };
        }

        public async Task<CartDto> CreateAsync(CreateUpdateCartDto dto)
        {
            var cart = new Cart
            {
                UserId = dto.UserId
            };

            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();

            return new CartDto
            {
                Id = cart.Id,
                UserId = cart.UserId
            };
        }

        public async Task<bool> UpdateAsync(int id, CreateUpdateCartDto dto)
        {
            var cart = await _context.Carts.FindAsync(id);
            if (cart == null) return false;

            cart.UserId = dto.UserId;

            _context.Carts.Update(cart);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cart = await _context.Carts.FindAsync(id);
            if (cart == null) return false;

            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}