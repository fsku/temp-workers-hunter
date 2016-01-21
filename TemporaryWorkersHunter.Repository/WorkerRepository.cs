using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using TemporaryWorkersHunter.Entities;
using TemporaryWorkersHunter.Repository.Common;

namespace TemporaryWorkersHunter.Repository
{
    public class WorkerRepository : GenericRepository<Worker>, IWorkerRepository
    {
        public WorkerRepository (DbContext context) : base(context)
        {

        }

        public Worker GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
