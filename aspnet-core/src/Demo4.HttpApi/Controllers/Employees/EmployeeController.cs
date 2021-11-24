using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Demo4.Employees;

namespace Demo4.Controllers.Employees
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Employee")]
    [Route("api/app/employees")]

    public class EmployeeController : AbpController, IEmployeesAppService
    {
        private readonly IEmployeesAppService _employeesAppService;

        public EmployeeController(IEmployeesAppService employeesAppService)
        {
            _employeesAppService = employeesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<EmployeeDto>> GetListAsync(GetEmployeesInput input)
        {
            return _employeesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<EmployeeDto> GetAsync(Guid id)
        {
            return _employeesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<EmployeeDto> CreateAsync(EmployeeCreateDto input)
        {
            return _employeesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<EmployeeDto> UpdateAsync(Guid id, EmployeeUpdateDto input)
        {
            return _employeesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _employeesAppService.DeleteAsync(id);
        }
    }
}