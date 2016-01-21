using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.DynamicData;

namespace TemporaryWorkersHunter.Web.Converters.Interfaces
{
    public interface IBaseConverter<TViewModel,TEntity>
    {
        void ConvertViewModelToEntity(TViewModel viewModel, TEntity entity);
        void ConvertEntityToViewModel(TEntity entity, TViewModel viewModel);
        void RewritePropertiesFromViewModelToEntity(TViewModel viewModel, TEntity entity);
        void RewritePropertiesFromEntityToViewModel(TEntity entity, TViewModel viewModel);
    }
}
