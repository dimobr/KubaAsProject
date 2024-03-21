using System.Threading.Tasks;
using KubaAsProject.Models;

namespace KubaAsProject.Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetByIdAsync(int id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteByIdAsync(int id);
        Task<IQueryable<TEntity>> GetAllAsync();    
    }
}
