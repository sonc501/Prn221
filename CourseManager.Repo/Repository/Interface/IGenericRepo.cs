using CourseManager.Repo.Commons;
using CourseManager.Repo.Models;
using System.Linq.Expressions;

namespace CourseManager.Repo.Repository.Interface
{
    public interface IGenericRepo<TEntity> where TEntity : BaseEntity
    {
        Task<List<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity?> GetByIdAsync(int id, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression,params Expression<Func<TEntity, object>>[] includes);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void UpdateRange(List<TEntity> entity);
        void SoftRemove(TEntity entity);
        Task<Pagination<TEntity>> ToPagination(int pageIndex = 0, int pageSize = 10, params Expression<Func<TEntity, object>>[] includes);
        Task<Pagination<TEntity>> ToPagination(Expression<Func<TEntity, bool>> expression, int pageIndex = 0, int pageSize = 10, params Expression<Func<TEntity, object>>[] includes);
        Task<Pagination<TEntity>> ToPagination(IQueryable<TEntity> value, Expression<Func<TEntity, bool>> expression, int pageIndex, int pageSize, params Expression<Func<TEntity, object>>[] includes);
    }
}
