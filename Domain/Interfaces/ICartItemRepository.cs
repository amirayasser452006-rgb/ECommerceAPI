using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICartItemRepository
    {
        Task<IEnumerable<CartItem>> GetAllAsync();
        Task<CartItem?> GetByIdAsync(int id);
        Task AddAsync(CartItem cartItem);
        void Update(CartItem cartItem);
        void Delete(CartItem cartItem);
        Task SaveChangesAsync();
    }
}