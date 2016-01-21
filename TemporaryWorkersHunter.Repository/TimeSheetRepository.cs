using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemporaryWorkersHunter.Entities;
using TemporaryWorkersHunter.Repository.Common;

namespace TemporaryWorkersHunter.Repository
{
    public class TimeSheetRepository : GenericRepository<TimeSheet>, ITimeSheetRepository
    {
        public TimeSheetRepository(DbContext context) : base(context)
        {

        }

        public List<TimeSheet> GetAllByDate(DateTime dateTime)
        {
            return FindBy(x => x.Date == dateTime).ToList();
        }

        public List<TimeSheet> GetAllFromDate(DateTime dateTime)
        {
            return FindBy(x => x.Date >= dateTime).ToList();
        }

        public List<TimeSheet> GetAllForPerdiod(DateTime dateTimeFrom, DateTime dateTimeTo)
        {
            return FindBy(x => x.Date >= dateTimeFrom && x.Date <= dateTimeTo).ToList();
        }
    }
}
