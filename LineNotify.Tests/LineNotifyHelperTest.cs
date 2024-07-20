using Microsoft.Extensions.Configuration;
using System.Net;

namespace LineNotify.Tests
{
    [TestClass]
    public class LineNotifyHelperTest
    {
        private readonly IConfiguration _configuration;

        public LineNotifyHelperTest()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            _configuration = builder.Build();
        }

        [TestMethod]
        public async Task SendLogNotify_Success()
        {
            await LineNotifyHelper.SendLogNotifyAsync("LogAccessToken");
        }

        [TestMethod]
        public async Task SendAlertNotify_Success()
        {
            await LineNotifyHelper.SendAlertNotifyAsync("AlertAccessToken");
        }

        [TestMethod]
        public async Task SendErrorNotify_Success()
        {
            await LineNotifyHelper.SendErrorNotifyAsync("ErrorAccessToken");
        }

        [TestMethod]
        public async Task SendSuccessNotify_Success()
        {
            await LineNotifyHelper.SendSuccessNotifyAsync("SuccessAccessToken");
        }
    }
}