using Newtonsoft.Json;
using System.Text;

namespace AlgDataGateway.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<OperationResult<T>> DoPostAsync<T, T1>(this HttpClient client, string uri, T1 data)
           where T : class
        {
            var response = await client.PostAsJsonAsync(uri, data);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var result = JsonConvert.DeserializeObject<T>(responseContent);
                return OperationResult<T>.Ok(result);
            }
            else
            {
                var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var errorDetails = JsonConvert.DeserializeAnonymousType(responseContent, new { Code = "", Message = "" });
                return OperationResult<T>.Error(errorDetails.Code, errorDetails.Message);
            }
        }

        public class OperationResult<T>
        {
            public T Data { get; set; }
            public bool Success { get; set; }
            public string ErrorMessage { get; set; }
            public string ErrorCode { get; set; }

            public static OperationResult<T> Ok(T data)
            {
                return new OperationResult<T>
                {
                    Data = data,
                    Success = true
                };
            }

            public static OperationResult<T> Error(string code, string message)
            {
                return new OperationResult<T>
                {
                    Success = false,
                    ErrorCode = code,
                    ErrorMessage = message
                };
            }
        }
    }
}