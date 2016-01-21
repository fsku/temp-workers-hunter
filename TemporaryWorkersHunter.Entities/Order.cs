using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TemporaryWorkersHunter.Entities.Common;

namespace TemporaryWorkersHunter.Entities
{
    public class Order : Entity<int>
    {
        public IList<OrderRow> OrderRows { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
