using Microsoft.AspNetCore.Mvc;

namespace LineNotify.Tests.Web.Controllers
{
    public class NotifyController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendLogNotify(string logMessage)
        {
            // ここにログ通知のロジックを追加
            ViewBag.LogMessage = logMessage;
            return View("Index");
        }

        [HttpPost]
        public IActionResult SendAlertNotify(string alertMessage)
        {
            // ここにアラート通知のロジックを追加
            ViewBag.AlertMessage = alertMessage;
            return View("Index");
        }

        [HttpPost]
        public IActionResult SendErrorNotify(string errorMessage)
        {
            // ここにエラーメッセージのロジックを追加
            ViewBag.ErrorMessage = errorMessage;
            return View("Index");
        }

        [HttpPost]
        public IActionResult SendSuccessNotify(string successMessage)
        {
            // ここに成功メッセージのロジックを追加
            ViewBag.SuccessMessage = successMessage;
            return View("Index");
        }
    }
}
