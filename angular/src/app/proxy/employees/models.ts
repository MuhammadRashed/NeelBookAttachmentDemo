import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface EmployeeCreateDto {
  name?: string;
  attachmentId?: string;
}

export interface EmployeeDto extends FullAuditedEntityDto<string> {
  name?: string;
  attachmentId?: string;
}

export interface EmployeeUpdateDto {
  name?: string;
  attachmentId?: string;
}

export interface GetEmployeesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  name?: string;
  attachmentId?: string;
}
