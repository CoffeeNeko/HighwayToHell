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
    public class GeneralSqlPersonDtoFactory : GenericAbstractDtoFactory<GeneralSqlPersonEntity>
    {
        protected override IDto MapDtoFrom(GeneralSqlPersonEntity entity)
        {
            return new PersonDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                Surname = entity.Surname
            };
        }
    }
}
