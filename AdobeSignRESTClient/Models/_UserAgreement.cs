﻿using System;
using System.Collections.Generic;

namespace AdobeSignRESTClient.Models
{
    public class _UserAgreement
    {
        /// <summary>
        /// The unique identifier of the agreement
        /// </summary>
        public string agreementId { get; set; }
        /// <summary>
        /// A version ID which uniquely identifies the current version of the agreement
        /// </summary>
        public string latestVersionId { get; set; }
        /// <summary>
        /// Name of the Agreement
        /// </summary>
        public string name { get; set; }
        /// <summary>
        ///  ['WAITING_FOR_MY_SIGNATURE' or 'WAITING_FOR_MY_APPROVAL' or 'WAITING_FOR_MY_DELEGATION' or 'OUT_FOR_SIGNATURE' or 'OUT_FOR_APPROVAL' 
        ///  or 'SIGNED' or 'APPROVED' or 'RECALLED' or 'WAITING_FOR_FAXIN' or 'ARCHIVED' or 'FORM' or 'EXPIRED' or 'WIDGET' or 'WAITING_FOR_AUTHORING']: 
        ///  The current status of the document from the perspective of the user
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// True if this is an e-sign document
        /// </summary>
        public bool esign { get; set; }
        /// <summary>
        /// The display date for the agreement
        /// </summary>
        public DateTime displayDate { get; set; }
        /// <summary>
        /// The most relevant current user set for the agreement. It is typically the next signer if the agreement is from the current user, or the sender if received from another user
        /// </summary>
        public List<_DisplayUserSetInfo> displayUserSetInfos { get; set; }
    }
}
