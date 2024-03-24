using Clean.Application.Dtos;
using Clean.Application.Interface;

namespace Clean.Application.Services.Stripes
{
    public class StripeService : IStripeService
    {
        private readonly IStripeRepository stripeRepository;

        public StripeService(IStripeRepository stripeRepository)
        {
            this.stripeRepository = stripeRepository;
        }
  
        public async Task<ResponseDto> CheckOutSessionAsync(string priceId, int quantity)
        {
           return await this.stripeRepository.CheckOutSessionAsync(priceId,quantity);
        }
        public async Task<ResponseDto> StripeWebhook(string requestBody)
        {
            return await this.stripeRepository.StripeWebhook(requestBody);
        }
    }
}
