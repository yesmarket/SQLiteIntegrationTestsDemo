namespace ChannelManagement.DataAccess.Contracts.Types
{
	public enum Status
	{
        Pending = 1,
        Queued = 2,
        Sending = 3,
        Sent = 4,
		Acknowledged = 5,
		Failed = 6,
		Unknown = 7
	}
}