using System.Threading.Tasks;

namespace OMS_Abp.Data;

public interface IOMS_AbpDbSchemaMigrator
{
    Task MigrateAsync();
}
