using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TemporaryWorkersHunter.Entities;
using TemporaryWorkersHunter.Web.Converters.Interfaces;
using TemporaryWorkersHunter.Web.ViewModels;

namespace TemporaryWorkersHunter.Web.Converters
{
    public class AddressConverter : BaseConverter<AddressViewModel,Address>, IAddressConverter
    {
        
    }
}
