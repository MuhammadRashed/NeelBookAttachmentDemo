import { Component } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  template: `
    <app-host-dashboard *abpPermission="'Demo4.Dashboard.Host'"></app-host-dashboard>
    <app-tenant-dashboard *abpPermission="'Demo4.Dashboard.Tenant'"></app-tenant-dashboard>
  `,
})
export class DashboardComponent {}
