using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemporaryWorkersHunter.Entities;
using TemporaryWorkersHunter.Web.Converters.Interfaces;
using TemporaryWorkersHunter.Web.ViewModels;

namespace TemporaryWorkersHunter.Web.Converters
{
    public class CompetenceConverter : BaseConverter<CompetenceViewModel,Competence>, ICompetenceConverter
    {
    }
}
