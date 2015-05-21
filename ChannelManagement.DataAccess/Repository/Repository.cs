using ChannelManagement.DataAccess.Contracts.Repository;
using NHibernate;

namespace ChannelManagement.DataAccess.Repository
{
    public class Repository<TEntity> : IRepository<TEntity>
    {
        protected readonly ISessionFactory SessionFactory;

        public Repository(ISessionFactory sessionFactory)
        {
            SessionFactory = sessionFactory;
        }

        public void Save(TEntity entity)
        {
            using (var session = SessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(entity);
                    transaction.Commit();
                }
            }
        }
    }
}