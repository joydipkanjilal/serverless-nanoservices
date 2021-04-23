using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Nanoservices.Infrastructure.Definitions;
using Newtonsoft.Json;

namespace Auth0ServerlessNanoserviceDemo
{
    public class GetAllProducts
    {
        private readonly ICheckOutService _checkoutService;
        public GetAllProducts(ICheckOutService checkoutService)
        {
            _checkoutService = checkoutService;
        }
        [FunctionName("GetAllProducts")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]
            HttpRequest req, ILogger log)
        {
            return new OkObjectResult(await _checkoutService.GetAllProducts());
        }
    }
}

