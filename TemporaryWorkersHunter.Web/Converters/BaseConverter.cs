using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TemporaryWorkersHunter.Web.Converters.Interfaces;
using static System.Diagnostics.Contracts.Contract;

namespace TemporaryWorkersHunter.Web.Converters
{
    public abstract class BaseConverter<TViewModel, TEntity> : IBaseConverter<TViewModel, TEntity>
    {
        public void ConvertViewModelToEntity(TViewModel viewModel, TEntity entity)
        {
            RewritePropertiesFromViewModelToEntity(viewModel, entity);
        }

        public void ConvertEntityToViewModel(TEntity entity, TViewModel viewModel)
        {
            RewritePropertiesFromEntityToViewModel(entity, viewModel);
        }

        public void RewritePropertiesFromViewModelToEntity(TViewModel viewModel, TEntity entity)
        {
            PropertyInfo[] props = viewModel.GetType().GetProperties();

            foreach (PropertyInfo prop in props)
            {
                object propValue = prop.GetValue(viewModel, null);

                Type innerType;
                bool isPropAGenericType = TryListOfWhat(prop.GetType(), out innerType);
                    
                if (!isPropAGenericType)
                {
                    PropertyInfo entityProp = entity.GetType().GetProperty(prop.Name);
                    entityProp.SetValue(entity, propValue, null);
                }
            }
        }

        public void RewritePropertiesFromEntityToViewModel(TEntity entity, TViewModel viewModel)
        {
            PropertyInfo[] props = entity.GetType().GetProperties();

            foreach (PropertyInfo prop in props)
            {
                object propValue = prop.GetValue(entity, null);
                PropertyInfo entityProp = viewModel.GetType().GetProperty(prop.Name);
                entityProp.SetValue(viewModel, propValue, null);
            }
        }

        private static bool TryListOfWhat(Type type, out Type innerType)
        {
            var interfaceTest = new Func<Type, Type>(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IList<>) ? i.GetGenericArguments().Single() : null);

            innerType = interfaceTest(type);
            if (innerType != null)
            {
                return true;
            }

            foreach (var i in type.GetInterfaces())
            {
                innerType = interfaceTest(i);
                if (innerType != null)
                {
                    return true;
                }
            }

            return false;
        }

    }
}