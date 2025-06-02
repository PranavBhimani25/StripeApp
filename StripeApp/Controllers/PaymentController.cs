using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using Stripe.V2;

namespace StripeApp.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCheckoutSession(decimal amount)
        {
            var domain = "https://localhost:7034"; // Use your local or live domain

            // Stripe requires amount in paisa (1 INR = 100 paisa)
            long stripeAmount = (long)(amount * 100);

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = stripeAmount, // $50.00
                            Currency = "inr",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = "Test Product (INR)",
                            },
                        },
                        Quantity = 1,
                    },
                },
                Mode = "payment",
                SuccessUrl = domain + "/Payment/Success",
                CancelUrl = domain + "/Payment/Cancel",
            };

            var service = new SessionService();
            Session session = service.Create(options);

            return Redirect(session.Url);
        }

        public IActionResult Success() =>View();
        public IActionResult Cancel() => View();

    }
}

