using System.IO;
using System.Security.Cryptography;
using AdobeSignRESTClient;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AdobeSignRESTClient.Models;
using Microsoft.AspNetCore.Http;

namespace AdobeSignApi.Controllers
{
    [Produces("application/json")]
    [Route("api/AdobeSign")]
    public class AdobeSignController : Controller
    {
        private static AdobeSignREST client;
        public AdobeSignController()
        {
            client = new AdobeSignREST("https://api.eu1.echosign.com", "CBJCHBCAABAAShWitqkQgjhBRXFQH7zuOHJsdG-Vi4GS", "PZaD8TnKTzl0XSwdF6orBzGbPx6OcBwr");
        }
        
        // GET api/AdobeSign/RefreshToken
        [HttpGet("RefreshToken")]
        public async Task RefreshTokenAsync()
        {
            await client.Authorize("3AAABLblqZhCStO97dFLfaAcb-wctwWu-DlCLG5QzyTlNXPxgwUsmxUsAFX6EXdAQgfY-pSG_EtA*");
        }

        //string filename, byte[] file, string mimeType = null
        [HttpGet("TransientDocument")]
        public async Task TransientDocument()
        {
            await this.RefreshTokenAsync().ConfigureAwait(true);
            byte[] file = System.IO.File.ReadAllBytes(@"C:\Liviu\Dev\DocumentFull1.pdf");
            string fileName = "DocumentFull1.pdf";
            var transientDocument = client.UploadTransientDocument(fileName, file);
        }

        [HttpPost("PostTransientDocument")]
        public async Task<TransientDocument> PostTransientDocument(IFormFile file, string fileName)
        {
            var fileStream=file.OpenReadStream();
            byte[] fileByte;

            using (BinaryReader br = new BinaryReader(fileStream))
            {
                fileByte = br.ReadBytes((int)fileStream.Length);
            }
            await this.RefreshTokenAsync().ConfigureAwait(true);
            var transientDocument = client.UploadTransientDocument(fileName, fileByte).Result;
            return transientDocument;
        }

        [HttpPost("CreateAgreement")]
        public async Task<AgreementCreationResponse> CreateAgreement([FromBody]AgreementMinimalRequest agreement)
        {
            await this.RefreshTokenAsync().ConfigureAwait(true);
            var response = client.CreateAgreement(agreement).Result;

            return response;
            //client.CreateAgreement();
        }

        [HttpGet("GetAgreementSigningUrl")]
        public async Task<SigningUrlResponse> GetAgreementSigningUrl([FromQuery]string agreementId)
        {
            await this.RefreshTokenAsync().ConfigureAwait(true);
            var response = client.GetAgreementSigningUrl(agreementId).Result;

            return response;
            //client.CreateAgreement();
        }

        [HttpGet("UpdateAgreementStatus")]
        public ActionResult UpdateAgreementStatus()
        {

            var clientid = Request.Headers["X-ADOBESIGN-CLIENTID"];
            if (clientid== "CBJCHBCAABAAShWitqkQgjhBRXFQH7zuOHJsdG-Vi4GS")
                return Json( new { xAdobeSignClientId = "PZaD8TnKTzl0XSwdF6orBzGbPx6OcBwr" });
            else
            {
                return new BadRequestResult();
            }
        }
        //[HttpPost("UpdateAgreementStatus")]
        //public async Task<string> UpdateAgreementStatus()
        //{

        //}
    }
}