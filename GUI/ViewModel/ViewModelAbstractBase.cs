using System;
using GalaSoft.MvvmLight;
using HighwayToHell.GUI.Interface;
using HighwayToHell.GUI.Model;
using HighwayToHell.GUI.Service.Mapper;

namespace HighwayToHell.GUI.ViewModel
{
    public abstract class ViewModelAbstractBase : ViewModelBase, IViewModel
    {
        private readonly DtoMapperFactory _dtoMapperFactory;
        public ViewModelData Data { get; private set; }
        protected ViewModelAbstractBase()
        {
            Data = new ViewModelData();
            _dtoMapperFactory = new DtoMapperFactory();
        }

        public override void Cleanup()
        {
            // Clean up if needed
            Console.WriteLine("Clean");
           base.Cleanup();
        }
    }
}
