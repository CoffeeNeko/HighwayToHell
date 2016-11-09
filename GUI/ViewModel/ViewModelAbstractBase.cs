using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight;
using HighwayToHell.GUI.Interface;
using HighwayToHell.GUI.Model;
using HighwayToHell.GUI.Service.Mapper;
using HighwayToHell.GUI.View;

namespace HighwayToHell.GUI.ViewModel
{
    public abstract class ViewModelAbstractBase : ViewModelBase, IViewModel
    {
        public static int Index { get; set; }
        protected static bool IsPopUpActivated;
        protected static SinView SinView;
        protected static PersonView PersonView;
        private readonly DtoMapperFactory _dtoMapperFactory;
        public static ViewModelData Data { get; private set; }
        protected List<string> UpdateElements;
        protected ViewModelAbstractBase()
        {
            if (Data == null)
            {
                Data = new ViewModelData();
                for (var i = 0; i < 101; i++)
                {
                    Data.Persons.Add(CreatePerson(i));
                }
            }
            _dtoMapperFactory = new DtoMapperFactory();
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
    }
}
