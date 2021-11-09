using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML.Voice;
using Twilio.Types;

namespace Core.Common.SMS
{
    public interface IMessageSender
    {
        Task<(bool, string)> SendSmsAsync(string number, string message);
    }

    public class MessageSender : IMessageSender
    {
        private IConfiguration _configuration;
        public MessageSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<(bool, string)> SendSmsAsync(string number, string message)
        {
            try
            {
                TwilioClient.Init(_configuration["SMSoptions:Identification"], _configuration["SMSoptions:Password"]);
                await MessageResource.CreateAsync(
                                                   to: new PhoneNumber(string.Concat("+51", number)),
                                                   from: new PhoneNumber(_configuration["SMSoptions:From"]),
                                                   body: message);
                return (true, string.Empty);
            }
            catch (Exception ex)
            {
                return (true, ex.ToString());
            }
        }
    }
}
