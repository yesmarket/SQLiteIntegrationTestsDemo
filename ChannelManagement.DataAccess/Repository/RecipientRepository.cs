using System.Collections.Generic;
using System.Linq;
using ChannelManagement.DataAccess.Contracts.Model;
using ChannelManagement.DataAccess.Contracts.Repository;
using ChannelManagement.DataAccess.Contracts.Types;
using NHibernate;
using NHibernate.Linq;

namespace ChannelManagement.DataAccess.Repository
{
    public class RecipientRepository : Repository<Recipient>, IRecipientRepository
    {
        public RecipientRepository(ISessionFactory sessionFactory)
            : base(sessionFactory)
        {
        }

        public IEnumerable<Recipient> GetRecipientsByStatus(Status status)
        {
            List<Recipient> recipients;
            using (var session = SessionFactory.OpenSession())
            {
                recipients = session.Query<Recipient>().Where(recipient => recipient.Status == status).ToList();
            }
            return recipients;
        }
    }
}