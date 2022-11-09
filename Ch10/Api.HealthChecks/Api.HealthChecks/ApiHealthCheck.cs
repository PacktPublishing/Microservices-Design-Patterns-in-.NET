using Microsoft.Extensions.Diagnostics.HealthChecks;

public class HealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        var healthy = true;
        if (healthy)
        {
            // additional custom logic when the health is confirmed.
            return Task.FromResult(
                HealthCheckResult.Healthy("Service is healthy"));
        }

        // additional custom logic when the api is not healthy 
        return Task.FromResult(
            new HealthCheckResult(
                context.Registration.FailureStatus, "Service is unhealthy"));
    }
}
