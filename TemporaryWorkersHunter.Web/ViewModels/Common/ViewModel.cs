using System;
using TemporaryWorkersHunter.Entities.Common;

namespace TemporaryWorkersHunter.Web.ViewModels.Common
{
    public abstract class BaseViewModel
    {

    }

    public abstract class ViewModel<T> : BaseViewModel, IViewModel<T>
    {
        public virtual T Id { get; set; }
    }
}
