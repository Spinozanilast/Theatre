import { ApplicationConfig, LOCALE_ID } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';

import { routes } from './app.routes';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { errorInterceptor } from '@interceptors/global-error.interceptor';

export const appConfig: ApplicationConfig = {
    providers: [
        provideRouter(routes),
        // provideHttpClient(withInterceptors([errorInterceptor])),
        provideHttpClient(),
        provideAnimationsAsync('animations'),
    ],
};
