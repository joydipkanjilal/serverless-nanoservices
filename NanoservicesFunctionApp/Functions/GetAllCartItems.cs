using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Nanoservices.Infrastructure.Definitions;
using System.Threading.Tasks;

namespace NanoservicesFunctionApp
{
    public class GetAllCartItems
    {
        private readonly ICheckOutService _checkoutService;
        public GetAllCartItems(ICheckOutService checkoutService)
        {
            _checkoutService = checkoutService;
        }

        [FunctionName("GetAllCartItems")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]
            HttpRequest req, ILogger log)
        {
            return new OkObjectResult(await _checkoutService.GetAllCartItems());
        }
    }
}

