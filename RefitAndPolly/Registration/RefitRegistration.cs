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
            });
        }
    }
}
