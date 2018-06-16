using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISCS.Data.Entities
{
    public class Equipment : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Area Area { get; set; }

        [ForeignKey("Area")]
        public long AreaId { get; set; }

        public ICollection<TechCardEquipment> TechCardEquipments { get; set; }

        public ICollection<EquipmentOperation> EquipmentOperations { get; set; }
    }
}
