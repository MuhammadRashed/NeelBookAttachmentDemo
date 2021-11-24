using System;
using Demo4.Shared;
using Volo.Abp.AutoMapper;
using Demo4.Employees;
using AutoMapper;

namespace Demo4
{
    public class Demo4ApplicationAutoMapperProfile : Profile
    {
        public Demo4ApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<EmployeeCreateDto, Employee>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<EmployeeUpdateDto, Employee>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<Employee, EmployeeDto>();
        }
    }
}