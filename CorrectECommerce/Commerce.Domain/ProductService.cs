using System;
using System.Collections.Generic;
using System.Linq;

namespace Commerce.Domain
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IUserContext _userContext;

        public ProductService(IProductRepository repository, IUserContext userContext)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _userContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
        }

        public IEnumerable<DiscountedProduct> GetFeaturedProducts()
        {
            return from product in _repository.GetFeaturedProducts()
                select product.ApplyDiscountFor(_userContext);
        }
    }
}