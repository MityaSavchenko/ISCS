using System.ComponentModel.DataAnnotations.Schema;

namespace ISCS.Data.Entities
{
    public class AreaWork
    {

        public Area Area { get; set; }

        [ForeignKey("Area")]
        public long AreaId { get; set; }

        public Work Work { get; set; }

        [ForeignKey("Work")]
        public long WorkId { get; set; }
    }
}
