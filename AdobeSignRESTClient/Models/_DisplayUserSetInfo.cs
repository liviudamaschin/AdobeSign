using System.Collections.Generic;

namespace AdobeSignRESTClient.Models
{
    public class _DisplayUserSetInfo
    {
        /// <summary>
        /// Displays the info about user set
        /// </summary>
        public List<_DisplayUserInfo> displayUserSetMemberInfos { get; set; }
        /// <summary>
        /// The name of the display user set. Returned only, if the API caller is the sender of agreement.
        /// </summary>
        public string displayUserSetName { get; set; }
    }
}
