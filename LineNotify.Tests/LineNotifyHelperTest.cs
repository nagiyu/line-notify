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
            await SendLogNotify("LogAccessToken");
        }

        [TestMethod]
        public async Task SendAlertNotify_Success()
        {
            await SendLogNotify("AlertAccessToken");
        }

        [TestMethod]
        public async Task SendErrorNotify_Success()
        {
            await SendLogNotify("ErrorAccessToken");
        }

        [TestMethod]
        public async Task SendSuccessNotify_Success()
        {
            await SendLogNotify("SuccessAccessToken");
        }

        private async Task SendLogNotify(string key)
        {
            var accessToken = _configuration[key] ?? throw new Exception($"{key} is null.");
            await LineNotifyHelper.SendNotifyAsync(accessToken, "Notify Test.");
        }
    }
}