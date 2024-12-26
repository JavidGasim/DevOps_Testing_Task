using DevOps_Testing_Task.Entities;

namespace DevOps_Testing_Task.Repositories.Abstracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product>? GetByIdAsync(int id);
        Task<Product>? AddAsync(Product product);
        Task<Product>? UpdateAsync(Product product);
        Task<bool> DeleteAsync(int id);
    }
}
