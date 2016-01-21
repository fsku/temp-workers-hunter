using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TemporaryWorkersHunter.Entities.Common;

namespace TemporaryWorkersHunter.Entities
{
    public class OrderRow : Entity<int>
    {
        public Worker OrderedWorker { get; set; }
        public IList<Competence> WorkerCompetences { get; set; }
        public IList<AvailabilityPeriod> AvailabilityPeriods { get; set; }
    }
}
