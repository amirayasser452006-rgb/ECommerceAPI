using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTOs.Cart;

namespace Domain.ServiceInterfaces
{
    public interface ICartService
    {
        Task<IEnumerable<CartDto>> GetAllAsync();
        Task<CartDto?> GetByIdAsync(int id);
        Task<CartDto> CreateAsync(CreateUpdateCartDto dto);
        Task<bool> UpdateAsync(int id, CreateUpdateCartDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
