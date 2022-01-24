using Ecommerce.Framework.Entity;
using Ecommerce.Framework.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;
//using Ecommerce.Framework.Repository;

namespace Ecommerce.Framework.Services
{
    public class PurchaseService : IPurchaseService
    {
        private IShoppingUnitOfWork _shoppingUnitOfWork;
        public PurchaseService(IShoppingUnitOfWork shopingUnitOfWork)
        {
            _shoppingUnitOfWork = shopingUnitOfWork;
        }

        public IList<Product> GetProducts()
        {
            return _shoppingUnitOfWork.ProductRepository.GetAll();
        }

        public void AddProduct(Product product)
        {
            if (product != null)
            {
                _shoppingUnitOfWork.ProductRepository.Add(product);
                _shoppingUnitOfWork.Save();
            }
            else
                throw new InvalidOperationException("Product should be provided");
        }
    }
}
