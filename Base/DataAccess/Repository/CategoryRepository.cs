using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Models.DataModels;

namespace DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private DatabaseContext _db;
        public CategoryRepository(DatabaseContext db) : base(db)
        {
            _db = db;
        }

        public async Task Create(Category category)
        {
            _db.Categories.Add(category);
            await _db.SaveChangesAsync();
        }

        public async Task Update(Category category)
        {
            _db.Categories.Update(category);
            await _db.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
            var category = _db.Categories.Find(id);
            _db.Categories.Remove(category);
            await _db.SaveChangesAsync();

        }

        public async Task<string> GetName(int? id)
        {
            var category = await _db.Categories.FindAsync(id);
            return category.Name;
        }
    }
}