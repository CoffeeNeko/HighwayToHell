using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HighwayToHell.Repository.Interface;

namespace HighwayToHell.Repository.Factory
{
    public abstract class GenericAbstractDtoFactory<TEntity> : IDtoFactory 
        where TEntity : class, IEntity
    {
        public IDto GiveDtoOf(IEntity entity)
        {
            return entity.GetType() == typeof(TEntity) ? MapDtoFrom(entity as TEntity) : null;
        }

        protected abstract IDto MapDtoFrom(TEntity entity);
    }
}
