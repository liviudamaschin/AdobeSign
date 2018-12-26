
namespace AdobeSignRESTClient.Models
{
    public class _ReminderCreationInfo
    {
        /// <summary>
        /// The agreement identifier
        /// </summary>
        public string agreementId { get; set; }
        /// <summary>
        /// An optional message sent to the recipients, describing what is being sent and why their signatures are required.
        /// </summary>
        public string comment { get; set; }
    }
}
