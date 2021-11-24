using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Demo4.Employees
{
    public interface IEmployeesAppService : IApplicationService
    {
        Task<PagedResultDto<EmployeeDto>> GetListAsync(GetEmployeesInput input);

        Task<EmployeeDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<EmployeeDto> CreateAsync(EmployeeCreateDto input);

        Task<EmployeeDto> UpdateAsync(Guid id, EmployeeUpdateDto input);
    }
}