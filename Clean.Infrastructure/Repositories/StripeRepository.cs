using Clean.Application;
using Clean.Application.Dtos;
using Clean.Application.Dtos.Stripe;
using Clean.Application.Interface;
using Newtonsoft.Json;
using Stripe;
using Stripe.BillingPortal;
using Stripe.Checkout;

namespace Clean.Infrastructure.Repositories
{

    public class StripeRepository : IStripeRepository
    {


        public async Task<ResponseDto> CheckOutSessionAsync(string priceId, int quantity)
        {
            var response = new ResponseDto();
            try
            {
                // Set Stripe API key (better to set this once during application startup)
                StripeConfiguration.ApiKey = "sk_test_51N2XwECTIdeS2WufO7o4OXZ4NztBtiLaODpvtjgROviDokgn3itCniC0p5ILrLjUNVDplHIK9U4jvr1mvdMnw5P3008qCAASyL";

                var options = new Stripe.Checkout.SessionCreateOptions
                {
                    SuccessUrl = "http://localhost:4200/",
                    CancelUrl = "http://localhost:4200/",
                    PaymentMethodTypes = new List<string>
                    {
                        "card",
                    },
                    LineItems = new List<SessionLineItemOptions>
                    {
                        new SessionLineItemOptions
                        {
                            //PriceData = new SessionLineItemPriceDataOptions
                            //{
                            //    Currency = "usd",
                            //    UnitAmount = unitAmount*100,
                            //    ProductData = new SessionLineItemPriceDataProductDataOptions
                            //    {
                            //        Name = "Test Product",
                            //        Description = "Test Price Description",
                            //    },
                            //},
                            //Price="price_1OJw3XCTIdeS2Wuf0VmVbm1g",
                            Price=priceId,
                            Quantity = quantity, // You might want to adjust this based on your requirements,

                        },


                    },
                    Mode = "subscription",
                    ClientReferenceId = "1",

                };

                // Create a new session
                var service = new Stripe.Checkout.SessionService();
                var session = await service.CreateAsync(options);

                var url = session.Url;
                response.Data = url;
                response.Status = true;
                response.Message = "User Adedd SuccessFully";
            }
            catch (Exception ex)
            {
                response.Message = ex.InnerException?.Message;
            }
            return response;
        }
        public async Task<ResponseDto> StripeWebhook(string requestBody)
        {
            var response = new ResponseDto();
            try
            {
                DeserializeStripeDTO myDeserializedClass = JsonConvert.DeserializeObject<DeserializeStripeDTO>(requestBody);
                int id = int.Parse(myDeserializedClass.data.@object.client_reference_id);
                var customerId = myDeserializedClass.data.@object.customer;
                response.Data = customerId;
                response.Status = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.InnerException?.Message ?? ex.Message;
            }
            return response;
        }

    }
}

