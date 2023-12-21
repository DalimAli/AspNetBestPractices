# .Net Best Practices

## Rate Limiting
## Calling API using Refit
## Retry Policy using Polly
## Global Exception Handle using AddExceptionHandler middleware to handle unexpected request exceptions.

# Rate Limiting using Microsoft.AspNetCore.RateLimiting #
applying rate limit on api call using built-in rate limiter. Here I'm using fix rate limiter to control api call. you can also pertition for user specific. 
other 3 rate limiter also available. [for more info click me](https://learn.microsoft.com/en-us/aspnet/core/performance/rate-limit?view=aspnetcore-8.0)

# Refit #
Refit is a popular library that allows us to interact with any HTTP-based Rest API using interfaces. The concept is simple; instead of using an HTTP client, we define an interface that represents the API we want to interact with. Refit acts as a wrapper around the interface methods and handles HTTP requests and serializes response data to the type given in the interface. You can apply the Headers attribute to the interface itself.

# Polly #
Polly is a .NET library that provides resilience and transient-fault handling capabilities. You can implement those capabilities by applying Polly policies such as Retry, Circuit Breaker, Bulkhead Isolation, Timeout, and Fallback. [More](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/implement-http-call-retries-exponential-backoff-polly) 

# ExceptionHandler middleware #
when a violation of a business rule occurs, we raise a custom exception to handle the situation. A custom exception is an exception that is specifically created to address unique scenarios in our application. [More](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/error-handling?view=aspnetcore-8.0)
