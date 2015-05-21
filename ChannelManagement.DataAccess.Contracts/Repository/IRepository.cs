namespace ChannelManagement.DataAccess.Contracts.Repository
{
    public interface IRepository<in TEntity>
    {
        void Save(TEntity entity);
    }
}
