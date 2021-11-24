using System;
using Volo.Abp.Application.Dtos;

namespace Demo4.Employees
{
    public class EmployeeDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string AttachmentId { get; set; }
    }
}