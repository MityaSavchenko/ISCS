using System;
using ISCS.Data.Entities;
using ISCS.Data.Infrastucture.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ISCS.Data.Infrastucture
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;
        private GenericRepository<Work> workRepository;
        private GenericRepository<TechCard> techCardRepository;
        private GenericRepository<Equipment> equipmentRepository;
        private GenericRepository<Area> areaRepository;
        private GenericRepository<AreaWork> areaWorkRepository;
        private GenericRepository<EquipmentOperation> equipmentOperationRepository;
        private GenericRepository<Operation> operationRepository;
        private GenericRepository<TechCardEquipment> techCardEquipmentRepository;
        private GenericRepository<TechCardOperation> techCardOperationRepository;
        private GenericRepository<Hazard> hazardRepository;
        private GenericRepository<HazardControl> hazardControlRepository;
        private GenericRepository<TechCardHazardControl> techCardHazardControlRepository;

        public GenericRepository<Work> WorkRepository
        {
            get
            {
                if (this.workRepository == null)
                {
                    this.workRepository = new GenericRepository<Work>(this.context);
                }

                return workRepository;
            }
        }

        public GenericRepository<TechCard> TechCardRepository => techCardRepository =
            techCardRepository ?? new GenericRepository<TechCard>(this.context);

        public GenericRepository<Equipment> EquipmentRepository =>
            equipmentRepository = equipmentRepository ?? new GenericRepository<Equipment>(context);

        public GenericRepository<Area> AreaRepository =>
            areaRepository = areaRepository ?? new GenericRepository<Area>(context);

        public GenericRepository<AreaWork> AreaWorkRepository =>
            areaWorkRepository = areaWorkRepository ?? new GenericRepository<AreaWork>(context);

        public GenericRepository<EquipmentOperation> EquipmentOperationRepository => equipmentOperationRepository =
            equipmentOperationRepository ?? new GenericRepository<EquipmentOperation>(context);

        public GenericRepository<Operation> OperationRepository =>
            operationRepository = operationRepository ?? new GenericRepository<Operation>(context);

        public GenericRepository<TechCardEquipment> TechCardEquipmentRepository => techCardEquipmentRepository =
            techCardEquipmentRepository ?? new GenericRepository<TechCardEquipment>(context);

        public GenericRepository<TechCardOperation> TechCardOperationRepository => techCardOperationRepository =
            techCardOperationRepository ?? new GenericRepository<TechCardOperation>(context);

        public GenericRepository<Hazard> HazardRepository =>
            hazardRepository = hazardRepository ?? new GenericRepository<Hazard>(context);

        public GenericRepository<HazardControl> HazardControlRepository => hazardControlRepository =
            hazardControlRepository ?? new GenericRepository<HazardControl>(context);

        public GenericRepository<TechCardHazardControl> TechCardHazardControlRepository =>
            techCardHazardControlRepository = techCardHazardControlRepository ??
                                              new GenericRepository<TechCardHazardControl>(context);

        public UnitOfWork(
            DbContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            Commit();
        }
    }
}