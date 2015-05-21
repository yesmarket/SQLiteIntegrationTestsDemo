using System;
using System.Reflection;
using ChannelManagement.DataAccess.IntegrationTests.Fixtures.Extensions;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;

namespace ChannelManagement.DataAccess.IntegrationTests.Fixtures
{
    public class NHibernateFixture : IDisposable
    {
        public ISession Session { get; set; }

        public void ConfigureOrm()
        {
            Configuration configuration = null;

            var sessionFactory =
                Fluently.Configure()
                    .Database(SQLiteConfiguration.Standard.InMemory().ShowSql().Dialect<SQLiteDialect>())
                    .Mappings(m => m.HbmMappings.AddFromAssembly(Assembly.Load("ChannelManagement.DataAccess")))
                    .RemoveCatalogAndSchemaFromMappings()
                    .ExposeConfiguration(c =>
                    {
                        configuration = c;
                        c.DataBaseIntegration(db => db.LogFormattedSql = true);
                    })
                    .BuildSessionFactory();

            Session = sessionFactory.OpenSession();

            new SchemaExport(configuration).Execute(true, true, false, Session.Connection, null);
        }

        public void Dispose()
        {
            if (Session != null)
            {
                Session.Dispose();
            }
        }
    }
}