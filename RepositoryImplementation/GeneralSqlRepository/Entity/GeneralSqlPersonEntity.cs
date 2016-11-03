using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HighwayToHell.Repository.Interface;

namespace GeneralSqlRepository.Entity
{
    public class GeneralSqlPersonEntity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<IEntity> Sins { get; set; }

        public GeneralSqlPersonEntity()
        {
            Sins = new List<IEntity>();
        }
    }
}
