using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace LineNotify.Tests.Web.Controllers
{
    public class NotifyController : Controller
    {
        private readonly IConfiguration Configuration;

        public NotifyController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendLogNotify(string logMessage)
        {
            await SendNotify("LogAccessToken", logMessage);
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> SendAlertNotify(string alertMessage)
        {
            await SendNotify("AlertAccessToken", alertMessage);
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> SendErrorNotify(string errorMessage)
        {
            await SendNotify("ErrorAccessToken", errorMessage);
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> SendSuccessNotify(string successMessage)
        {
            await SendNotify("SuccessAccessToken", successMessage);
            return View("Index");
        }

        private async Task SendNotify(string key, string message)
        {
            var accessToken = Configuration[key] ?? throw new Exception($"{key} is null.");
            await LineNotifyHelper.SendNotifyAsync(accessToken, message);
        }
    }
}
