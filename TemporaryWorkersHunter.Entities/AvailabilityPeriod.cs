using System;
using System.ComponentModel.DataAnnotations;
using TemporaryWorkersHunter.Entities.Common;

namespace TemporaryWorkersHunter.Entities
{
    public class AvailabilityPeriod : Entity<int>
    {
        public DateTime AvailabeFromDate { get; set; }
        public DateTime AvailabeToDate { get; set; }
    }
}