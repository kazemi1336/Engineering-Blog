using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using EnggBlog.DataLayer.Entities;

namespace EnggBlog.DataLayer.Context
{
    public class EnggBlogContext : DbContext
    {
        public EnggBlogContext(DbContextOptions<EnggBlogContext> options) : base (options)
        {

        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductDownloadFile> ProductDownloadFiles { get; set; }

    }
}
