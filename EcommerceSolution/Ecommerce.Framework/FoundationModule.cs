using Autofac;
using Ecommerce.Framework.Context;
using Ecommerce.Framework.Repository;
using Ecommerce.Framework.Services;
using Ecommerce.Framework.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Framework
{
  public  class FoundationModule:Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public FoundationModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ShoppingContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName);

            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<ShoppingUnitOfWork>().As<IShoppingUnitOfWork>();
             builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<ShopService>().As<IShopService>();
            builder.RegisterType<PurchaseService>().As<IPurchaseService>();



            base.Load(builder);
        }
    }
}
