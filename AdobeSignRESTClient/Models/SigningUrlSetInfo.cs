using System.Collections.Generic;

namespace AdobeSignRESTClient.Models
{
    public class SigningUrlSetInfo
    {
        public List<SigningUrl> SigningUrls { get; set; }
        public string SigningUrlSetName { get; set; }
    }
}
