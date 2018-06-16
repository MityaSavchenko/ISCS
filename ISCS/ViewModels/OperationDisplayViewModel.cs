namespace ISCS.ViewModels
{
    public class OperationDisplayViewModel
    {
        public long Id => EquipmentOperation.Id;

        public EquipmentOperationViewModel EquipmentOperation { get; set; }

        public string OperationName => EquipmentOperation?.Operation?.Name;

        public string OperationDescription => EquipmentOperation?.Operation?.Description;

        public string EquipmentName => EquipmentOperation.Equipment.Name;

        public long EquipmentId => EquipmentOperation.Equipment.Id;

        public long OperationId => EquipmentOperation.Operation.Id;

        public long OrderId { get; set; }
    }
}
