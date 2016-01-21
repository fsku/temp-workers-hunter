using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TemporaryWorkersHunter.Entities.Common;

namespace TemporaryWorkersHunter.Entities
{
    public class RecruitmentAgency : Entity<int>
    {
        public string Name { get; set; }
        public Address Address { get; set; }    
        public IList<Worker> AvailableWorkers { get; set; }
    }
}
