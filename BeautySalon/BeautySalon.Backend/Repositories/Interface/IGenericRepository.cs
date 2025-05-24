using BeautySalon.Shared.Response;
using System.Collections;

namespace BeautySalon.Backend.Repositories.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<ActionResponse<T>> GetAsync(int id);

        Task<ActionResponse<IEnumerable>> GetAsync();

        Task<ActionResponse<T>> AddAsync(T entity);

        Task<ActionResponse<T>> DeleteAsync(int id);

        Task<ActionResponse<T>> UpdateAsync(T entity);
    }
}