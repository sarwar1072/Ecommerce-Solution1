using DataAccessLayer;
using Ecommerce.Framework.Context;
using Ecommerce.Framework.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Framework.Repository
{
    public class CustomerRepository: Repository<Customer, int, ShoppingContext>,ICustomerRepository
    {
        public CustomerRepository(ShoppingContext dbcontext):base(dbcontext)
        {

        }

    }
}
