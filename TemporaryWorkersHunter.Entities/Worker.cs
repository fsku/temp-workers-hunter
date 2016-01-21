using System.Collections.Generic;
using TemporaryWorkersHunter.Entities.Common;

namespace TemporaryWorkersHunter.Entities
{
    public class Worker : Entity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Image { get; set; }
        public Address Address { get; set; }
        public string Pesel { get; set; }
        public int RelianceRating { get; set; } 
        public IList<Competence> WorkerCompetences { get; set; }
        public RecruitmentAgency RecruitmentAgency { get; set; } 
    }
}
