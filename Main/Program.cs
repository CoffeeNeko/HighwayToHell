using System;
using GeneralSqlRepository.Dao;
using GeneralSqlRepository.Factory;
using GeneralSqlRepository.Repository;
using HighwayToHell.Repository.Dto;
using HighwayToHell.Repository.Factory;

namespace HighwayToHell.Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DtoFactory faco = new DtoFactory();
            EntityFactory eFaco = new EntityFactory();
            eFaco.RegisterFactory(new GeneralSqlPersonEntityFactory());
            eFaco.RegisterFactory(new GeneralSqlSinEntityFactory());
            faco.RegisterFactory(new GeneralSqlPersonDtoFactory());
            faco.RegisterFactory(new GeneralSqlSinDtoFactory());
            GeneralSqlRepositoryBase repo = new GeneralSqlRepositoryBase(new GeneralSqlSinDao(), new GeneralSqlPersonDao(), new GeneralSqlPersonAndSinDao(), faco, eFaco);

            repo.AddOrUpdatePerson(new PersonDto()
            {
                Id = 0,
                Name = "TestPerson",
                Surname = "nachtest"
            });

            repo.AddOrUpdatePerson(new PersonDto()
            {
                Id = 0,
                Name = "uiououioui",
                Surname = "ererterte"
            });

            foreach (var test in repo.GetAllPersons())
            {
                Console.WriteLine(test.Id + " "+test.Name);
                //foreach (var sin in test.Sins)
                //{
                //    Console.WriteLine(sin.Description);
                //}
            }
            Console.Read();
        }
    }
}
