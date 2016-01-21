using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TemporaryWorkersHunter.Entities;
using TemporaryWorkersHunter.Web.Converters;
using TemporaryWorkersHunter.Web.ViewModels;
using ImageConverter = TemporaryWorkersHunter.Web.Converters.ImageConverter;

namespace TemporaryWorkersHunter.Web.Tests.Converters
{
    [TestClass]
    public class ConvertersTests
    {
        [TestMethod]
        public void ConvertAddressViewModel_WhenValidViewModel_ReturnEntity()
        {
            var converter = new AddressConverter();
            var viewModel = new AddressViewModel
            {
                Street = "Washington Street",
                ZipCode = "61-422",
                Number = 25,
                Id = 1,
                ApartmentNumber = 22
            };
            var entity = new Address();

            converter.ConvertViewModelToEntity(viewModel, entity);

            Assert.AreEqual(entity.Street, viewModel.Street);
        }

        [TestMethod]
        public void ConvertAddressEntity_WhenValidEntity_ReturnViewModel()
        {
            var converter = new AddressConverter();
            var viewModel = new Address
            {
                Street = "Washington Street",
                ZipCode = "61-422",
                Number = 25,
                Id = 1,
                ApartmentNumber = 22
            };
            var entity = new AddressViewModel();

            converter.ConvertEntityToViewModel(viewModel, entity);

            Assert.AreEqual(entity.Street, viewModel.Street);
        }

        [TestMethod]
        public void ConvertWorkerViewModel_WhenValidViewModel_ReturnEntity()
        {
            var adrConv = new AddressConverter();
            var compConv = new CompetenceConverter();
            var converter = new WorkerConverter(adrConv,compConv,new ImageConverter());

            var viewModel = new WorkerViewModel
            {
                FirstName = "Filip",
                LastName = "Skurniak",
                Pesel = "632964328947",
                RelianceRating = 10,
                WorkerCompetences = new List<CompetenceViewModel>()
                {
                    new CompetenceViewModel
                    {
                        Id = 100
                    }
                }
            };
            var entity = new Worker();

            converter.ConvertViewModelToEntity(viewModel, entity);

            Assert.AreEqual(entity.FirstName, viewModel.FirstName);
        }

    }
}
