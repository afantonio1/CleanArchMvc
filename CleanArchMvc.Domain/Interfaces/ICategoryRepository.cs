﻿using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> GetByIdAsync(int? id);
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> CreateAsync(Category category);
        Task<Category> UpdateAsync(Category category);
        Task<Category> RemoveAsync(Category category);
    }
}
