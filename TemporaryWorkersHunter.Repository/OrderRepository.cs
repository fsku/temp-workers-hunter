using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemporaryWorkersHunter.Entities;
using TemporaryWorkersHunter.Repository.Common;

namespace TemporaryWorkersHunter.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository   
    {
        public OrderRepository(DbContext context) : base(context)
        {

        }

        public Order GetById(int? id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
