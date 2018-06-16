using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISCS.Data.Entities
{
    public class TechCard : BaseEntity
    {
        public Work Work { get; set; }

        [ForeignKey("Work")]
        public long WorkId { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public bool IsActual { get; set; }

        public int PeopleNumber { get; set; }

        public string Comment { get; set; }

        public TechCardStates TechCardState { get; set; }

        public ICollection<TechCardOperation> TechCardOperations { get; set; }

        public ICollection<TechCardEquipment> TechCardEquipments { get; set; }

        public ICollection<TechCardHazardControl> TechCardHazardControls { get; set; }
    }
}
