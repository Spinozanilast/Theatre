using Twilio.Rest.Verify.V2.Service;

namespace Theatre.Application.Services;

public interface ISmsService
{
    Task<VerificationResource> SendSmsAsync(string phoneNumber);
    Task<bool> CheckVerificationResult(string code, string phoneNumber);
}