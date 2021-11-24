using System.Threading.Tasks;

namespace Demo4.Data
{
    public interface IDemo4DbSchemaMigrator
    {
        Task MigrateAsync();
    }
}