using BeautySalon.Backend.Data;
using BeautySalon.Backend.Repositories.Interface;
using BeautySalon.Shared.Response;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Collections;

namespace BeautySalon.Backend.Repositories.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly BeatySalonContext _context;

        public GenericRepository(BeatySalonContext context)
        {
            _context = context;
        }

        public virtual async Task<ActionResponse<T>> AddAsync(T entity)
        {
            _context.Add(entity);
            try
            {
                await _context.SaveChangesAsync();
                return new ActionResponse<T>
                {
                    Success = true,
                    Result = entity
                };
            }
            catch (Exception ex)
            {
                return ExceptionActionResponse(ex);
            }
        }

        public virtual async Task<ActionResponse<T>> DeleteAsync(int id)
        {
            var row = await _context.FindAsync<T>(id);
            if (row != null)
            {
                return new ActionResponse<T>
                {
                    Success = false,
                };
            }
            _context.Remove(row);
            try
            {
                await _context.SaveChangesAsync();
                return new ActionResponse<T>
                {
                    Success = true,
                };
            }
            catch
            {
                return new ActionResponse<T>
                {
                    Success = false,
                    Message = "ERR002"
                };
            }
        }

        public Task<ActionResponse<T>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResponse<IEnumerable>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResponse<T>> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        private ActionResponse<T> ExceptionActionResponse(Exception ex)
        {
            return new ActionResponse<T>
            {
                Success = false,
                Message = ex.Message,
            };
        }
    }
}