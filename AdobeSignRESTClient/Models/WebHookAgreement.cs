using System.Collections.Generic;

namespace AdobeSignRESTClient.Models
{
    public class WebHookAgreement
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SignatureType { get; set; }
        public string Status { get; set; }
        public List<Cc> Ccs { get; set; }
        public DeviceInfo DeviceInfo { get; set; }
        public string DocumentVisibilityEnabled { get; set; }
        public string CreatedDate { get; set; }
        public string ExpirationTime { get; set; }
        public ExternalId ExternalId { get; set; }
        public PostSignOption PostSignOption { get; set; }
        public string FirstReminderDelay { get; set; }
        public string Locale { get; set; }
        public string Message { get; set; }
        public string ReminderFrequency { get; set; }
        public string SenderEmail { get; set; }
        public VaultingInfo VaultingInfo { get; set; }
        public string WorkflowId { get; set; }
        public WebHookParticipantSetsInfo ParticipantSetsInfo { get; set; }
        public WebHookDocumentsInfo DocumentsInfo { get; set; }
    }
}
