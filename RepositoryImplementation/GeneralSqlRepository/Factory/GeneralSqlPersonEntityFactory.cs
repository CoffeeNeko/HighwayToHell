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

        private Func<IDto, IEntity> _transformSin;

        public GeneralSqlPersonEntityFactory(Func<IDto, IEntity> func)
        {
            _transformSin = func;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        protected override IEntity MapEntityFrom(PersonDto dto)
        {
            List<IEntity> sins = new List<IEntity>();


            GeneralSqlPersonEntity Person = new GeneralSqlPersonEntity()
            {
                Id = dto.Id,
                Name = dto.Name,
                Surname = dto.Surname
            };

            foreach (IDto sin in dto.Sins)
            {
                Person.Sins.Add(_transformSin(sin));
            }

            return Person;
        }
    }
}
