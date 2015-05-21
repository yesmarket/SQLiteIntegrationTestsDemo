using System.Collections.Generic;
using ChannelManagement.DataAccess.Contracts.Model;
using ChannelManagement.DataAccess.Contracts.Types;

namespace ChannelManagement.DataAccess.Contracts.Repository
{
    public interface IRecipientRepository : IRepository<Recipient>
    {
        IEnumerable<Recipient> GetRecipientsByStatus(Status status);
    }
}