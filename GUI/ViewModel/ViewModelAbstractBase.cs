using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight;
using HighwayToHell.GUI.Interface;
using HighwayToHell.GUI.Model;
using HighwayToHell.GUI.Service.Mapper;
using HighwayToHell.GUI.View;
using HighwayToHell.Repository.Interface;
using GeneralSqlRepository;
using HighwayToHell.Repository.Dto;

namespace HighwayToHell.GUI.ViewModel
{
    public abstract class ViewModelAbstractBase : ViewModelBase, IViewModel
    {
        public static int Index { get; set; }
        protected static bool IsPopUpActivated;
        protected static SinView SinView;
        protected static PersonView PersonView;
        protected readonly DtoMapperFactory _dtoMapperFactory;
        protected readonly IRepository _repository;
        public static ViewModelData Data { get; private set; }
        protected List<string> UpdateElements;
        protected ViewModelAbstractBase()
        {
            _repository = InitGeneralRepo.Init();
            _dtoMapperFactory = new DtoMapperFactory();

            Data = new ViewModelData();
            foreach (var person in _repository.GetAllPersons())
            {
                Data.Persons.Add((PersonData) _dtoMapperFactory.GiveDataOf(person));
            }

            /*------------Testdaten ab hier-------------------*/
            //if (Data == null)
            //{
            //    Data = new ViewModelData();
            //    for (var i = 0; i < 101; i++)
            //    {
            //        Data.Persons.Add(CreatePerson(i));
            //    }
            //}
            
            UpdateElements = new List<string>();
        }

        private static PersonData CreatePerson(int index)
        {
            var person = new PersonData("name:" + index, "surname:" + index);
            for (var i = 0; i < index; i++)
            {
                person.Sins.Add(new SinData("SündenText" + i, "Sünde" + i));
            }
            return person;
        }

        protected void Update()
        {          

            if (UpdateElements == null)
            {
                return;
            }
            foreach (var element in UpdateElements.Where(element => element != null))
            {
                // ReSharper disable once ExplicitCallerInfoArgument
                RaisePropertyChanged(element);
            }
        }

        protected void SavePersonsToDB()
        {
            foreach (var person in Data.Persons)
            {
                if (person.dto == null)
                {
                    person.dto = new PersonDto()
                    {
                        Name = person.Name,
                        Surname = person.Surname,
                        Id = 0
                    };
                }
                _repository.AddOrUpdatePerson((PersonDto)person.dto);
            }
        }
    }
}
