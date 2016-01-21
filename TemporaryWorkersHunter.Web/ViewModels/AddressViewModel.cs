using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemporaryWorkersHunter.Entities;
using TemporaryWorkersHunter.Web.ViewModels.Common;

namespace TemporaryWorkersHunter.Web.ViewModels
{
    public class AddressViewModel : ViewModel<int>
    {
        public string Street { get; set; }
        public int Number { get; set; }
        public int ApartmentNumber { get; set; }
        public string ZipCode { get; set; }
    }
}
