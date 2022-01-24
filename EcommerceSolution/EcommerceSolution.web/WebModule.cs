using Autofac;
using Ecommerce.Framework.Context;
using EcommerceSolution.web.Areas.Admin.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSolution.web
{
    public class WebModule:Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public WebModule(string connectionString, string migrationAssemblyName
            , IWebHostEnvironment webHostEnvironment)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
            _webHostEnvironment = webHostEnvironment;
        }

        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<HtmlEmailService>().As<IEmailService>()
            //    .SingleInstance();

            //builder.RegisterType<ShoppingContext>()
            //    .WithParameter("connectionString", _connectionString)
            //    .WithParameter("migrationAssemblyName", _migrationAssemblyName);

            //builder.RegisterType<IndexModel>().AsSelf();
            builder.RegisterType<ProductModel>().AsSelf();
           // builder.RegisterType<ProductUpdateModel>().AsSelf();


            base.Load(builder);
        }
    }
}
