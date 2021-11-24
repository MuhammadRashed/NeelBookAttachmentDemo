using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Demo4.Permissions;
using Demo4.Employees;
using NeelbookAttachment;

namespace Demo4.Employees
{
    [RemoteService(IsEnabled = false)]
    [Authorize(Demo4Permissions.Employees.Default)]
    public class EmployeesAppService : ApplicationService, IEmployeesAppService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAttachmentDetailsAppService attachmentDetailsAppService;

        public EmployeesAppService(IEmployeeRepository employeeRepository , IAttachmentDetailsAppService attachmentDetailsAppService)
        {
            _employeeRepository = employeeRepository;
            this.attachmentDetailsAppService = attachmentDetailsAppService;
        }

        public virtual async Task<PagedResultDto<EmployeeDto>> GetListAsync(GetEmployeesInput input)
        {
            var totalCount = await _employeeRepository.GetCountAsync(input.FilterText, input.Name, input.AttachmentId);
            var items = await _employeeRepository.GetListAsync(input.FilterText, input.Name, input.AttachmentId, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<EmployeeDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Employee>, List<EmployeeDto>>(items)
            };
        }

        public virtual async Task<EmployeeDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Employee, EmployeeDto>(await _employeeRepository.GetAsync(id));
        }

        [Authorize(Demo4Permissions.Employees.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _employeeRepository.DeleteAsync(id);
        }

        [Authorize(Demo4Permissions.Employees.Create)]
        public virtual async Task<EmployeeDto> CreateAsync(EmployeeCreateDto input)
        {

            var employee = ObjectMapper.Map<EmployeeCreateDto, Employee>(input);

            employee = await _employeeRepository.InsertAsync(employee, autoSave: true);

            var conf = await attachmentDetailsAppService.ConfirmAsync(new AttachmentConfirmDto() { AttachmentId = input.AttachmentId });
            employee.AttachmentId = conf.AttachmentId;
            employee = await _employeeRepository.UpdateAsync(employee, autoSave: true);

            return ObjectMapper.Map<Employee, EmployeeDto>(employee);
        }

        [Authorize(Demo4Permissions.Employees.Edit)]
        public virtual async Task<EmployeeDto> UpdateAsync(Guid id, EmployeeUpdateDto input)
        {

            var employee = await _employeeRepository.GetAsync(id);
            ObjectMapper.Map(input, employee);
            employee = await _employeeRepository.UpdateAsync(employee, autoSave: true);
            await attachmentDetailsAppService.ConfirmAsync(new AttachmentConfirmDto() { AttachmentId = input.AttachmentId });
            var conf = await attachmentDetailsAppService.ConfirmAsync(new AttachmentConfirmDto() { AttachmentId = input.AttachmentId });
            employee.AttachmentId = conf.AttachmentId;
            employee = await _employeeRepository.UpdateAsync(employee, autoSave: true);

            return ObjectMapper.Map<Employee, EmployeeDto>(employee);
        }
    }
}