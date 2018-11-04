using AdobeSignRESTClient.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdobeSignRESTClient.ErrorHandling
{
    public class AdobeSignOAuthException: Exception
    {
        public AdobeSignError Error { get; set; }
        public AdobeSignOAuthException(AdobeSignError error)
        {
            this.Error = error;
        }
    }
}
