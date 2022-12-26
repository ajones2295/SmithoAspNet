using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Models.DataModels;

namespace DataAccess.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private DatabaseContext _db;

        public CompanyRepository(DatabaseContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Company company)
        {
            _db.Companies.Update(company);
        }
    }
}