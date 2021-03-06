﻿
namespace AdobeSignRESTClient.Models
{
    public class _WidgetSecurityOption
    {
        /// <summary>
        /// ['NONE' or 'INHERITED_FROM_DOCUMENT' or 'PASSWORD' or 'WEB_IDENTITY' or 'KBA' or 'PHONE']
        /// The authentication method for the recipients to have access to view and sign the widget
        /// </summary>
        public string authenticationMethod { get; set; }
    }
}
