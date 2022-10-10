using JobTask.Domain.Entities;
using JobTask.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JobTask.Service.Interfaces
{
    public interface IProductService
    {
        ValueTask<Product> CreateAsync(ProductForCreationDto dto);
        ValueTask<Product> UpdateAsync(long id, ProductForCreationDto dto);
        ValueTask<Product> GetAsync(Expression<Func<Product, bool>> expression);
        ValueTask<IEnumerable<Product>> GetAllAsync(Expression<Func<Product, bool>> expression = null);
        ValueTask<bool> DeleteAsync(Expression<Func<Product, bool>> expression);
    }
}
