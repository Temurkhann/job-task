using AutoMapper;
using JobTask.Data.IRepositories;
using JobTask.Domain.Entities;
using JobTask.Service.DTOs;
using JobTask.Service.Exceptions;
using JobTask.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JobTask.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async ValueTask<Product> CreateAsync(ProductForCreationDto dto)
        {
            var product = await productRepository.GetAsync(u => u.Title == dto.Title);

            if (product is not null)
                throw new JobTaskException(400, "Product already exists");

            Product mappedProduct = mapper.Map<Product>(dto);

            Product newProduct = await productRepository.AddAsync(mappedProduct);

            await productRepository.SaveChangesAsync();

            return newProduct;
        }

        public async ValueTask<bool> DeleteAsync(Expression<Func<Product, bool>> expression)
        {
            var product = await productRepository.GetAsync(expression);

            if (product is null )
                throw new JobTaskException(404, "Product not found");

            productRepository.Delete(product);

            await productRepository.SaveChangesAsync();

            return true;
        }

        public async ValueTask<IEnumerable<Product>> GetAllAsync(Expression<Func<Product, bool>> expression = null)
        {
            var products = productRepository.GetAll(expression);

            return products;
        }

        public async ValueTask<Product> GetAsync(Expression<Func<Product, bool>> expression)
        {
            var product = await productRepository.GetAsync(expression);

            if (product is null)
                throw new JobTaskException(404, "Product not found");

            return product;
        }

        public async ValueTask<Product> UpdateAsync(long id, ProductForCreationDto dto)
        {
            var product = await productRepository.GetAsync(u => u.Title == dto.Title);

            if (product is null)
                throw new JobTaskException(404, "User not found!");

            product = mapper.Map(dto, product);

            productRepository.Update(product);

            await productRepository.SaveChangesAsync();

            return product;
        }
    }
}
