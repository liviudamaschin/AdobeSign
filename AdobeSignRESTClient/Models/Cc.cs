using System.Collections.Generic;

namespace AdobeSignRESTClient.Models
{
    public class Cc
    {
        public string Email { get; set; }
        public string Label { get; set; }
        public List<string> VisiblePages { get; set; }
    }
}
