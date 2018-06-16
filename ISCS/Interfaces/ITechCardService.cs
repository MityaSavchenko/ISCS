using ISCS.ViewModels;
using System.Collections.Generic;

namespace ISCS.Interfaces
{
    public interface ITechCardService
    {
        TechCardViewModel InitializeCreateViewModel();

        TechCardViewModel GetTechCardById(long id);

        TechCardViewModel CreateTechCard(TechCardViewModel viewModel);

        IEnumerable<AreaViewModel> GetAvailableAreas();

        IEnumerable<EquipmentViewModel> GetEquipmentByArea(long areaId);

        IEnumerable<WorkViewModel> GetAllWorks();

        IEnumerable<AreaViewModel> GetAreasByWork(long workId);

        IEnumerable<WorkViewModel> GetWorksByArea(long areaId);

        IEnumerable<TechCardViewModel> FindTechCards(
                long? workId,
                long? areaId,
                string state,
                string fromDate,
                string toDate,
                string description);

        void SetTechCardActuality(long techCardId, bool value);

        IEnumerable<OperationViewModel> GetOperationsByEquipment(long equipmentId);

        void SaveTechCardOperations(long techCardId, IEnumerable<OperationViewModel> operations);

        void SaveRiskAssessment(long techCardId, IEnumerable<HazardControlViewModel> controls);

        void ReorderOperations(long techCardId, IEnumerable<ReorderOperationViewModel> operations);

        void ChangeStatusToNeedRa(long techCardId, string comment);

        IEnumerable<HazardControlViewModel> GetHazardConstrolsByHazard(long hazardId);

        void AcceptTechCard(long techCardId);
    }
}
