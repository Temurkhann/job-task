using JobTask.Data.DbContexts;
using JobTask.Data.IRepositories;
using JobTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTask.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(JobTaskDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
