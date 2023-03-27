using DataAccess.Data;

namespace Api.Configurations.Policies
{
    public class NumberOfDaysForAccount : INumberOfDaysForAccount
    {
        private readonly DatabaseContext _db;
        public NumberOfDaysForAccount(DatabaseContext db)
        {
            _db = db;
        }

        public int Get(string userId)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.Id == userId);
            if (user != null && user.DateCreated != DateTime.MinValue)
            {
                return (DateTime.Today - user.DateCreated).Days;
            }
            return 0;
        }
    }

}