using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System.Web;

namespace SMSTester
{
    class SendSMS
    {
        static void Main(string[] args)
        {
            #region Twilio Provider
            //Method-1 Twilio
            const string accountSid = "YourAccount Sid from Twilio goes here";
            const string authToken = "Auth Token Goes here";
            TwilioClient.Init(accountSid, authToken);
            var message = MessageResource.Create(
                body: "A sample Message that will be shared to the number of your choice",
                from: new Twilio.Types.PhoneNumber("From number which you'll get from Twilio Account"),
                to: new Twilio.Types.PhoneNumber("Send to Mobile No. #")
            );
            Console.WriteLine(message.Sid);
            #endregion

            #region TxtLocal Provider
            //Method-2 : Txt Local
            String txtMessage = HttpUtility.UrlEncode("A sample Message that will be shared to the number of your choice");
            using (var wb = new WebClient())
            {
                byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                {
                {"apikey" , "Your txtlocal API Key"},
                {"numbers" , "Send to Mobile number#"},
                {"message" , txtMessage},
                {"sender" , "TXTLCL"}
                });
                string result = System.Text.Encoding.UTF8.GetString(response);
                Console.WriteLine(result);
            }
            #endregion
        }
    }
}
