import type { EmployeeCreateDto, EmployeeDto, EmployeeUpdateDto, GetEmployeesInput } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  apiName = 'Default';

  create = (input: EmployeeCreateDto) =>
    this.restService.request<any, EmployeeDto>({
      method: 'POST',
      url: '/api/app/employees',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/employees/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, EmployeeDto>({
      method: 'GET',
      url: `/api/app/employees/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: GetEmployeesInput) =>
    this.restService.request<any, PagedResultDto<EmployeeDto>>({
      method: 'GET',
      url: '/api/app/employees',
      params: { filterText: input.filterText, name: input.name, attachmentId: input.attachmentId, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  update = (id: string, input: EmployeeUpdateDto) =>
    this.restService.request<any, EmployeeDto>({
      method: 'PUT',
      url: `/api/app/employees/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
