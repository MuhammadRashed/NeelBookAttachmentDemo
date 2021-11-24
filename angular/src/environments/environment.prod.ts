import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'Demo4',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44364',
    redirectUri: baseUrl,
    clientId: 'Demo4_App',
    responseType: 'code',
    scope: 'offline_access Demo4',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44364',
      rootNamespace: 'Demo4',
    },
  },
} as Environment;
