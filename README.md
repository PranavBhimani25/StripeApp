# 💳 Stripe Payment Integration - ASP.NET Core MVC
---
COMPANY: CODTECH IT SOLUTIONS
---
NAME: Pranav Bhimani
---

INTERN ID: CT04DM1485
---

DOMAIN: .Net 
---

DURATION: 4 WEEEKS
---

MENTOR: VAISHALI
---

A comprehensive demo project showcasing **Stripe payment gateway integration** with **ASP.NET Core MVC**. Features dynamic pricing, INR currency support, and a clean Bootstrap UI - all running in **test mode** for safe development and learning.

> ⚠️ **Test Mode Only** - No real transactions are processed. Safe for development and demonstration purposes.

---

## ✨ Features

- 💰 **Dynamic Payment Amounts** - Users can enter custom payment amounts
- 🇮🇳 **INR Currency Support** - Built for Indian Rupee transactions
- 🎨 **Modern UI** - Clean, responsive Bootstrap 5 interface
- 🔒 **Secure Integration** - Follows Stripe best practices
- 📱 **Mobile Responsive** - Works seamlessly across all devices
- ✅ **Success/Cancel Handling** - Proper redirect flow management
- 📄 **Privacy Compliant** - Includes privacy policy page

---

## 🛠️ Tech Stack

| Technology | Version | Purpose |
|------------|---------|---------|
| ASP.NET Core MVC | .NET 6+ | Web Framework |
| Stripe.NET SDK | Latest | Payment Processing |
| Bootstrap | 5.x | UI Framework |
| C# | 10+ | Backend Language |
| Razor Views | - | Template Engine |

---

## 🚀 Quick Start

### Prerequisites
- .NET 6 SDK or higher
- Visual Studio 2022 or VS Code
- Stripe test account (free)

### 1. Clone & Setup
```bash
# Clone the repository
git clone https://github.com/yourusername/stripe-aspnet-demo.git
cd stripe-aspnet-demo

# Restore dependencies
dotnet restore
```

### 2. Install Stripe Package
```bash
dotnet add package Stripe.net
```

### 3. Configure Stripe Keys
Add your Stripe test keys to `appsettings.json`:
```json
{
  "Stripe": {
    "SecretKey": "sk_test_your_secret_key_here",
    "PublishableKey": "pk_test_your_publishable_key_here"
  }
}
```

**🔑 Get Your Keys:**
1. Sign up at [Stripe Dashboard](https://dashboard.stripe.com)
2. Navigate to **Developers → API Keys**
3. Copy your **test mode** keys (they start with `sk_test_` and `pk_test_`)

### 4. Run the Application
```bash
dotnet run
```

Navigate to: `https://localhost:5001/Payment`

---

## 💳 Testing Payments

Use these **Stripe test cards** for different scenarios:

| Card Number | Brand | Outcome |
|-------------|-------|---------|
| `4242 4242 4242 4242` | Visa | ✅ Success |
| `4000 0000 0000 0002` | Visa | ❌ Declined |
| `4000 0000 0000 9995` | Visa | ⚠️ Insufficient Funds |

**Test Data:**
- **Expiry:** Any future date (e.g., `12/25`)
- **CVC:** Any 3-digit number (e.g., `123`)
- **ZIP:** Any 5-digit code (e.g., `12345`)

---

## 📁 Project Structure

```
stripe-aspnet-demo/
├── Controllers/
│   ├── PaymentController.cs    # Stripe payment logic
│   └── HomeController.cs       # Home & privacy pages
├── Views/
│   ├── Payment/
│   │   ├── Index.cshtml        # Payment form
│   │   ├── Success.cshtml      # Success page
│   │   └── Cancel.cshtml       # Cancel page
│   ├── Home/
│   │   ├── Index.cshtml        # Homepage
│   │   └── Privacy.cshtml      # Privacy policy
│   └── Shared/
│       └── _Layout.cshtml      # Main layout
├── wwwroot/
│   ├── css/                    # Custom styles
│   ├── js/                     # JavaScript files
│   └── lib/                    # Bootstrap & dependencies
├── appsettings.json            # Configuration
├── Program.cs                  # App startup
└── README.md                   # This file
```

---

## 🔧 Key Implementation Details

### Payment Controller
```csharp
[HttpPost]
public async Task<IActionResult> CreateCheckoutSession(decimal amount)
{
    var options = new SessionCreateOptions
    {
        PaymentMethodTypes = new List<string> { "card" },
        LineItems = new List<SessionLineItemOptions>
        {
            new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmount = (long)(amount * 100), // Convert to paise
                    Currency = "inr",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = "Payment Demo"
                    }
                },
                Quantity = 1
            }
        },
        Mode = "payment",
        SuccessUrl = Url.Action("Success", "Payment", null, Request.Scheme),
        CancelUrl = Url.Action("Cancel", "Payment", null, Request.Scheme)
    };
    
    var service = new SessionService();
    var session = await service.CreateAsync(options);
    
    return Redirect(session.Url);
}
```

---

## 🔒 Security & Privacy

- 🛡️ **Test Mode Only** - No real money is processed
- 🔐 **Secure Key Management** - API keys should be stored in environment variables for production
- 📊 **No Data Storage** - This demo doesn't store payment information
- 🕒 **Session-Based** - Uses Stripe's hosted checkout for security

### Production Deployment Checklist
- [ ] Move API keys to environment variables
- [ ] Enable HTTPS enforcement
- [ ] Add webhook endpoint validation
- [ ] Implement proper error handling
- [ ] Add logging and monitoring

---

## 🤝 Contributing

1. Fork the project
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

---

## 📞 Support & Contact

**Pranav Bhimani**
- 📧 Email: [your-email@gmail.com](mailto:your-email@gmail.com)
- 💼 LinkedIn: [Your LinkedIn Profile](https://linkedin.com/in/yourprofile)
- 🐙 GitHub: [@yourusername](https://github.com/yourusername)

---

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

## 🙏 Acknowledgments

- [Stripe Documentation](https://stripe.com/docs) for excellent payment integration guides
- [ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core) for framework guidance
- [Bootstrap](https://getbootstrap.com) for the responsive UI components

---

## 📸 Screenshots

*Coming soon - Add screenshots of your payment flow here*


![Payment Form](https://github.com/PranavBhimani25/StripeApp/blob/00e9e1d6d5cbdab763a64e3d74e8b3bead0a473e/StripeApp/wwwroot/Images/Screenshot%202025-06-03%20001236.png)
![Payment Form](https://github.com/PranavBhimani25/StripeApp/blob/00e9e1d6d5cbdab763a64e3d74e8b3bead0a473e/StripeApp/wwwroot/Images/Screenshot%202025-06-03%20001301.png)
![Stripe Checkout](https://github.com/PranavBhimani25/StripeApp/blob/00e9e1d6d5cbdab763a64e3d74e8b3bead0a473e/StripeApp/wwwroot/Images/Screenshot%202025-06-03%20001339.png)
![Success Page](https://github.com/PranavBhimani25/StripeApp/blob/00e9e1d6d5cbdab763a64e3d74e8b3bead0a473e/StripeApp/wwwroot/Images/Screenshot%202025-06-03%20001400.png)

---

<div align="center">

**⭐ Star this repo if it helped you learn Stripe integration!**

Made with ❤️ for the developer community

</div>
