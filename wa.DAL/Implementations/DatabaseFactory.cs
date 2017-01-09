using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using wa.DAL.Contracts;

namespace wa.DAL.Implementations
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private sysengEntities dataContext;
        public sysengEntities Get()
        {
            return dataContext ?? (dataContext = new sysengEntities());
        }

        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
