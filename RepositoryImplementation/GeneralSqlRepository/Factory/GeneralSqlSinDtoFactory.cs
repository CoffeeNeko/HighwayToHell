using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralSqlRepository.Entity;
using HighwayToHell.Repository.Dto;
using HighwayToHell.Repository.Factory;
using HighwayToHell.Repository.Interface;

namespace GeneralSqlRepository.Factory
{
    public class GeneralSqlSinDtoFactory : GenericAbstractDtoFactory<GeneralSqlSinEntity>
    {
        protected override IDto MapDtoFrom(GeneralSqlSinEntity entity)
        {
            return new SinDto()
            {
                Id = entity.Id,
                Description = entity.Description,
                Name = entity.Name,
    
            };
        }
    }
}
