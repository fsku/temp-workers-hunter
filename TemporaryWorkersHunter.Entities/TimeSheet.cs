using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TemporaryWorkersHunter.Entities.Common;

namespace TemporaryWorkersHunter.Entities
{
    public class TimeSheet : Entity<int>
    {
        public DateTime Date { get; set; }
        public IList<TimeSheetRow>TimeSheetRows { get; set; }
    }
}
