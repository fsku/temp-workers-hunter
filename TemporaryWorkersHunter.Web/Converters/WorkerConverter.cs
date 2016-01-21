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
    public class WorkerConverter : BaseConverter<WorkerViewModel,Worker>, IWorkerConverter
    {
        private IAddressConverter _addressConverter ;
        private ICompetenceConverter _competenceConverter;
        private IImageConverter _imageConverter;

        public WorkerConverter(IAddressConverter addressConverter, ICompetenceConverter competenceConverter, IImageConverter imageConverter)
        {
            _addressConverter = addressConverter;
            _competenceConverter = competenceConverter;
            _imageConverter = imageConverter;
        }

        public new void ConvertViewModelToEntity(WorkerViewModel viewModel, Worker entity)
        {
            if (viewModel.Address != null)
            {
                _addressConverter.ConvertViewModelToEntity(viewModel.Address, entity.Address);
            }

            if (viewModel.Image != null)
            {
                entity.Image = _imageConverter.ImageToByteArray(viewModel.Image);
            }

            if (viewModel.WorkerCompetences.Any())
            {
                entity.WorkerCompetences = null;

                foreach (var competence in viewModel.WorkerCompetences)
                {
                    var entityCompetence = new Competence();

                    _competenceConverter.ConvertViewModelToEntity(competence, entityCompetence);

                    entity.WorkerCompetences?.Add(entityCompetence);
                }
            }

            base.ConvertViewModelToEntity(viewModel, entity);
        }
    }
}
