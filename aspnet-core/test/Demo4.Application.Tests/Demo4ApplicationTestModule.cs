using Volo.Abp.Modularity;

namespace Demo4
{
    [DependsOn(
        typeof(Demo4ApplicationModule),
        typeof(Demo4DomainTestModule)
        )]
    public class Demo4ApplicationTestModule : AbpModule
    {

    }
}