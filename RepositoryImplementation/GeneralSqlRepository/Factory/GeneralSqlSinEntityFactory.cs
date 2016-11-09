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
    public class GeneralSqlSinEntityFactory : GenericAbstractEntityFactory<SinDto>
    {
         /// <summary>
         /// 
         /// </summary>
         /// <param name="dto"></param>
         /// <returns></returns>
         protected override IEntity MapEntityFrom(SinDto dto)
        {
            return new GeneralSqlSinEntity()
            {
                Id = dto.Id,
                Description = dto.Description,
                Name = dto.Name
            };
        }
    }
}
