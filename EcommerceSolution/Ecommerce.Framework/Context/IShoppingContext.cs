using Ecommerce.Framework.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Framework.Context
{
   public interface IShoppingContext
    {

        DbSet<Category> Category { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<ProductCategory> ProductCategory { get; set; }
        DbSet<ProductImage> ProductImages { get; set; }
        DbSet<Product> Products { get; set; }
    }
}
