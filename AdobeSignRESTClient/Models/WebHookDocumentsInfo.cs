using System.Collections.Generic;

namespace AdobeSignRESTClient.Models
{
    public class WebHookDocumentsInfo
    {
        public List<WebHookDocument> Documents { get; set; }
        public List<WebHookDocument> SupportingDocuments { get; set; }
    }
}
