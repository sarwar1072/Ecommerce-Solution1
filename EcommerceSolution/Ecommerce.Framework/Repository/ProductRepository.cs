using DataAccessLayer;
using Ecommerce.Framework.Context;
using Ecommerce.Framework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Ecommerce.Framework.Repository
{
    public class ProductRepository :Repository<Product,int, ShoppingContext> ,IProductRepository
    {
        public ProductRepository(ShoppingContext dbContext):base(dbContext)
        {
                
        }

        public IList<Product> GetLatestProducts()
        {
            throw new NotImplementedException();
        }
    }
}
