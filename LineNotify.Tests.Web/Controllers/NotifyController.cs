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
            await LineNotifyHelper.SendLogNotifyAsync(logMessage);
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> SendAlertNotify(string alertMessage)
        {
            await LineNotifyHelper.SendAlertNotifyAsync(alertMessage);
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> SendErrorNotify(string errorMessage)
        {
            await LineNotifyHelper.SendErrorNotifyAsync(errorMessage);
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> SendSuccessNotify(string successMessage)
        {
            await LineNotifyHelper.SendSuccessNotifyAsync(successMessage);
            return View("Index");
        }
    }
}
