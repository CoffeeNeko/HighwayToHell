using HighwayToHell.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralSqlRepository.Dao;
using GeneralSqlRepository.Entity;
using GeneralSqlRepository.Interface;
using HighwayToHell.Repository.Dto;
using System.Data.SqlClient;

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
        private readonly IEntityFactory _entityFactory;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sinDao"></param>
        /// <param name="personDao"></param>
        /// <param name="dtoFactory"></param>
        /// <param name="personAndSinDao"></param>
        public GeneralSqlRepositoryBase(GeneralSqlSinDao sinDao, GeneralSqlPersonDao personDao, GeneralSqlPersonAndSinDao personAndSinDao,
            IDtoFactory dtoFactory, IEntityFactory entityFactory)
        {
            _sinDao = sinDao;
            _personDao = personDao;
            _personAndSinDao = personAndSinDao;
            _dtoFactory = dtoFactory;
            _entityFactory = entityFactory;

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
            var personEntities = _personDao.GetAllPersons(_connectionString);
            
            GiveSinsToPersons(personEntities);

            return CreatePersonDtoList(personEntities).ConvertAll(dto => (PersonDto)dto);
        }


        private void GiveSinsToPersons(List<IEntity> persons)
        {
            List<int> sinIds = new List<int>();

            foreach (var person in persons.Cast<GeneralSqlPersonEntity>())
            {
                sinIds = (_personAndSinDao.FindSinIdsOf(person, _connectionString));

                person.Sins = FindSinsForPersons(sinIds);
            }
        }

        private List<IEntity> FindSinsForPersons(List<int> sinIds)
        {
            return sinIds.Select(id => _sinDao.GetSinById(id, _connectionString)).ToList();
        }

        private List<IDto> CreatePersonDtoList(List<IEntity> personEntities)
        {
            var returnDtos = new List<IDto>();
            foreach (var entity in personEntities)
            {
                var personEntity = (GeneralSqlPersonEntity) entity;

                var sinDtos = personEntity.Sins.Select(sin => _dtoFactory.GiveDtoOf(sin)).ToList();
                var personDto = (PersonDto)_dtoFactory.GiveDtoOf(personEntity);

                personDto.Sins = sinDtos.ConvertAll(sin => (SinDto)sin);
                returnDtos.Add(personDto);
            }
            return returnDtos;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<SinDto> GetAllSins()
        {
            var sinEntities = _sinDao.GetAllSins(_connectionString);

            return CreateDtoList(sinEntities).ConvertAll(dto => (SinDto)dto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sin"></param>
        /// <returns></returns>
        public List<PersonDto> GetAllPersonsOfSin(SinDto sin)
        {
            var personIds = _personAndSinDao.FindPersonIdsFor(_entityFactory.GiveEntityOf(sin) as GeneralSqlSinEntity, _connectionString);
            var personEntities = personIds.Select(id => _personDao.GetPersonById(id, _connectionString)).ToList();

            return CreatePersonDtoList(personEntities).ConvertAll(dto => (PersonDto)dto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sin"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void AddOrUpdateSin(SinDto sin)
        {
            _sinDao.InsertSin(_entityFactory.GiveEntityOf(sin) as GeneralSqlSinEntity, _connectionString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void AddOrUpdatePerson(PersonDto person)
        {
            var personEntity = _entityFactory.GiveEntityOf(person) as GeneralSqlPersonEntity;
            _personDao.InsertPerson(personEntity, _connectionString);

            UpdatePersonSin(person);
        }

        private void UpdatePersonSin(PersonDto personDto)
        {
            var personEntity = _entityFactory.GiveEntityOf(personDto) as GeneralSqlPersonEntity;
            _personAndSinDao.RemoveByPerson(personEntity, _connectionString);
            foreach (var sinDto in personDto.Sins)
            {
                var sinEntity = _entityFactory.GiveEntityOf(sinDto);
                if (((GeneralSqlSinEntity)sinEntity).Id == 0)
                {
                    _sinDao.InsertSin((GeneralSqlSinEntity) sinEntity, _connectionString);
                }
                _personAndSinDao.AddPersonSin(personEntity, sinEntity as GeneralSqlSinEntity, _connectionString);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sin"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void RemoveSin(SinDto sin)
        {
            GeneralSqlSinEntity entity = _entityFactory.GiveEntityOf(sin) as GeneralSqlSinEntity;
            _sinDao.RemoveSin(entity, _connectionString);
            _personAndSinDao.RemoveBySin(entity, _connectionString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void RemovePerson(PersonDto person)
        {
            GeneralSqlPersonEntity entity = _entityFactory.GiveEntityOf(person) as GeneralSqlPersonEntity;
            _personDao.RemovePerson(entity, _connectionString);
            _personAndSinDao.RemoveByPerson(entity, _connectionString);
        }
    }
}
