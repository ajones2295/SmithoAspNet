using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Models.DataModels;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private DatabaseContext _db;

        public OrderDetailRepository(DatabaseContext db) : base(db)
        {
            _db = db;
        }


        public void Update(OrderDetail orderDetail)
        {
            _db.OrderDetail.Update(orderDetail);
        }
    }
}