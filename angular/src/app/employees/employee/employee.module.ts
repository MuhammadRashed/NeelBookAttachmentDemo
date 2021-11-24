import { NeelbookAttachmentModule } from 'neelbook-attachment';
import { CoreModule } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgModule } from '@angular/core';
import { NgbCollapseModule, NgbDatepickerModule, NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxValidateCoreModule } from '@ngx-validate/core';
import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';
import { PageModule } from '@abp/ng.components/page';
import { EmployeeComponent } from './components/employee.component';
import { EmployeeRoutingModule } from './employee-routing.module';

@NgModule({
  declarations: [EmployeeComponent],
  imports: [
    EmployeeRoutingModule,
    CoreModule,
    NeelbookAttachmentModule,
    ThemeSharedModule,
    CommercialUiModule,
    NgxValidateCoreModule,
    NgbCollapseModule,
    NgbDatepickerModule,
    NgbDropdownModule,
    PageModule
  ],
})
export class EmployeeModule {}
