using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HighwayToHell.Repository.Interface;

namespace HighwayToHell.Repository.Factory
{
    public class DtoFactory : IDtoFactory
    {
        private readonly List<IDtoFactory> _dtoFactories;

        public DtoFactory ()
        {
            _dtoFactories = new List<IDtoFactory>();
        }
        
        public void RegisterFactory(IDtoFactory dtoFactory)
        {
            _dtoFactories.Add(dtoFactory);
        }

        public IDto GiveDtoOf(IEntity entity)
        {
            foreach (var dtoFactory in _dtoFactories)
            {
                var returnDto = dtoFactory.GiveDtoOf(entity);
                if (returnDto != null)
                {
                    return returnDto;
                }
            }

            return null;
        }
    }
}
