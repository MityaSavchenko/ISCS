using System.Collections.Generic;

namespace ISCS.Data.Entities
{
    public class Area : BaseEntity
    {
        public string Name { get; set; }

        public string Coords { get; set; }

        public ICollection<Equipment> Equipments { get; set; }

        public ICollection<AreaWork> AreaWorks { get; set; }
    }
}
