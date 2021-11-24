using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Demo4.EntityFrameworkCore;

namespace Demo4.Employees
{
    public class EfCoreEmployeeRepository : EfCoreRepository<Demo4DbContext, Employee, Guid>, IEmployeeRepository
    {
        public EfCoreEmployeeRepository(IDbContextProvider<Demo4DbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<Employee>> GetListAsync(
            string filterText = null,
            string name = null,
            string attachmentId = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, name, attachmentId);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? EmployeeConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string name = null,
            string attachmentId = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, name, attachmentId);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Employee> ApplyFilter(
            IQueryable<Employee> query,
            string filterText,
            string name = null,
            string attachmentId = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Name.Contains(filterText) || e.AttachmentId.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                    .WhereIf(!string.IsNullOrWhiteSpace(attachmentId), e => e.AttachmentId.Contains(attachmentId));
        }
    }
}