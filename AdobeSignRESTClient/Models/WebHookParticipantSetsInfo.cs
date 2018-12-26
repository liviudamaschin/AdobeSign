using System.Collections.Generic;

namespace AdobeSignRESTClient.Models
{
    public class WebHookParticipantSetsInfo
    {
        public List<WebHookParticipantSet> ParticipantSets { get; set; }
        public List<WebHookParticipantSet> NextParticipantSets { get; set; }
    }
}
