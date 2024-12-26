using DevOps_Testing_Task.Entities;

namespace DevOps_Testing_Task.Services.Abstracts
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product>? GetByIdAsync(int id);
        Task<Product>? AddAsync(Product product);
        Task<Product>? UpdateAsync(Product product);
        Task<bool> DeleteAsync(int id);
    }
}
