using TemporaryWorkersHunter.Entities;
using TemporaryWorkersHunter.Repository.Common;

namespace TemporaryWorkersHunter.Repository
{
    public interface IWorkerRepository : IGenericRepository<Worker>
    {
        Worker GetById(int id);
    }
}