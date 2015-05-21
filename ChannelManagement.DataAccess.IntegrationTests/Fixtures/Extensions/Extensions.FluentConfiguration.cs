using FluentNHibernate.Cfg;

namespace ChannelManagement.DataAccess.IntegrationTests.Fixtures.Extensions
{
    public static class FluentConfigurationExtensions
    {
        public static FluentConfiguration RemoveCatalogAndSchemaFromMappings(this FluentConfiguration value)
        {
            value.ExposeConfiguration(c =>
            {
                foreach (var persistentClass in c.ClassMappings)
                {
                    persistentClass.Table.Name = string.Format("{0}{1}{2}", persistentClass.Table.Catalog, persistentClass.Table.Schema, persistentClass.Table.Name.Replace(string.Format("[{0}].", persistentClass.Table.Schema), string.Empty));
                    persistentClass.Table.Catalog = null;
                    persistentClass.Table.Schema = null;
                }
            });

            return value;
        }
    }
}
