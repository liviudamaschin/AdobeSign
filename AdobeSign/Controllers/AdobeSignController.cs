using AdobeSignRESTClient;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
            await client.Authorize("3AAABLblqZhBxMxOnKyfDBztQtFkarYqrc51rJaiaftOV-EvlZmBSomrYHgowSGDeTwiZlObeSJU*");
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

        [HttpGet("CreateAgreement")]
        public async Task CreateAgreement(string transientDocumentId)
        {
            await this.RefreshTokenAsync().ConfigureAwait(true);
            //client.CreateAgreement();
        }
    }
}