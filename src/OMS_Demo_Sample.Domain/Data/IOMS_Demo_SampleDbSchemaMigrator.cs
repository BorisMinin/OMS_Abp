using System.Threading.Tasks;

namespace OMS_Demo_Sample.Data;

public interface IOMS_Demo_SampleDbSchemaMigrator
{
    Task MigrateAsync();
}
