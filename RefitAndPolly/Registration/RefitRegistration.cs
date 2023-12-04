using Polly.Extensions.Http;
using Polly;
using Refit;
using RefitAndPolly.Interface;

namespace RefitAndPolly.Registration
{
    public static class RefitRegistration
    {
        public static void RegisterRefit(this IServiceCollection services)
        {
            services.AddRefitClient<IAuthorService>().Configure();
        }

        public static void Configure(this IHttpClientBuilder httpClientBuilder)
        {
            httpClientBuilder.ConfigureHttpClient(option =>
            {
                option.BaseAddress = new Uri("https://localhost:7134//api");
            }).AddPolicyHandler(GetRetryPolicy());
        }
        static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.Forbidden)
                .WaitAndRetryAsync(2, retryAttempt => Func(retryAttempt));
        }

        private static TimeSpan Func(int retryAttempt)
        {
            Console.WriteLine($"Retring again {retryAttempt}");
            return TimeSpan.FromSeconds(Math.Pow(2, retryAttempt));
        }
    }
}
