using System.Collections.Generic;
using TemporaryWorkersHunter.Entities;
using TemporaryWorkersHunter.Service.Common;

namespace TemporaryWorkersHunter.Service
{
    public interface IOrderService : IEntityService<Order>
    {
        IEnumerable<Order> GetAllOrders();
        Order GetById(int? id);
    }
}