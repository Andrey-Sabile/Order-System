import { APP_ID, ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { importProvidersFrom } from '@angular/core';
import { routes } from './app.routes';
import { provideClientHydration, BrowserModule } from '@angular/platform-browser';
import { provideAnimations } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal';
import { provideHttpClient, withFetch, withInterceptorsFromDi, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthorizeInterceptor } from './core/api-authorization/authorize.interceptor';

export function getBaseUrl() {
    return document.getElementsByTagName('base')[0].href;
  }
  
export const appConfig: ApplicationConfig = {
    providers: [
        provideRouter(routes),
        provideClientHydration(),
        provideHttpClient(withFetch(), withInterceptorsFromDi()),
        provideAnimations(),
        importProvidersFrom(ModalModule.forRoot()),
        { provide: APP_ID, useValue: 'ng-cli-universal'},
        { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
        { provide: 'BASE_URL', useFactory: getBaseUrl, deps: [] }
    ]
}