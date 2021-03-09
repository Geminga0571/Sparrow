using System.Web.Mvc;
using Twilio;
using Twilio.TwiML;
using Twilio.AspNet.Mvc;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using System.Net.Mail;
using Service;

namespace Sparrow.Controllers
{
    public class SmsController : TwilioController
    {
        public ActionResult ReceiveSms()
        {
            var response = new MessagingResponse();
            var requestBody = Request.Form["Body"].ToString();
            var requester = Request.Form["From"].ToString();
            Sms sms = new Sms();
            var accountSid = "<AccountSIDFromYourTwilioAccount>";
            var authToken = "<AuthTokenFromYourTwilioAccount>";
            TwilioClient.Init(accountSid, authToken);
            var to = new PhoneNumber(requester);
            var from = new PhoneNumber("<YourTwilioPhoneNumber>");
            var message = MessageResource.Create(
                to: to,
                from: from,
                body: sms.CheckIncomingMessage(requestBody)
                );
            return TwiML(response);
        }
    }
}
