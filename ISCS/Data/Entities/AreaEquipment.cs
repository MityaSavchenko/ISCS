using System.ComponentModel.DataAnnotations.Schema;

namespace ISCS.Data.Entities
{
    public class AreaEquipment
    {
        public Area Area { get; set; }

        [ForeignKey("Area")]
        public virtual long AreaId { get; set; }

        public Equipment Equipment { get; set; }

        [ForeignKey("Equipment")]
        public virtual long EquipmentId { get; set; }
    }
}
