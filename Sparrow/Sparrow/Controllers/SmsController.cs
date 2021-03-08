using System.Web.Mvc;
using Twilio;
using Twilio.TwiML;
using Twilio.AspNet.Mvc;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using System.Net.Mail;

namespace Sparrow.Controllers
{
    public class SmsController : TwilioController
    {
        public ActionResult SendSms()
        {
            var accountSid = "ACd7866d577d7850a0d4beee7722edd17e";
            var authToken = "389a892c27cadf5c81a6b0b4b0908350";
            TwilioClient.Init(accountSid, authToken);
            var to = new PhoneNumber("+14157451519");
            var from = new PhoneNumber("+19898001313");

            var message = MessageResource.Create(
                to: to,
                from: from,
                body: "Hi! I'm SMS Bot from BHHC. I can help you with:\nIn-Network Physician? REPLY <ZIPCODE>.\nClaim Status REPLY <CLAIMNUMBER>\nPayment Status REPLY RECENTPAYMENT"
                );
            return Content("Message Sent!");
        }

        public ActionResult ReceiveSms()
        {
            var response = new MessagingResponse();
            response.Message("Thank you!");
            return TwiML(response);
        }

        public ActionResult smspost()
        {
            var requestBody = Request.Form["Body"];
            var response = new MessagingResponse();
            if (requestBody == "hello")
            {
                response.Message("Hi!");
            }
            else if (requestBody == "bye")
            {
                response.Message("Goodbye");
            }

            return TwiML(response);
        }

        public ActionResult SMSv()
        {
            var message = new MailMessage();
            message.From = new MailAddress("sgosalia@bhhc.com");
            message.To.Add(new MailAddress("5107714313@txt.att.net"));
            message.Subject = "This is my subject";
            message.Body = "This is the content";
            var client = new SmtpClient();
            client.Host = "wcsmtp.berkshire.local";
            client.Port = 25;
            client.UseDefaultCredentials = false;
            client.Send(message);
            return Content("SMS Sent!");
        }

    }
}
