using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ISCS.Data.Entities;
using Newtonsoft.Json;

namespace ISCS.ViewModels
{
    public class TechCardViewModel
    {
        public long Id { get; set; }

        public string DisplayName => Id.ToString("00000000");

        public WorkViewModel Work { get; set; }

        [Required]
        public long WorkId
        {
            get
            {
                if (Work == null)
                {
                    Work = new WorkViewModel();
                }

                return Work.Id;
            }
            set
            {
                if (Work == null)
                {
                    Work = new WorkViewModel();
                }
                Work.Id = value;
            }
        }

        public AreaViewModel Area => SelectedEquipment?.FirstOrDefault()?.Area;

        public long? AreaId => Area?.Id;

        [Required]
        public int? PeopleNumber { get; set; }

        public string Description { get; set; }

        public IList<EquipmentViewModel> SelectedEquipment { get; set; }

        public IEnumerable<long> SelectedEquipmentIds { get; set; }

        public DateTime CreationDate { get; set; }

        public bool IsActual { get; set; }

        public IEnumerable<OperationDisplayViewModel> Operations { get; set; }

        public string SelectedEquipmentIdsJson
        {
            get => JsonConvert.SerializeObject(SelectedEquipmentIds);
            set => SelectedEquipmentIds = JsonConvert.DeserializeObject<IEnumerable<long>>(value);
        }

        public string Comment { get; set; }

        public IEnumerable<HazardViewModel> AvailableHazards { get; set; }

        public TechCardStates TechCardState { get; set; }

        public IEnumerable<HazardControlViewModel> HazardControls { get; set; }

        #region Available Collections

        public IList<WorkViewModel> AvailableWorks { get; set; }

        public IList<AreaViewModel> AvailableAreas { get; set; }

        public IList<EquipmentViewModel> AvailableEquipment { get; set; }

        #endregion
    }
}
