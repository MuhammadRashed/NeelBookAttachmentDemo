import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const EMPLOYEES_EMPLOYEE_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/employees',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:Employees',
        layout: eLayoutType.application,
        requiredPolicy: 'Demo4.Employees',
      },
    ]);
  };
}
