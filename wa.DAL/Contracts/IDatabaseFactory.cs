using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace wa.DAL.Contracts
{
    public interface IDatabaseFactory : IDisposable
    {
        sysengEntities Get();
    }
}
