using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using Secret;

namespace LineNotify
{
    public class LineNotifyHelper
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task SendLogNotifyAsync(string message)
        {
            var accessToken = await SecretHelper.GetSecret("LogAccessToken");
            await SendNotifyAsync(accessToken, message);
        }

        public static async Task SendAlertNotifyAsync(string message)
        {
            var accessToken = await SecretHelper.GetSecret("AlertAccessToken");
            await SendNotifyAsync(accessToken, message);
        }

        public static async Task SendErrorNotifyAsync(string message)
        {
            var accessToken = await SecretHelper.GetSecret("ErrorAccessToken");
            await SendNotifyAsync(accessToken, message);
        }

        public static async Task SendSuccessNotifyAsync(string message)
        {
            var accessToken = await SecretHelper.GetSecret("SuccessAccessToken");
            await SendNotifyAsync(accessToken, message);
        }

        private static async Task SendNotifyAsync(string accessToken, string message)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "https://notify-api.line.me/api/notify");

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var content = new FormUrlEncodedContent(
                new[] {
                    new KeyValuePair<string, string>("message", $"\n{message}")
                });

            request.Content = content;

            try
            {
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

    }
}
