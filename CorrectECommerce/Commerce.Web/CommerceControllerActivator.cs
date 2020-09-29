using System;
using Commerce.Domain;
using Commerce.SqlDataAccess;
using Commerce.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace Commerce.Web
{
    public class CommerceControllerActivator : IControllerActivator
    {
        private readonly CommerceConfiguration _configuration;

        // singletons
        private readonly IUserContext _userContext;

        public CommerceControllerActivator(CommerceConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _userContext = new AspNetUserContextAdapter();
        }

        public object Create(ControllerContext context) => this.Create(context.ActionDescriptor.ControllerTypeInfo.AsType());

        public void Release(ControllerContext context, object controller) => (controller as IDisposable)?.Dispose();

        public Controller Create(Type type)
        {
            var context = new CommerceContext(_configuration.ConnectionString);

            switch (type.Name)
            {
                case nameof(HomeController):
                    return new HomeController(
                        new ProductService(this.CreateProductRepository(context), this._userContext));

                default: throw new InvalidOperationException($"Unknown controller {type}.");
            }
        }

        private IProductRepository CreateProductRepository(CommerceContext context) =>
            (IProductRepository) Activator.CreateInstance(this._configuration.ProductRepositoryType, context);
    }
}