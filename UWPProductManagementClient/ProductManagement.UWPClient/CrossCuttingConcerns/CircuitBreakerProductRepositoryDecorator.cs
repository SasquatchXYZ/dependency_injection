using System;
using System.Collections.Generic;
using ProductManagement.Domain;

namespace ProductManagement.UWPClient.CrossCuttingConcerns
{
    public class CircuitBreakerProductRepositoryDecorator : IProductRepository
    {
        private readonly ICircuitBreaker _breaker;
        private readonly IProductRepository _decoratee;

        public CircuitBreakerProductRepositoryDecorator(
            ICircuitBreaker breaker, IProductRepository decoratee)
        {
            _breaker = breaker;
            _decoratee = decoratee;
        }

        public void Delete(Guid id) => _breaker.Execute(() => _decoratee.Delete(id));
        public IEnumerable<Product> GetAll() => _breaker.Execute(() => _decoratee.GetAll());
        public Product GetById(Guid id) => _breaker.Execute(() => _decoratee.GetById(id));
        public void Insert(Product product) => _breaker.Execute(() => _decoratee.Insert(product));
        public void Update(Product product) => _breaker.Execute(() => _decoratee.Update(product));
    }
}