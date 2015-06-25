using System.Linq;
using ChannelManagement.DataAccess.Contracts.Model;
using ChannelManagement.DataAccess.Contracts.Types;
using ChannelManagement.DataAccess.IntegrationTests.Fixtures;
using ChannelManagement.DataAccess.Repository;
using NHibernate;
using NSubstitute;
using Ploeh.AutoFixture;
using SharpTestsEx;
using Xunit;

namespace ChannelManagement.DataAccess.IntegrationTests.Repository
{
    public class RecipientRepositoryIntegraionTests : IUseFixture<NHibernateFixture>
    {
        #region Boring stuff
        private readonly ISessionFactory _sessionFactory;
        private readonly RecipientRepository _sut;
        private ISession _session;

        public void SetFixture(NHibernateFixture data)
        {
            data.ConfigureOrm();
            _session = data.Session;
            _sessionFactory.OpenSession().Returns(_session);
        }

        public RecipientRepositoryIntegraionTests()
        {
            _sessionFactory = Substitute.For<ISessionFactory>();
            _sut = new RecipientRepository(_sessionFactory);
        } 
        #endregion

        [Fact]
        public void GetRecipientsByStatus_MatchingSubset_ReturnsCorrectNumberOfResults()
        {
            var fixture = new Fixture();
            _session.Save(fixture.Build<Recipient>().With(recipient => recipient.Status, Status.Pending).Create());
            _session.Save(fixture.Build<Recipient>().With(recipient => recipient.Status, Status.Sent).Create());
            _session.Flush();
            var recipients = _sut.GetRecipientsByStatus(Status.Sent);
            recipients.Count().Should().Be.EqualTo(1);
        }

        [Fact]
        public void GetRecipientsByStatus_NoMatchingRecords_ReturnsCorrectNumberOfResults()
        {
            var fixture = new Fixture();
            _session.Save(fixture.Build<Recipient>().With(recipient => recipient.Status, Status.Pending).Create());
            _session.Flush();
            var recipients = _sut.GetRecipientsByStatus(Status.Sent);
            recipients.Count().Should().Be.EqualTo(0);
        }
    }
}
