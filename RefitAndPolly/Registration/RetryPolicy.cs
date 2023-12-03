using Polly.Extensions.Http;
using Polly;
using RefitAndPolly.Interface;
using System.Net;
using RefitAndPolly.Service;

namespace RefitAndPolly.RetryPolicy
{
    public static class RetryPolicy
    {
        internal static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == HttpStatusCode.NotFound 
                            || msg.StatusCode == HttpStatusCode.Forbidden
                            || msg.StatusCode == HttpStatusCode.ServiceUnavailable)
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }

        public static void RegisterPolly(this IServiceCollection services)
        {
            services.AddHttpClient<IAuthorService, AuthorService>()
                    .SetHandlerLifetime(TimeSpan.FromMinutes(5))  //Set lifetime to five minutes
                    .AddPolicyHandler(GetRetryPolicy());
        }
    }
}
