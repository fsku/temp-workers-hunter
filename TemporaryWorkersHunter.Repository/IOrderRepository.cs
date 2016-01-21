using TemporaryWorkersHunter.Entities;
using TemporaryWorkersHunter.Repository.Common;

namespace TemporaryWorkersHunter.Repository
{
    public  interface IOrderRepository : IGenericRepository<Order>
    {
        Order GetById(int? id);
    }
}