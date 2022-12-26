using Models.DataModels;

namespace DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task Create(Category category);
        Task Update(Category category);
        Task Delete(int id);
        Task<string> GetName(int? id);
    }
}