using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Theatre.Application.Common.ConfigurationOptions;
using Theatre.Application.Services;
using Theatre.Contracts.PhoneVerification;

namespace Theatre.Api.Controllers;

[ApiController]
[Route("phone-verification")]
public class PhoneNumberVerificationController(IOptions<TwilioAccountOptions> options) : ControllerBase
{
    private readonly ISmsService _twilioSmsService = new TwilioSmsService(options);

    [HttpPost("send-verification-code")]
    public async Task<IActionResult> SendVerificationCode([FromBody] SendVerificationCodeRequest request)
    {
        if (string.IsNullOrEmpty(request.PhoneNumber))
        {
            return BadRequest("Phone number is required.");
        }

        await _twilioSmsService.SendSmsAsync(request.PhoneNumber);
        return Ok(new { Message = "Verification code sent successfully." });
    }

    [HttpPost("verify-code")]
    public async Task<IActionResult> VerifyCode([FromBody] VerifyCodeRequest request)
    {
        if (string.IsNullOrEmpty(request.PhoneNumber) || string.IsNullOrEmpty(request.VerificationCode))
        {
            return BadRequest("Phone number and code are required.");
        }


        var verificationResult =
            await _twilioSmsService.CheckVerificationResult(request.VerificationCode, request.PhoneNumber);

        if (verificationResult)
        {
            return Ok(new { Message = "Verification successful." });
        }

        return Unauthorized("Invalid verification code.");
    }
}