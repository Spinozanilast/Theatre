namespace Theatre.Contracts.PhoneVerification;

public record VerifyCodeRequest(string PhoneNumber, string VerificationCode);