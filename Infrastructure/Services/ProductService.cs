using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();

            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock
            });
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return null;

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            };
        }

        public async Task<ProductDto> CreateAsync(ProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Stock = dto.Stock
            };

            await _productRepository.AddAsync(product);
            await _productRepository.SaveChangesAsync();

            dto.Id = product.Id;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, ProductDto dto)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return false;

            product.Name = dto.Name;
            product.Price = dto.Price;
            product.Stock = dto.Stock;

            _productRepository.Update(product);
            await _productRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return false;

            _productRepository.Delete(product);
            await _productRepository.SaveChangesAsync();
            return true;
        }
    }
}