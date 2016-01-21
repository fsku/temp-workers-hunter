using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemporaryWorkersHunter.Entities;
using TemporaryWorkersHunter.Repository;
using TemporaryWorkersHunter.Repository.Common;
using TemporaryWorkersHunter.Service.Common;

namespace TemporaryWorkersHunter.Service
{
    public class TimeSheetService : EntityService<TimeSheet>, ITimeSheetService
    {
        IUnitOfWork _unitOfWork;
        ITimeSheetRepository _timeSheetRepository;

        public TimeSheetService(IUnitOfWork unitOfWork, ITimeSheetRepository repository) : base(unitOfWork, repository)
        {
            _unitOfWork = unitOfWork;
            _timeSheetRepository = repository;
        }

        public List<TimeSheet> GetAllByDate(DateTime dateTime)
        {
            return _timeSheetRepository.GetAllByDate(dateTime);
        }

        public List<TimeSheet> GetAllFromDate(DateTime dateTime)
        {
            return _timeSheetRepository.GetAllFromDate(dateTime);
        }

        public List<TimeSheet> GetAllForPerdiod(DateTime dateTimeFrom, DateTime dateTimeTo)
        {
            return _timeSheetRepository.GetAllForPerdiod(dateTimeFrom, dateTimeTo);
        }
    }
}
