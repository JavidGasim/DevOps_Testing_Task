using DevOps_Testing_Task.Entities;
using DevOps_Testing_Task.Repositories.Abstracts;
using DevOps_Testing_Task.Services.Abstracts;

namespace DevOps_Testing_Task.Services.Concretes
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<Product>? AddAsync(Product product)
        {
            return await _repository.AddAsync(product);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<Product>? GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<Product>? UpdateAsync(Product product)
        {
            return await _repository.UpdateAsync(product);
        }
    }
}
