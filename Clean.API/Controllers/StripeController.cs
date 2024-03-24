using Clean.Application.Dtos;
using Clean.Application.Services.Stripes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Stripe;

namespace Clean.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripeController : Controller
    {
        private readonly IStripeService stripeService;

        public StripeController(IStripeService stripeService)
        {
            this.stripeService = stripeService;
        }
        
        [HttpPost("checkout")]
        public async Task<ResponseDto> CheckOutSessionAsync(string priceId, int quantity)
        {
            return await this.stripeService.CheckOutSessionAsync(priceId,quantity);
            
        }
        [HttpPost("completedWebhook")]
        public async Task<ResponseDto> StripeWebhook(string requestBody)
        {
            return await this.stripeService.StripeWebhook(requestBody);

        }

    }
}
