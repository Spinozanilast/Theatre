using Microsoft.Extensions.Options;
using Theatre.Application.Common.ConfigurationOptions;
using Twilio;
using Twilio.Rest.Conversations.V1;
using Twilio.Rest.Verify.V2.Service;

namespace Theatre.Application.Services;

public class TwilioSmsService : ISmsService
{
    public const string TwilioResourseChannel = "sms";
    public readonly TwilioAccountOptions _twilioAccountOptions;

    public TwilioSmsService(IOptions<TwilioAccountOptions> options)
    {
        _twilioAccountOptions = options.Value;
    }

    public async Task<VerificationResource> SendSmsAsync(string phoneNumber)
    {
        TwilioClient.Init(_twilioAccountOptions.AccountSid, _twilioAccountOptions.AuthToken);

        var verification = await VerificationResource.CreateAsync(
            to: phoneNumber,
            channel: TwilioResourseChannel,
            pathServiceSid: _twilioAccountOptions.SmsServicePathSid);

        return verification;
    }

    public async Task<bool> CheckVerificationResult(string code, string phoneNumber)
    {
        TwilioClient.Init(_twilioAccountOptions.AccountSid, _twilioAccountOptions.AuthToken);

        var verificationResult = await VerificationCheckResource.CreateAsync(
            to: phoneNumber,
            code: code,
            pathServiceSid: _twilioAccountOptions.SmsServicePathSid);

        return verificationResult.Status == "approved";
    }
}