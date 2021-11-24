using Demo4.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Demo4.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(Demo4EntityFrameworkCoreModule),
        typeof(Demo4ApplicationContractsModule)
    )]
    public class Demo4DbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options =>
            {
                options.IsJobExecutionEnabled = false;
            });
        }
    }
}
