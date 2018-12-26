using System.Collections.Generic;

namespace AdobeSignRESTClient.Models
{
    public class WebHookInfo
    {
        public string WebHookId { get; set; }
        public string WebHookName { get; set; }
        public string WebHookNotificationId { get; set; }
        public List<WebHookNotificationApplicableUser> WebHookNotificationApplicableUsers { get; set; }
        public WebHookUrlInfo WebHookUrlInfo { get; set; }
        public string WebHookScope { get; set; }
        public string Event { get; set; }
        public string EventDate { get; set; }
        public string EventResourceParentType { get; set; }
        public string EventResourceParentId { get; set; }
        public string SubEvent { get; set; }
        public string EventResourceType { get; set; }
        public string ParticipantRole { get; set; }
        public string ActionType { get; set; }
        public string ParticipantUserId { get; set; }
        public string ParticipantUserEmail { get; set; }
        public string ActingUserId { get; set; }
        public string ActingUserEmail { get; set; }
        public string InitiatingUserId { get; set; }
        public string InitiatingUserEmail { get; set; }
        public string ActingUserIpAddress { get; set; }
        public WebHookAgreement Agreement { get; set; }
    }
}
