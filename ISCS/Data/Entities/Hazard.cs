using System.Collections.Generic;

namespace ISCS.Data.Entities
{
    public class Hazard : BaseEntity
    {
        public string Name { get; set; }

        public HazardLevel HazardLevel { get; set; }

        public ICollection<HazardControl> HazardControls { get; set; }
    }
}
