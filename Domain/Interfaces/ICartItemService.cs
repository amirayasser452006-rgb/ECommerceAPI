using System;
using System.Collections.Generic;
using System.Text;

using Domain.DTOs.CartItem;

namespace Domain.Interfaces
{
    public interface ICartItemService
    {
        Task<IEnumerable<CartItemDto>> GetAllAsync();
        Task<CartItemDto?> GetByIdAsync(int id);
        Task<CartItemDto> CreateAsync(CreateUpdateCartItemDto dto);
        Task<bool> UpdateAsync(int id, CreateUpdateCartItemDto dto);
        Task<bool> DeleteAsync(int id);
    }
}