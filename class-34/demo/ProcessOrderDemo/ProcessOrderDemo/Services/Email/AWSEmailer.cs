using ProcessOrderDemo.Services.Email.Interfaces;
using ProcessOrderDemo.Services.Email.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessOrderDemo.Services.Email
{
  public class AWSEmailer : IEmail
  {
    public Task<EmailResponse> SendEmailAsync(Message message)
    {
      throw new NotImplementedException();
    }
  }
}
