using HighwayToHell.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralSqlRepository.Dao;
using GeneralSqlRepository.Interface;
using HighwayToHell.Repository.Dto;

namespace GeneralSqlRepository.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class GeneralSqlRepositoryBase : IRepository
    {
        private readonly string _connectionString = Properties.Settings.Default.ConnectionString;

        private readonly GeneralSqlSinDao _sinDao;
        private readonly GeneralSqlPersonDao _personDao;
        private readonly GeneralSqlPersonAndSinDao _personAndSinDao;
        private readonly IDtoFactory _dtoFactory;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sinDao"></param>
        /// <param name="personDao"></param>
        /// <param name="dtoFactory"></param>
        /// <param name="personAndSinDao"></param>
        public GeneralSqlRepositoryBase(GeneralSqlSinDao sinDao, GeneralSqlPersonDao personDao, IDtoFactory dtoFactory, GeneralSqlPersonAndSinDao personAndSinDao)
        {
            _sinDao = sinDao;
            _personDao = personDao;
            _personAndSinDao = personAndSinDao;
            _dtoFactory = dtoFactory;
        }

        private List<IDto> CreateDtoList(List<IEntity> entities)
        {
            return entities.Select(entity => _dtoFactory.GiveDtoOf(entity)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<PersonDto> GetAllPersons()
        {
            return CreateDtoList(_personDao.GetAllPersons(_connectionString)).ConvertAll(dto => (PersonDto) dto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<SinDto> GetAllSins()
        {
            return CreateDtoList(_sinDao.GetAllSins(_connectionString)).ConvertAll(dto => (SinDto)dto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sin"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void AddSin(SinDto sin)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void AddPerson(PersonDto person)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sin"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void RemoveSin(SinDto sin)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void RemovePerson(PersonDto person)
        {
            throw new NotImplementedException();
        }
    }
}
