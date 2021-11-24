using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Demo4.Employees
{
    public interface IEmployeeRepository : IRepository<Employee, Guid>
    {
        Task<List<Employee>> GetListAsync(
            string filterText = null,
            string name = null,
            string attachmentId = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filterText = null,
            string name = null,
            string attachmentId = null,
            CancellationToken cancellationToken = default);
    }
}