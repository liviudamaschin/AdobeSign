using System.Threading.Tasks;

namespace AdobeSignRESTClient
{
    interface IAdobeSignREST
    {
        string AccessToken { get; set; }
        int AccessTokenExpires { get; }
        string ApiEndpointVer { get; set; }
        string RefreshToken { get; }

        Task Authorize(string refreshToken);
        Task Authorize(string authCode, string redirect_uri);
    }
}
