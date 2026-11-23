using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTOs;

namespace Domain.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto?> GetByIdAsync(int id);
        Task<ProductDto> CreateAsync(ProductDto dto);
        Task<bool> UpdateAsync(int id, ProductDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
