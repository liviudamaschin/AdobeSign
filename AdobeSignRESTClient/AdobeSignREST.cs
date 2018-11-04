using AdobeSignRESTClient.ErrorHandling;
using AdobeSignRESTClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AdobeSignRESTClient
{
    public class AdobeSignREST : IAdobeSignREST
    {
        private readonly HttpClient _client;

        private readonly string _clientId;
        private readonly string _secretId;
        private string _apiUrl;
        private readonly string _apiEndpointVer = "api/rest/v6";

        public string AccessToken { get; set; }
        public int AccessTokenExpires { get; set; }
        public string ApiEndpointVer { get; set; }
        public string RefreshToken { get; set; }

        /// <summary>
        /// Initialize AdobeSignREST without Access Token. Must call Authorize() after initialization to acquire Access Token.
        /// </summary>
        /// <param name="apiUrl">API url returned from the authorization request URL</param>
        /// <param name="clientId">Application/Client ID</param>
        /// <param name="secretId">Client Secret</param>
        public AdobeSignREST(string apiUrl, string clientId, string secretId)
        {
            _apiUrl = apiUrl;
            _clientId = clientId;
            _secretId = secretId;

            _client = new HttpClient {BaseAddress = new Uri(apiUrl)};
        }

        /// <summary>
        /// Refresh existing Access Token with the Refresh Token.
        /// </summary>
        /// <param name="refreshToken">Refresh Token used to get a new Access Token.</param>
        /// <returns></returns>
        public async Task Authorize(string refreshToken)
        {
            using (HttpContent content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "refresh_token"),
                new KeyValuePair<string, string>("client_id", _clientId),
                new KeyValuePair<string, string>("client_secret", _secretId),
                new KeyValuePair<string, string>("refresh_token", refreshToken)
            }))
            {
                HttpResponseMessage result = await _client.PostAsync("oauth/refresh", content).ConfigureAwait(false);
                if (result.IsSuccessStatusCode)
                {
                    string response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                    RefreshTokenResponse tokenObj = JsonConvert.DeserializeObject<RefreshTokenResponse>(response);

                    AccessToken = tokenObj.access_token;
                    AccessTokenExpires = tokenObj.expires_in;

                    _client.DefaultRequestHeaders.Remove("Authorization");
                    _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {AccessToken}");
                }
                else
                {
                    string response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                    HandleError(result.StatusCode, response, true);
                }
            }
        }

        /// <summary>
        /// Obtain Access Token for the AdobeSign REST API (use only if you don't already have a Refresh Token, or if it is expired)
        /// </summary>
        /// <param name="authCode">Authorization code received from the authorization request</param>
        /// <param name="redirectUri">Redirect URI matching the one specified in the authorization request</param>
        /// <returns></returns>
        public async Task Authorize(string authCode, string redirectUri)
        {
            using (HttpContent content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
                new KeyValuePair<string, string>("client_id", _clientId),
                new KeyValuePair<string, string>("client_secret", _secretId),
                new KeyValuePair<string, string>("code", authCode),
                new KeyValuePair<string, string>("redirect_uri", redirectUri)
            }))
            {
                HttpResponseMessage result = await _client.PostAsync("oauth/token", content).ConfigureAwait(false);
                if (result.IsSuccessStatusCode)
                {
                    string response = await result.Content.ReadAsStringAsync();
                    TokenResponse tokenObj = JsonConvert.DeserializeObject<TokenResponse>(response);

                    AccessToken = tokenObj.access_token;
                    AccessTokenExpires = tokenObj.expires_in;
                    RefreshToken = tokenObj.refresh_token;

                    _client.DefaultRequestHeaders.Remove("Authorization");
                    _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {AccessToken}");
                }
                else
                {
                    string response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                    HandleError(result.StatusCode, response, true);
                }
            }
        }

        /// <summary>
        /// Uploads a document and obtains the document's ID to use in an Agreement.
        /// </summary>
        /// <param name="fileName">The name for the Transient Document</param>
        /// <param name="file">The document file</param>
        /// <param name="mimeType">(Optional) The mime type for the document</param>
        /// <returns>Returns the uploaded document ID</returns>
        public async Task<TransientDocument> UploadTransientDocument(string fileName, byte[] file, string mimeType = null)
        {
            using (MultipartFormDataContent content = new MultipartFormDataContent())
            {
                content.Add(new StreamContent(new MemoryStream(file)), "File", "sample.pdf");
                content.Add(new StringContent(fileName), "File-Name");

                if (mimeType != null)
                    content.Add(new StringContent(mimeType), "Mime-Type");

                HttpResponseMessage result = await _client.PostAsync(_apiEndpointVer + "/transientDocuments", content);
                if (result.IsSuccessStatusCode)
                {
                    string response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                    TransientDocument document = JsonConvert.DeserializeObject<TransientDocument>(response);

                    return document;
                }
                else
                {
                    string response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                    HandleError(result.StatusCode, response);

                    return null;
                }
            }
        }

        /// <summary>
        /// Creates an agreement. Sends it out for signatures, and returns the agreementID in the response to the client
        /// </summary>
        /// <param name="newAgreement">Information about the agreement</param>
        /// <returns>AgreementCreationResponse</returns>
        public async Task<AgreementCreationResponse> CreateAgreement(AgreementMinimalRequest newAgreement)
        {
            string serializedObject = JsonConvert.SerializeObject(newAgreement);

            using (StringContent content = new StringContent(serializedObject, Encoding.UTF8))
            {
                content.Headers.Remove("Content-Type");
                content.Headers.Add("Content-Type", "application/json");

                HttpResponseMessage result = await _client.PostAsync(_apiEndpointVer + "/agreements", content).ConfigureAwait(false);
                if (result.IsSuccessStatusCode)
                {
                    string response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                    AgreementCreationResponse agreement = JsonConvert.DeserializeObject<AgreementCreationResponse>(response);

                    return agreement;
                }
                else
                {
                    string response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                    HandleError(result.StatusCode, response);

                    return null;
                }
            }
        }
        private void HandleError(HttpStatusCode statusCode, string response, bool isOAuthError = false)
        {
            switch (statusCode)
            {
                case HttpStatusCode.Unauthorized:
                    AdobeSignError error = JsonConvert.DeserializeObject<AdobeSignError>(response);
                    throw new AdobeSignOAuthException(error);
                case HttpStatusCode.BadRequest:
                    if (!isOAuthError) // AdobeSign returns different json for oAuth calls
                    {
                        AdobeSignErrorCode errorCode = JsonConvert.DeserializeObject<AdobeSignErrorCode>(response);
                        throw new AdobeSignBadRequestException(errorCode);
                    }
                    else
                    {
                        AdobeSignError oAuthError = JsonConvert.DeserializeObject<AdobeSignError>(response);
                        throw new AdobeSignOAuthException(oAuthError);
                    }
                default:
                    AdobeSignErrorCode defaultError = JsonConvert.DeserializeObject<AdobeSignErrorCode>(response);
                    throw new AdobeSignBadRequestException(defaultError);
            }
        }
    }
}
