using DataAccessLayer;
using Ecommerce.Framework.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Framework.UnitOfWorks
{
   public  interface IShoppingUnitOfWork: IUnitOfWork
    {
        IProductRepository ProductRepository { get; set; }
        ICategoryRepository CategoryRepository { get; set; }
        ICustomerRepository CustomerRepository { get; set; }
    }
}
