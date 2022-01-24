using DataAccessLayer;
using Ecommerce.Framework.Context;
using Ecommerce.Framework.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Framework.Repository
{
   public interface ICategoryRepository: IRepository<Category, int, ShoppingContext>
    {
    }
}
