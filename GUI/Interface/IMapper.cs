using HighwayToHell.Repository.Interface;

namespace HighwayToHell.GUI.Interface
{
    public interface IMapper
    {
        IData MapDataFrom(IDto dto);
    }
}