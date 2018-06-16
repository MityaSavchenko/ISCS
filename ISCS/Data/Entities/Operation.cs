using System.Collections.Generic;

namespace ISCS.Data.Entities
{
    public class Operation : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<EquipmentOperation> EquipmentOperations { get; set; }
    }
}
