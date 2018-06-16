using System;
using ISCS.Data.Entities;

namespace ISCS.Data.Infrastucture.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<Work> WorkRepository { get; }

        GenericRepository<TechCard> TechCardRepository { get; }

        GenericRepository<Equipment> EquipmentRepository { get; }

        GenericRepository<Area> AreaRepository { get; }

        GenericRepository<AreaWork> AreaWorkRepository { get; }

        GenericRepository<EquipmentOperation> EquipmentOperationRepository { get; }

        GenericRepository<Operation> OperationRepository { get; }

        GenericRepository<TechCardEquipment> TechCardEquipmentRepository { get; }

        GenericRepository<TechCardOperation> TechCardOperationRepository { get; }

        GenericRepository<Hazard> HazardRepository { get; }

        GenericRepository<HazardControl> HazardControlRepository { get; }

        GenericRepository<TechCardHazardControl> TechCardHazardControlRepository { get; }

        void Commit();
    }
}
