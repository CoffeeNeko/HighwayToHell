using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HighwayToHell.Repository.Interface;

namespace HighwayToHell.Repository.Factory
{
    public class EntityFactory : IEntityFactory
    {
        private readonly List<IEntityFactory> _entityFactories;

        public EntityFactory()
        {
            _entityFactories = new List<IEntityFactory>();
        }

        public void RegisterFactory(IEntityFactory dtoFactory)
        {
            _entityFactories.Add(dtoFactory);
        }

        public IEntity GiveEntityOf(IDto dto)
        {
            foreach (var entityFactory in _entityFactories)
            {
                var returnDto = entityFactory.GiveEntityOf(dto);
                if (returnDto != null)
                {
                    return returnDto;
                }
            }

            return null;
        }
    }
}
