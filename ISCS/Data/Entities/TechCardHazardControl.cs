using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ISCS.Data.Entities
{
    public class TechCardHazardControl : BaseEntity
    {
        public TechCard TechCard { get; set; }

        [ForeignKey("TechCard")]
        public long TechCardId { get; set; }

        public HazardControl HazardControl { get; set; }

        [ForeignKey("HazardControl")]
        public long HazardControlId { get; set; }
    }
}
