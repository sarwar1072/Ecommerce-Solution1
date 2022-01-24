using Ecommerce.Framework.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Framework.Services
{
    public interface IPurchaseService
    {
        IList<Product> GetProducts();
        void AddProduct(Product product);
    }
}
