using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Demo4.Data
{
    /* This is used if database provider does't define
     * IDemo4DbSchemaMigrator implementation.
     */
    public class NullDemo4DbSchemaMigrator : IDemo4DbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}