using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISCS.Data.Entities
{
    public class EquipmentOperation : BaseEntity
    {
        public virtual Equipment Equipment { get; set; }

        [ForeignKey("Equipment")]
        public long EquipmentId { get; set; }

        public virtual Operation Operation { get; set; }

        [ForeignKey("Operation")]
        public long OperationId { get; set; }
    }
}
