using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Nanoservices.Infrastructure.Definitions;
using System.Threading.Tasks;

namespace NanoservicesFunctionApp
{
    public class ItemAvailability
    {
        private readonly ICheckOutService _checkoutService;
        public ItemAvailability(ICheckOutService checkoutService)
        {
            _checkoutService = checkoutService;
        }

        [FunctionName("IsItemAvailable")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]
            HttpRequest req, ILogger log)
        {
            string productCode = req.Query["productcode"];
            return new OkObjectResult(await _checkoutService.IsItemAvailable(productCode));
        }
    }
}

