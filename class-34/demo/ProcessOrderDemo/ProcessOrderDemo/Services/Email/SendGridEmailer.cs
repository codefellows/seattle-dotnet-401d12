using Microsoft.Extensions.Configuration;
using ProcessOrderDemo.Services.Email.Interfaces;
using ProcessOrderDemo.Services.Email.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessOrderDemo.Services.Email
{
  public class SendGridEmailer : IEmail
  {
    public IConfiguration Configuration { get; set; }

    public SendGridEmailer(IConfiguration config)
    {
      Configuration = config;
    }
    public async Task<EmailResponse> SendEmailAsync(Message inboundMessage)
    {

      string apiKey = Configuration["SendGrid:Key"];
      string fromEmail = Configuration["SendGrid:DefaultFromAddress"];
      string fromName = Configuration["SendGrid:DefaultFromName"];

      var client = new SendGridClient(apiKey);

      SendGridMessage msg = new SendGridMessage();
      msg.SetFrom(new EmailAddress(fromEmail, fromName));
      msg.AddTo(inboundMessage.To);
      msg.SetSubject(inboundMessage.Subject);
      msg.AddContent(MimeType.Html, inboundMessage.Body);

      var sendGridResponse = await client.SendEmailAsync(msg);

      EmailResponse response = new EmailResponse()
      {
        WasSent = sendGridResponse.IsSuccessStatusCode
      };

      return response;

    }
  }
}
