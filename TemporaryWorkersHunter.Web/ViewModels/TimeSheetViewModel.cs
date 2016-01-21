using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TemporaryWorkersHunter.Web.ViewModels.Common;

namespace TemporaryWorkersHunter.Web.ViewModels
{
    public class TimeSheetViewModel : ViewModel<int>
    {
        public DateTime Date { get; set; }
        public IList<TimeSheetRowViewModel> TimeSheetRows { get; set; }
    }
}