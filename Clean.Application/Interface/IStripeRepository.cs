using Clean.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Interface
{
    public interface IStripeRepository
    {
        Task<ResponseDto> CheckOutSessionAsync(string priceId, int quantity);
        Task<ResponseDto> StripeWebhook(string requestBody);
    }
}
