import { HttpResponse, HttpResponseBase } from '@angular/common/http';
import { Component, EventEmitter, inject, Output } from '@angular/core';
import {
    FormControl,
    FormGroup,
    ReactiveFormsModule,
    Validators,
} from '@angular/forms';
import {
    SendVerificationCodeRequest,
    VerifyCodeRequest,
} from '@data/phone-verification.interfaces';
import { UserData } from '@data/user.interfaces';
import { PhoneVerificationService } from '@services/phone-verification.service';
import { NgxMaskDirective, provideNgxMask } from 'ngx-mask';

@Component({
    selector: 'user-data-input',
    standalone: true,
    imports: [NgxMaskDirective, ReactiveFormsModule],
    templateUrl: './user-data-input.component.html',
    styleUrl: './user-data-input.component.less',
    providers: [provideNgxMask()],
})
export class UserDataInputComponent {
    private readonly verificationService = inject(PhoneVerificationService);

    @Output() submit = new EventEmitter<UserData>();
    isPhoneNumberVerified = false;

    private phoneCountryCode = '+375';
    private phoneNumberLength = 9;

    userDataGroup = new FormGroup({
        name: new FormControl('', Validators.maxLength(20)),
        email: new FormControl('', Validators.required),
        phone: new FormControl('', Validators.required),
        verificationCode: new FormControl('', [
            Validators.required,
            Validators.minLength(6),
        ]),
    });

    getUnmaskedPhoneNumber(phoneValue: string): string {
        return this.phoneCountryCode + phoneValue.replace(/\D/g, '')!;
    }

    verifyPhone(): void {
        const verificationRequest: VerifyCodeRequest = {
            phoneNumber: this.getUnmaskedPhoneNumber(
                this.userDataGroup.value.phone!
            ),
            verificationCode: this.userDataGroup.value.verificationCode!,
        };

        this.verificationService
            .verifyCode(verificationRequest)
            .subscribe(() => {
                this.isPhoneNumberVerified = true;
            });
    }

    sendVerificationCode(): void {
        const verificationRequest: SendVerificationCodeRequest = {
            phoneNumber: this.getUnmaskedPhoneNumber(
                this.userDataGroup.value.phone!
            ),
        };

        this.verificationService
            .sendVerificationCode(verificationRequest)
            .subscribe();
    }

    onSubmit(): void {
        if (this.userDataGroup.valid) {
            const userData: UserData = {
                firstName: this.userDataGroup.value.name!,
                phoneNumber: this.getUnmaskedPhoneNumber(
                    this.userDataGroup.value.phone!
                ),
                email: this.userDataGroup.value.email!,
            };

            this.submit.emit(userData);
        }
    }

    isPhoneNumberValidToVerify(): boolean {
        return (
            this.userDataGroup.value.phone!.length === this.phoneNumberLength
        );
    }
}
