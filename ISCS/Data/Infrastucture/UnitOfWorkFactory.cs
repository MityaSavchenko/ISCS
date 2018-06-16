using ISCS.Data.Infrastucture.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ISCS.Data.Infrastucture
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly DbContext context;

        public UnitOfWorkFactory(DbContext context)
        {
            this.context = context;
        }

        public IUnitOfWork Create()
        {
            return new UnitOfWork(this.context);
        }
    }
}
