using DataAccessLayer;
using Ecommerce.Framework.Context;
using Ecommerce.Framework.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Framework.Repository
{
   public class CategoryRepository: Repository<Category, int, ShoppingContext>, ICategoryRepository
    {
        public CategoryRepository(ShoppingContext dbcontext):base(dbcontext)
        {

        }
    }
}
