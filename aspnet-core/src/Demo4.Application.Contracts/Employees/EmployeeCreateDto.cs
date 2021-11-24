using System;
using System.ComponentModel.DataAnnotations;

namespace Demo4.Employees
{
    public class EmployeeCreateDto
    {
        public string Name { get; set; }
        public string AttachmentId { get; set; }
    }
}