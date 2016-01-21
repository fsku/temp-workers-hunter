using System.Transactions;
using TemporaryWorkersHunter.Entities;
using TemporaryWorkersHunter.Repository;
using TemporaryWorkersHunter.Repository.Common;
using TemporaryWorkersHunter.Service.Common;

namespace TemporaryWorkersHunter.Service
{
    public class WorkerService : EntityService<Worker>, IWorkerService
    {
        IUnitOfWork _unitOfWork;
       IWorkerRepository _workerRepository;

        public WorkerService(IUnitOfWork unitOfWork, IWorkerRepository workerRepository)
            : base(unitOfWork, workerRepository)
        {
            _unitOfWork = unitOfWork;
            _workerRepository = workerRepository;
        }
        
        public Worker GetById(int id)
        {
            return _workerRepository.GetById(id);
        }

        public void Add(Worker worker)
        {
            using (var ts = new TransactionScope())
            {
                _workerRepository.Add(worker);
                _workerRepository.Save();

                ts.Complete();
            }
        }
    }
}
