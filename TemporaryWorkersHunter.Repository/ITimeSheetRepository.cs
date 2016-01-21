using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemporaryWorkersHunter.Entities;
using TemporaryWorkersHunter.Repository.Common;

namespace TemporaryWorkersHunter.Repository
{
    public interface ITimeSheetRepository : IGenericRepository<TimeSheet>
    {
        List<TimeSheet> GetAllByDate(DateTime dateTime);
        List<TimeSheet> GetAllFromDate(DateTime dateTime);
        List<TimeSheet> GetAllForPerdiod(DateTime dateTimeFrom, DateTime dateTimeTo);

    }
}
