using JobTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTask.Data.DbContexts
{
    public class JobTaskDbContext : DbContext
    {
        public JobTaskDbContext(DbContextOptions<JobTaskDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<User> JobTasks { get; set; }
        public virtual DbSet<Product> UserTasks { get; set; }
    }
}
