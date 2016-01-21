using System.ComponentModel.DataAnnotations;
using TemporaryWorkersHunter.Entities.Common;

namespace TemporaryWorkersHunter.Entities
{
    public class TimeSheetRow : Entity<int>
    {
        public Worker Worker { get; set; }
        public bool IsPresent { get; set; }
        public int NumberOfHours { get; set; }

        public bool IsLate { get; set; }
    }
}
