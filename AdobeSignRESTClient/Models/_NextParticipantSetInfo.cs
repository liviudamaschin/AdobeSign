using System.Collections.Generic;

namespace AdobeSignRESTClient.Models
{
    public class _NextParticipantSetInfo
    {
        /// <summary>
        /// Information about the members of the next participant set
        /// </summary>
        public List<_NextParticipantInfo> nextParticipantSetMemberInfos { get; set; }
        /// <summary>
        /// The name of the next participant set. Returned only, if the API caller is the sender of agreement
        /// </summary>
        public string nextParticipantSetName { get; set; }
    }
}
