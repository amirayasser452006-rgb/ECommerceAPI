using System;
using System.Collections.Generic;
using System.Text;

using Domain.DTOs.CartItem;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly ICartItemRepository _cartItemRepository;

        public CartItemService(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<IEnumerable<CartItemDto>> GetAllAsync()
        {
            var items = await _cartItemRepository.GetAllAsync();

            return items.Select(ci => new CartItemDto
            {
                Id = ci.Id,
                CartId = ci.CartId,
                ProductId = ci.ProductId,
                ProductName = ci.Product?.Name,
                ProductPrice = ci.Product?.Price,
                Quantity = ci.Quantity
            });
        }

        public async Task<CartItemDto?> GetByIdAsync(int id)
        {
            var item = await _cartItemRepository.GetByIdAsync(id);
            if (item == null) return null;

            return new CartItemDto
            {
                Id = item.Id,
                CartId = item.CartId,
                ProductId = item.ProductId,
                ProductName = item.Product?.Name,
                ProductPrice = item.Product?.Price,
                Quantity = item.Quantity
            };
        }

        public async Task<CartItemDto> CreateAsync(CreateUpdateCartItemDto dto)
        {
            var item = new CartItem
            {
                CartId = dto.CartId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity
            };

            await _cartItemRepository.AddAsync(item);
            await _cartItemRepository.SaveChangesAsync();

            return new CartItemDto
            {
                Id = item.Id,
                CartId = item.CartId,
                ProductId = item.ProductId,
                Quantity = item.Quantity
            };
        }

        public async Task<bool> UpdateAsync(int id, CreateUpdateCartItemDto dto)
        {
            var item = await _cartItemRepository.GetByIdAsync(id);
            if (item == null) return false;

            item.CartId = dto.CartId;
            item.ProductId = dto.ProductId;
            item.Quantity = dto.Quantity;

            _cartItemRepository.Update(item);
            await _cartItemRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _cartItemRepository.GetByIdAsync(id);
            if (item == null) return false;

            _cartItemRepository.Delete(item);
            await _cartItemRepository.SaveChangesAsync();
            return true;
        }
    }
}