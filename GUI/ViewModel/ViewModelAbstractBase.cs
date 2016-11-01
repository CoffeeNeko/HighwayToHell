using System;
using GalaSoft.MvvmLight;
using HighwayToHell.GUI.Interface;
using HighwayToHell.GUI.Model;

namespace HighwayToHell.GUI.ViewModel
{
    public abstract class ViewModelAbstractBase : ViewModelBase, IViewModel
    {
        //ToDo private readonly DtoMapperFactory _dtoMapperFactory;
        public ViewModelData Data { get; private set; }
        //ToDo IRepository
        protected ViewModelAbstractBase()
        {
            Data = new ViewModelData();
            //ToDo _dtoMapperFactory = new DtoMapperFactory();
        }

        public override void Cleanup()
        {
            // Clean up if needed
            Console.WriteLine("Clean");
           base.Cleanup();
        }
    }
}
