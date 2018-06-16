namespace ISCS.Data.Infrastucture.Interfaces
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
