using Model;
using wa.DAL.Contracts;
using wa.DAL.Implementations;

namespace wa.Repository
{
    class LeadRepository : Repository<Lead>, ILeadRepository
    {
        private sysengEntities dataContext;

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        public LeadRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }

        protected sysengEntities DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }
    }

    public interface ILeadRepository : IRepository<Lead>
    { }
}
