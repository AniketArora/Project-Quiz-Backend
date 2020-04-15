using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Project.Models.Repo_s {
    public interface IGenericRepo<TEntity> where TEntity : class {
        void Create(TEntity entity);
        void Delete(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(Guid id);
        Task<TEntity> GetAsync(int id);
        Task<TEntity> GetAsync<TPkType>(TPkType id);
        Task<IEnumerable<TEntity>> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression);
        Task SaveChangesAsync();
    }
}