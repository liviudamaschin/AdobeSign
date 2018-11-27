
namespace AdobeSignRESTClient.Models
{
    public class AgreementDocument
    {
        /// <summary>
        /// Id of the document
        /// </summary>
        public string documentId { get; set; }
        /// <summary>
        /// Mime-type of the document
        /// </summary>
        public string mimeType { get; set; }
        /// <summary>
        /// Name of the document
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Number of pages in the document
        /// </summary>
        public int numPages { get; set; }
    }
}
