using System;
using System.Collections.Generic;
using System.Drawing;
using TemporaryWorkersHunter.Web.ViewModels.Common;

namespace TemporaryWorkersHunter.Web.ViewModels
{
    public class WorkerViewModel : ViewModel<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Image Image { get; set; }
        public AddressViewModel Address { get; set; }
        public string Pesel { get; set; }
        public int RelianceRating { get; set; }
        public IList<CompetenceViewModel> WorkerCompetences { get; set; }
    }
}
