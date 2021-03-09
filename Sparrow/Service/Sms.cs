using System;

namespace Service
{
    public class Sms
    {
        public string CheckIncomingMessage(string incomingText)
        {
            if (incomingText.ToLower() == "hi")
            {
                return GetWelcome();
            }
            else if (incomingText.ToLower() == "claimnumber 1234")
            {
                return "\nClaim number: 1234\nStatus: Closed\nClosed Date: 03/07/2021";
            }
            else if (incomingText.ToLower() == "claimnumber 4321")
            {
                return "\nClaim number: 4321\nStatus: Re-opened\nRe-opened Date: 03/07/2021\nRe-open reason: Litigation";
            }
            else if (incomingText.ToLower() == "claimnumber 1111")
            {
                return "\nClaim number: 1111\nStatus: Open";
            }
            else
            {
                return GetProviderByLoction(incomingText);
            }
        }
        public string GetWelcome()
        {
            return "\nHi! I'm SMS Bot. I can help you with:\nIn-Network Physician? REPLY <ZIPCODE>.\nClaim Status REPLY <ClaimNumber XXXX>";
          
        }
        public string GetProviderByLoction(string zipCode)
        {
            if (zipCode == "94111")
            {
                return "\nProvider:Primary Treating Physician(In-Network)\nAddress:26 CALIFORNIA ST San Francisco, CA 94111\nPhone:(415) 781-7077";
            }
            else if (zipCode == "94538")
            {
                return "\nProvider:Primary Treating Physician(In-Network)\nAddress:39400 Paseo Padre Pky Fremont, CA 94538\nPhone:(510) 248-3015";
            }
            else if (zipCode == "95695")
            {
                return "\nProvider:Primary Treating Physician(In-Network)\nAddress:39400 Paseo Padre Pky Fremont, CA 94538\nPhone:(510) 248-3015";
            }
            else {
                return "Invalid Entry!";
            }
        }
    }
}
