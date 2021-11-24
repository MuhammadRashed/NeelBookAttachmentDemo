using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Demo4.Data;
using Volo.Abp.DependencyInjection;

namespace Demo4.EntityFrameworkCore
{
    public class EntityFrameworkCoreDemo4DbSchemaMigrator
        : IDemo4DbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreDemo4DbSchemaMigrator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the Demo4DbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<Demo4DbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
