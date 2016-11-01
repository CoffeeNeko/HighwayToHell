namespace HighwayToHell.Repository.Interface
{
    public interface IEfEntityToDtoMapper
    {
        IDto MapEfEntityToDto(IEntity entity);
    }
}