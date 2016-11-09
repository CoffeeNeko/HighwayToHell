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
    /// <summary>
    /// 
    /// </summary>
    public class GeneralSqlPersonEntityFactory : GenericAbstractEntityFactory<PersonDto>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        protected override IEntity MapEntityFrom(PersonDto dto)
        {
            return new GeneralSqlPersonEntity()
            {
                Id = dto.Id,
                Name = dto.Name,
                Surname = dto.Surname
            };
        }
    }
}
