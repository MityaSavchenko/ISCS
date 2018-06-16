using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ISCS.Data.Entities
{
    public class TechCardOperation
    {
        public TechCard TechCard { get; set; }

        [ForeignKey("TechCard")]
        public long TechCardId { get; set; }

        public EquipmentOperation EquipmentOperation { get; set; }

        [ForeignKey("EquipmentOperation")]
        public long EquipmentOperationId { get; set; }

        public long OrderId { get; set; }
    }
}
