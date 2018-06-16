using System;
using ISCS.Interfaces;
using ISCS.ViewModels;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ISCS.Data.Entities;
using ISCS.Data.Infrastucture.Interfaces;
using Kendo.Mvc.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ISCS.Services
{
    public class TechCardService : ITechCardService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TechCardService(
            IUnitOfWork unitOfWork
        )
        {
            this._unitOfWork = unitOfWork;
        }

        public TechCardViewModel InitializeCreateViewModel()
        {
            return new TechCardViewModel()
            {
                AvailableWorks = _unitOfWork.WorkRepository.Get().Select(Mapper.Map<WorkViewModel>).ToList()
            };
        }

        public TechCardViewModel GetTechCardById(long id)
        {
            var techCard = _unitOfWork.TechCardRepository
                                .GetWithInclude(
                                    x => x.Id == id,
                                    x => x.TechCardEquipments,
                                    x => x.Work,
                                    x => x.TechCardOperations)
                                .FirstOrDefault();
            var result = Mapper.Map<TechCardViewModel>(techCard);
            var eq = techCard.TechCardEquipments.Select(y => y.EquipmentId);
            result.SelectedEquipment = _unitOfWork.EquipmentRepository
                .GetWithInclude(
                    x => eq.Contains(x.Id),
                    x => x.Area)
                .Select(Mapper.Map<EquipmentViewModel>).ToList();
            result.Operations = Mapper.Map<IEnumerable<OperationDisplayViewModel>>(
                    _unitOfWork.TechCardOperationRepository.GetWithInclude(
                        x => x.TechCardId == id,
                        x => x.EquipmentOperation,
                        x => x.EquipmentOperation.Operation)
                    ).OrderBy(x => x.OrderId);
            result.HazardControls =
                _unitOfWork.TechCardHazardControlRepository.GetWithInclude(
                    x => x.TechCardId == id,
                    x => x.HazardControl,
                    x => x.HazardControl.Hazard
                ).Select(Mapper.Map<HazardControlViewModel>);
            result.AvailableHazards = _unitOfWork.HazardRepository.Get().Select(Mapper.Map<HazardViewModel>);
            return result;
        }

        public TechCardViewModel CreateTechCard(TechCardViewModel viewModel)
        {
            var entity = Mapper.Map<TechCard>(viewModel);
            entity.Work = _unitOfWork.WorkRepository.FindById(viewModel.WorkId);


            var newTechCard = _unitOfWork.TechCardRepository.Create(entity);
            _unitOfWork.Commit();

            foreach (var selectedEquipmentId in viewModel.SelectedEquipmentIds)
            {
                _unitOfWork.TechCardEquipmentRepository.Create(new TechCardEquipment()
                {
                    TechCardId = newTechCard.Id,
                    EquipmentId = selectedEquipmentId
                });
            }
            _unitOfWork.Commit();

            return Mapper.Map<TechCardViewModel>(newTechCard) ?? new TechCardViewModel();
        }

        public IEnumerable<AreaViewModel> GetAvailableAreas() =>
            Mapper.Map<IEnumerable<AreaViewModel>>(_unitOfWork.AreaRepository.Get()) ?? Enumerable.Empty<AreaViewModel>();

        public IEnumerable<EquipmentViewModel> GetEquipmentByArea(long areaId) =>
            _unitOfWork.EquipmentRepository.Get(x => x.AreaId == areaId).Select(Mapper.Map<EquipmentViewModel>);

        public IEnumerable<WorkViewModel> GetAllWorks()
        {
            return _unitOfWork.WorkRepository.Get().Select(Mapper.Map<WorkViewModel>);
        }

        public IEnumerable<AreaViewModel> GetAreasByWork(long workId)
        {
            return _unitOfWork.AreaWorkRepository.GetWithInclude(x => x.WorkId == workId, x => x.Area)
                .Select(x => Mapper.Map<AreaViewModel>(x.Area));
        }

        public IEnumerable<WorkViewModel> GetWorksByArea(long areaId)
        {
            return _unitOfWork.AreaWorkRepository.GetWithInclude(x => x.AreaId == areaId, x => x.Work)
                .Select(x => Mapper.Map<WorkViewModel>(x.Work));
        }

        public IEnumerable<TechCardViewModel> FindTechCards(
            long? workId,
            long? areaId,
            string state,
            string fromDate,
            string toDate,
            string description)
        {
            DateTime from = DateTime.Today, to = DateTime.Today;
            TechCardStates stateEl = TechCardStates.All;

            if (fromDate != null)
            {
                from = DateTime.Parse(fromDate);
            }

            if (toDate != null)
            {
                to = DateTime.Parse(toDate);
            }

            if (state != null)
            {
                stateEl = Enum.Parse<TechCardStates>(state);
            }

            var techCards = _unitOfWork.TechCardRepository.GetWithInclude(
                x => (x.WorkId == workId || workId == null)
                     && (x.CreationDate >= from || fromDate == null)
                     && (x.CreationDate <= to || toDate == null)
                     && (x.TechCardState == stateEl || stateEl == TechCardStates.All)
                     && (x.Description.IndexOf(description ?? string.Empty, StringComparison.OrdinalIgnoreCase) >= 0 || description == null),
                x => x.Work,
                x => x.TechCardEquipments);
            var techCardViewModels = Mapper.Map<IEnumerable<TechCardViewModel>>(techCards);
            techCardViewModels.Each(x =>
            {
                var eIds = _unitOfWork.TechCardEquipmentRepository.Get(y => y.TechCardId == x.Id)
                    .Select(y => y.EquipmentId);
                x.SelectedEquipment = _unitOfWork.EquipmentRepository
                    .GetWithInclude(y => eIds.Contains(y.Id), y => y.Area)
                    .Select(Mapper.Map<EquipmentViewModel>)
                    .ToList();
            });

            return techCardViewModels.Where(x => x.AreaId == areaId || areaId == null);
        }

        public void SetTechCardActuality(long techCardId, bool value)
        {
            var techCard = _unitOfWork.TechCardRepository.FindById(techCardId);
            techCard.IsActual = value;
            _unitOfWork.Commit();
        }

        public IEnumerable<OperationViewModel> GetOperationsByEquipment(long equipmentId)
        {
            var equipmentOperations = _unitOfWork.EquipmentOperationRepository
                .GetWithInclude(x => x.EquipmentId == equipmentId, x => x.Operation);
            var res = Mapper.Map<IEnumerable<OperationViewModel>>(equipmentOperations);
            return res;
        }

        public void SaveTechCardOperations(long techCardId, IEnumerable<OperationViewModel> operations)
        {
            var newOperationIds = operations.Select(x => x.EquipmentOperationId);
            var techCardOperations = _unitOfWork.TechCardOperationRepository.Get(x => x.TechCardId == techCardId);
            var oldOperationIds = techCardOperations.Select(x => x.EquipmentOperationId);
            var idsForAdding = newOperationIds.Except(oldOperationIds);
            var idsForRemoving = oldOperationIds.Except(newOperationIds);

            foreach (var id in idsForRemoving)
            {
                _unitOfWork.TechCardOperationRepository.Remove(x =>
                    x.TechCardId == techCardId && x.EquipmentOperationId == id);
            }

            var maxOrderId = techCardOperations.Any() ? techCardOperations.Max(x => x.OrderId) : 0;
            foreach (var id in idsForAdding)
            {
                _unitOfWork.TechCardOperationRepository.Create(new TechCardOperation()
                {
                    TechCardId = techCardId,
                    EquipmentOperationId = id,
                    OrderId = ++maxOrderId
                });
            }

            var techCard = _unitOfWork.TechCardRepository.FindById(techCardId);
            techCard.TechCardState = TechCardStates.OperationsAdded;
            _unitOfWork.Commit();
        }

        public void SaveRiskAssessment(long techCardId, IEnumerable<HazardControlViewModel> controls)
        {
            var newControlIds = controls.Select(x => x.Id);
            var techCardControls = _unitOfWork.TechCardHazardControlRepository.Get(x => x.TechCardId == techCardId);
            var oldOperationIds = techCardControls.Select(x => x.HazardControlId);
            var idsForAdding = newControlIds.Except(oldOperationIds);
            var idsForRemoving = oldOperationIds.Except(newControlIds);

            foreach (var id in idsForRemoving)
            {
                _unitOfWork.TechCardHazardControlRepository.Remove(x =>
                    x.TechCardId == techCardId && x.HazardControlId == id);
            }
            

            foreach (var id in idsForAdding)
            {
                _unitOfWork.TechCardHazardControlRepository.Create(new TechCardHazardControl()
                {
                    TechCardId = techCardId,
                    HazardControlId = id
                });
            }

            var techCard = _unitOfWork.TechCardRepository.FindById(techCardId);
            techCard.TechCardState = TechCardStates.RaCompleted;
            _unitOfWork.Commit();
        }

        public void ReorderOperations(long techCardId, IEnumerable<ReorderOperationViewModel> operations)
        {
            var list = _unitOfWork.TechCardOperationRepository.GetAsTracking(x => x.TechCardId == techCardId);
            foreach (var techCardOperation in list)
            {
                techCardOperation.OrderId =
                    operations.FirstOrDefault(x => x.Id == techCardOperation.EquipmentOperationId).OrderId;
            }

            var techCard = _unitOfWork.TechCardRepository.FindById(techCardId);
            techCard.TechCardState = TechCardStates.OperationsConfigured;
            _unitOfWork.Commit();
        }

        public void ChangeStatusToNeedRa(long techCardId, string comment)
        {
            var techCard = _unitOfWork.TechCardRepository.FindById(techCardId);
            techCard.TechCardState = TechCardStates.NeedRa;
            techCard.Comment = comment;
        }

        public IEnumerable<HazardControlViewModel> GetHazardConstrolsByHazard(long hazardId)
        {
            var res = _unitOfWork.HazardControlRepository
                .GetWithInclude(
                    x => x.HazardId == hazardId,
                    x => x.Hazard)
                .Select(Mapper.Map<HazardControlViewModel>);
            return res;
        }

        public void AcceptTechCard(long techCardId)
        {
            var techCard = _unitOfWork.TechCardRepository.FindById(techCardId);
            techCard.TechCardState = TechCardStates.Accepted;
            _unitOfWork.Commit();
        }
    }
}