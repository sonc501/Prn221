using CourseManager.Repo.Commons;
using CourseManager.Repo.Models;
using CourseManager.Repo.Repository.Interface;
using CourseManager.Repo.UnitOfWorks;
using CourseManager.Service.Interfaces;
using System.Linq.Expressions;

namespace CourseManager.Service.Services
{
    public class Service<T> : IService<T> where T : BaseEntity
    {
        protected readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepo<T> _repo;

        public Service(IUnitOfWork unitOfWork, IGenericRepo<T> repo)
        {
            _unitOfWork = unitOfWork;
            _repo = repo;
        }
        public async Task<bool> Add(T item)
        {
            await _repo.AddAsync(item);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> Delete(T item)
        {
            _repo.SoftRemove(item);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression,params Expression<Func<T, object>>[] includes)
        {
            return (await _repo.GetAsync(expression,includes))!;
        }

        public async Task<List<T>> GetAll()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<T> GetById(int id)
        {
            return (await _repo.GetByIdAsync(id))!;
        }

        public async Task<Pagination<T>> GetByPage(int page = 0, int pageSize = 10, params Expression<Func<T, object>>[] includes)
        {
            return await _repo.ToPagination(page, pageSize,includes);
        }

        public async Task<Pagination<T>> GetByPage(Expression<Func<T, bool>> expression, int pageIndex = 0, int pageSize = 10, params Expression<Func<T, object>>[] includes)
        {
            return await _repo.ToPagination(expression, pageIndex, pageSize, includes);
        }

        public async Task<bool> Update(T item)
        {
            _repo.Update(item);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> UpdateRange(List<T> list)
        {
            _repo.UpdateRange(list);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
    }
}
