using AdobeSignRESTClient.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdobeSignRESTClient.ErrorHandling
{
    class AdobeSignBadRequestException : Exception
    {
        public AdobeSignErrorCode Error { get; set; }

        public AdobeSignBadRequestException(AdobeSignErrorCode error)
        {
            this.Error = error;
        }
    }
}
