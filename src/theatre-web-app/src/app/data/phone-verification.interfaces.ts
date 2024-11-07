export interface SendVerificationCodeRequest {
    phoneNumber: string;
}

export interface VerifyCodeRequest {
    phoneNumber: string;
    verificationCode: string;
}
