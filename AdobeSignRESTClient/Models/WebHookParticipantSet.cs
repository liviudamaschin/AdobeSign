using System.Collections.Generic;

namespace AdobeSignRESTClient.Models
{
    public class WebHookParticipantSet
    {
        public List<WebHookMemberInfo> MemberInfos { get; set; }
        public string Order { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string PrivateMessage { get; set; }
    }
}
