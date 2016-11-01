using HighwayToHell.Repository.Dao;
using HighwayToHell.Repository.Interface;

namespace HighwayToHell.Repository.Service
{
    class EntityFrameWorkBase
    {
        public IEntityFrameWorkDao PersonDataAccess { get; private set; }
        public IEntityFrameWorkDao SinDataAccess { get; private set; }
        public EfMapperFactory EfMapperFactory { get; private set; }

        public EntityFrameWorkBase()
        {
            PersonDataAccess = new EfPersonDao();
            SinDataAccess = new EfSinDao();
            EfMapperFactory = new EfMapperFactory();
        }
    }
}
