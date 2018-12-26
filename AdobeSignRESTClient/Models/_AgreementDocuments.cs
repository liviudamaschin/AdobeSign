using System.Collections.Generic;

namespace AdobeSignRESTClient.Models
{
    public class _AgreementDocuments
    {
        /// <summary>
        /// A list of objects representing the documents
        /// </summary>
        public List<_AgreementDocument> documents { get; set; }
        /// <summary>
        /// A list of supporting documents. This is returned only if there are any supporting document in the agreement
        /// </summary>
        public List<_AgreementSupportingDocument> supportingDocuments { get; set; }
    }
}
