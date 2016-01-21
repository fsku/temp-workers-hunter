using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemporaryWorkersHunter.Entities;
using TemporaryWorkersHunter.Repository;
using TemporaryWorkersHunter.Repository.Common;
using TemporaryWorkersHunter.Service.Common;

namespace TemporaryWorkersHunter.Service
{
    public class OrderService : EntityService<Order>, IOrderService
    {
        private IUnitOfWork _unitOfWork;
        private IWorkerRepository _workerRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IUnitOfWork unitOfWork, IGenericRepository<Order> repository, IWorkerRepository workerRepository, IOrderRepository orderRepository) : base(unitOfWork, repository)
        {
            _workerRepository = workerRepository;
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _orderRepository.GetAll();
        }

        public Order GetById(int? id)
        {
            return _orderRepository.GetById(id);
        }
    }
}
