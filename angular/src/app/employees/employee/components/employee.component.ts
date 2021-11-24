import { ABP, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type {
  GetEmployeesInput,
  EmployeeDto,
} from '../../../proxy/employees/models';
import { EmployeeService } from '../../../proxy/employees/employee.service';

@Component({
  selector: 'app-employee',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './employee.component.html',
  styles: [],
})
export class EmployeeComponent implements OnInit {
  data: PagedResultDto<EmployeeDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetEmployeesInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  selected?: EmployeeDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: EmployeeService,
    private confirmation: ConfirmationService,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    const getData = (query: ABP.PageQueryParams) =>
      this.service.getList({
        ...query,
        ...this.filters,
        filterText: query.filter,
      });

    const setData = (list: PagedResultDto<EmployeeDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetEmployeesInput;
  }

  buildForm() {
    const {
      name,
      attachmentId,
    } = this.selected || {};

    this.form = this.fb.group({
      name: [name ?? null, []],
      attachmentId: [attachmentId ?? null, []],
    });
  }

  hideForm() {
    this.isModalOpen = false;
    this.form.reset();
  }

  showForm() {
    this.buildForm();
    this.isModalOpen = true;
  }

  submitForm() {
    if (this.form.invalid) return;

    const request = this.selected
      ? this.service.update(this.selected.id, this.form.value)
      : this.service.create(this.form.value);

    this.isModalBusy = true;

    request
      .pipe(
        finalize(() => (this.isModalBusy = false)),
        tap(() => this.hideForm()),
      )
      .subscribe(this.list.get);
  }

  create() {
    this.selected = undefined;
    this.showForm();
  }

  update(record: EmployeeDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: EmployeeDto) {
    this.confirmation.warn(
      '::DeleteConfirmationMessage',
      '::AreYouSure',
      { messageLocalizationParams: [] }
    ).pipe(
      filter(status => status === Confirmation.Status.confirm),
      switchMap(() => this.service.delete(record.id)),
    ).subscribe(this.list.get);
  }
}
