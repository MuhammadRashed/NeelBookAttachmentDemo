using Demo4.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Demo4
{
    [DependsOn(
        typeof(Demo4EntityFrameworkCoreTestModule)
        )]
    public class Demo4DomainTestModule : AbpModule
    {

    }
}