namespace AdobeSignRESTClient.Models
{
    /// <summary>
    /// Information about the agreement that you want to send and authoring options that you want to apply at the time of sending
    /// </summary>
    public class _AgreementRequest
    {
        /// <summary>
        ///  Information about the document you want to send,
        /// </summary>
        public _DocumentCreationInfo documentCreationInfo { get; set; }
        /// <summary>
        ///  Options for authoring and sending the agreement
        /// </summary>
        public _InteractiveOptions options { get; set; }
    }
}
