using DataAccessLayer;
using Ecommerce.Framework.Context;
using Ecommerce.Framework.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Framework.UnitOfWorks
{
    public class ShoppingUnitOfWork : UnitOfWork, IShoppingUnitOfWork
    {
        public IProductRepository ProductRepository { get ; set ; }
        public ICategoryRepository CategoryRepository {get; set ; }
        public ICustomerRepository CustomerRepository { get; set; }
        public ShoppingUnitOfWork(IProductRepository productRepository, 
            ICategoryRepository categoryRepository,
            ICustomerRepository customerRepository,
            ShoppingContext dbContext) :base(dbContext)
        {
            ProductRepository = productRepository;
            CustomerRepository = customerRepository;
            CategoryRepository = categoryRepository;
        }
    }
}
