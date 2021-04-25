using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Nanoservices.Entities;
using Nanoservices.Infrastructure.Definitions;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace NanoservicesFunctionApp
{
    public class UpdateStock
    {
        private readonly ICheckOutService _checkoutService;
        public UpdateStock(ICheckOutService checkoutService)
        {
            _checkoutService = checkoutService;
        }

        [FunctionName("UpdateStock")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "put", Route = null)]
            HttpRequestMessage req, ILogger log)
        {
            string jsonContent = await req.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(jsonContent))
            {
                return new BadRequestErrorMessageResult("Invalid input.");
            }

            CartItem cartItem = JsonConvert.DeserializeObject<CartItem>(jsonContent);
            return new OkObjectResult(await _checkoutService.UpdateStock(cartItem));
        }
    }
}

