
namespace AdobeSignRESTClient.Models
{
    public class AgreementSupportingDocument
    {
        /// <summary>
        /// Display name of the document
        /// </summary>
        public string displayLabel { get; set; }
        /// <summary>
        /// Mime-type of the document
        /// </summary>
        public string mimeType { get; set; }
        /// <summary>
        /// The name of the supporting document field
        /// </summary>
        public string fieldName { get; set; }
        /// <summary>
        /// Number of pages in the document
        /// </summary>
        public int numPages { get; set; }
        /// <summary>
        /// Id representing the document
        /// </summary>
        public string supportingDocumentId { get; set; }
    }
}
