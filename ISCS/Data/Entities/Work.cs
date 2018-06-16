using System.Collections.Generic;

namespace ISCS.Data.Entities
{
    public class Work : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<AreaWork> AreaWorks { get; set; }

        public ICollection<TechCard> TechCards { get; set; }
    }
}
