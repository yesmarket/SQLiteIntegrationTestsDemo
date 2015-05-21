using System;
using ChannelManagement.DataAccess.Contracts.Types;

namespace ChannelManagement.DataAccess.Contracts.Model
{
    public class Recipient : BaseEntity<Guid>
    {
        public virtual string Token { get; set; }
        public virtual Status Status { get; set; }
        public virtual DateTime? DateSent { get; set; }
    }
}