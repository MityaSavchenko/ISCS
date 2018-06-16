using System.ComponentModel.DataAnnotations.Schema;

namespace ISCS.Data.Entities
{
    public class TechCardEquipment
    {
        public virtual TechCard TechCard { get; set; }

        [ForeignKey("TechCard")]
        public long TechCardId { get; set; }

        public virtual Equipment Equipment { get; set; }

        [ForeignKey("Equipment")]
        public long EquipmentId { get; set; }
    }
}
