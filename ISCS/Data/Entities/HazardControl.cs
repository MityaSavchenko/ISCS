using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ISCS.Data.Entities
{
    public class HazardControl : BaseEntity
    {
        public string Name { get; set; }

        public Hazard Hazard { get; set; }

        [ForeignKey("Hazard")]
        public long HazardId { get; set; }

        public ICollection<TechCardHazardControl> TechCardHazardControls { get; set; }

    }
}
