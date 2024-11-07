import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { ErrorHandleService } from '@data/services/error-handle.service';
import { catchError, throwError } from 'rxjs';

export const errorInterceptor: HttpInterceptorFn = (req, next) => {
    const errorHandler = inject(ErrorHandleService);
    return next(req).pipe(
        catchError((error: HttpErrorResponse) => {
            errorHandler.handleError(error);
            return throwError(() => error);
        })
    );
};
