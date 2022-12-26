using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Models.DataModels;

namespace DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private DatabaseContext _db;

        public CoverTypeRepository(DatabaseContext db) : base(db)
        {
            _db = db;
        }


        public void Update(CoverType coverType)
        {
            _db.CoverTypes.Update(coverType);
        }
    }
}