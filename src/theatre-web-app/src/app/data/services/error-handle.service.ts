import { HttpErrorResponse } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Router } from '@angular/router';

export interface QueryErrorParams {
    status: number;
    message: string;
}

@Injectable({
    providedIn: 'root',
})
export class ErrorHandleService {
    router = inject(Router);

    handleError(error: HttpErrorResponse) {
        console.log(error);

        const queryParams: QueryErrorParams = {
            status: error.status,
            message: error.message,
        };
        this.router.navigate(['/error'], { queryParams: { ...queryParams } });
    }
}
