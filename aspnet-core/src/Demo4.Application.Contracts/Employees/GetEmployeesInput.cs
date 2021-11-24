using Volo.Abp.Application.Dtos;
using System;

namespace Demo4.Employees
{
    public class GetEmployeesInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string Name { get; set; }
        public string AttachmentId { get; set; }

        public GetEmployeesInput()
        {

        }
    }
}