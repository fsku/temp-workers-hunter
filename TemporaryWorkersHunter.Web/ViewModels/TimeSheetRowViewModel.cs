using TemporaryWorkersHunter.Web.ViewModels.Common;

namespace TemporaryWorkersHunter.Web.ViewModels
{
    public class TimeSheetRowViewModel : ViewModel<int>
    {
        public WorkerViewModel Worker { get; set; }
        public bool IsPresent { get; set; }
        public int NumberOfHours { get; set; }

        public bool IsLate { get; set; }
    }
}