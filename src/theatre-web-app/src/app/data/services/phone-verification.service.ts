import { inject, Injectable } from '@angular/core';
import {
    HttpClient,
    HttpResponse,
    HttpResponseBase,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'environments/environment.development';
import {
    SendVerificationCodeRequest,
    VerifyCodeRequest,
} from '@data/phone-verification.interfaces';

@Injectable({
    providedIn: 'root',
})
export class PhoneVerificationService {
    private http = inject(HttpClient);
    private apiUrl = `${environment.apiUrl}/phone-verification`;

    sendVerificationCode(
        request: SendVerificationCodeRequest
    ): Observable<any> {
        return this.http
            .post(`${this.apiUrl}/send-verification-code`, request)
            .pipe(map((response) => response));
    }

    verifyCode(request: VerifyCodeRequest): Observable<any> {
        return this.http
            .post(`${this.apiUrl}/verify-code`, request)
            .pipe(map((response) => response));
    }
}
