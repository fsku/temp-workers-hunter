using TemporaryWorkersHunter.Entities;
using TemporaryWorkersHunter.Service.Common;

namespace TemporaryWorkersHunter.Service
{
    public interface IWorkerService : IEntityService<Worker>
    {
        Worker GetById(int id);
        void Add(Worker worker);
    }
}