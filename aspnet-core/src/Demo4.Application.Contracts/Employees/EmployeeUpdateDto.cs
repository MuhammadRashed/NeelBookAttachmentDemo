using System;
using System.ComponentModel.DataAnnotations;

namespace Demo4.Employees
{
    public class EmployeeUpdateDto
    {
        public string Name { get; set; }
        public string AttachmentId { get; set; }
    }
}