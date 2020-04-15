using Microsoft.EntityFrameworkCore;
using Project.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.Repo_s {
    public class GenericRepo<TEntity> : IGenericRepo<TEntity> where TEntity : class {
        private readonly ProjectDbContext _context;

        public GenericRepo(ProjectDbContext context) {
            this._context = context;
        }

        // CR(U)D

        public void Create(TEntity entity) {
            _context.Set<TEntity>().Add(entity);
        }


        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression) {
            return await _context.Set<TEntity>().Where(expression).ToListAsync();
        }

        public virtual async Task<TEntity> GetAsync(int id) {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<TEntity> GetAsync(Guid id) {
            return await _context.Set<TEntity>().FindAsync(id);
        }
        
        public virtual async Task<TEntity> GetAsync<TPkType>(TPkType id) {
            return await _context.Set<TEntity>().FindAsync(id);
        }


        public void Delete(TEntity entity) {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task SaveChangesAsync() {
            await _context.SaveChangesAsync();
        }
    }
}
