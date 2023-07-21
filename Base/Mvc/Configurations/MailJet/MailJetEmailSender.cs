using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity.UI.Services;
using Models.UtilityModels;
using Newtonsoft.Json.Linq;

namespace Mvc.Configurations.MailJet
{
    public class MailJetEmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<MailJetEmailSender> _logger;
        private readonly string businessEmail = "jerell.smith.09@gmail.com"; // replace with inquiry@smithovision.com
        private readonly string formInquiryEmail = "lakeboy7824@protonmail.com";
        private readonly string formInquiryName = "New Client Inquiry";

        public MailJetOptions _mailJetOptions;
        public MailJetEmailSender(IConfiguration configuration, ILogger<MailJetEmailSender> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public async Task SendEmailAsync(string email, string formType, string htmlMessage)
        {
            _mailJetOptions = _configuration.GetSection("MailJet").Get<MailJetOptions>();

            MailjetClient client = new MailjetClient(_mailJetOptions.ApiKey, _mailJetOptions.SecretKey);
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
            .Property(Send.FromEmail, SD.FORM_EMAIL_SENDER)  // replace with inquiry@smithovision.com
            .Property(Send.FromName, formType)
            .Property(Send.To, SD.FORM_EMAIL_RECEIVER)
            .Property(Send.Subject, formInquiryName)
            .Property(Send.HtmlPart, htmlMessage);

            await client.PostAsync(request);
            //if (response.IsSuccessStatusCode)
            //{
            //    _logger.LogInformation(string.Format("Total: {0}, Count: {1}\n", response.GetTotal(), response.GetCount()));
            //    //_logger.LogInformation(response.GetData());
            //}
            //else
            //{
            //    _logger.LogError(string.Format("StatusCode: {0}\n", response.StatusCode));
            //    _logger.LogError(string.Format("ErrorInfo: {0}\n", response.GetErrorInfo()));
            //    _logger.LogError(string.Format("ErrorMessage: {0}\n", response.GetErrorMessage()));
            //    _logger.LogError(response.ToString());
            //}
        }
    }
}