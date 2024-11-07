namespace Theatre.Application.Common.ConfigurationOptions;

public class TwilioAccountOptions
{
    public const string Position = "Twilio";
    
    public string AuthToken { get; set; } = string.Empty;
    public string AccountSid { get; set; } = string.Empty;
    public string SmsServicePathSid { get; set; } = string.Empty;
}