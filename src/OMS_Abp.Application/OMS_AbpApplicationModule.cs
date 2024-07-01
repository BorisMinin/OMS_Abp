using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.Uow;

namespace OMS_Abp;

[DependsOn(
    typeof(OMS_AbpDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(OMS_AbpApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
public class OMS_AbpApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<OMS_AbpApplicationModule>();
        });

        // todo: I had this error:
        // SQLite Error 5: 'database is locked'. Microsoft.Data.Sqlite.SqliteException(0x80004005): SQLite Error 5: 'database is locked'.
        // here is temp solution to resolve this error by this link:
        // https://support.abp.io/QA/Questions/4278/Create-new-tenant-will-result-in-deadlocks#answer-ea309e6a-0e4b-ca3e-527a-3a088e19ae93
        Configure<AbpUnitOfWorkDefaultOptions>(options =>
        {
            options.TransactionBehavior = UnitOfWorkTransactionBehavior.Disabled;
        });
    }
}