using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OrderFactory.Nacha.Parser.Data;

namespace OrderFactory.Nacha.Functions
{
    public class CheckDbConnections
    {
        private readonly IConfiguration _configuration;
        private readonly ISqlConnectionFactory _connectionFactory;

        public CheckDbConnections(ISqlConnectionFactory connectionFactory, IConfiguration configuration)
        {
            _connectionFactory = connectionFactory;
            _configuration = configuration;
        }

        [FunctionName("health-check")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)]
            HttpRequest req,
            ILogger log)
        {
            if (!_configuration.IsSettingEnabled("EnableHealthChecks"))
                return new OkObjectResult("Please set EnableHealthChecks to \"true\" to see the results.");

            var (isHealthy, statusString) = await _connectionFactory.ConnectionStatus();
            if (!isHealthy) log.LogError("Health check failed: {statusString}", statusString);

            var sb = new StringBuilder();
            sb.AppendLine($"{statusString}\r\n");

            AppendForwardedFor(req, sb);

            return new OkObjectResult(sb.ToString());
        }

        private static void AppendForwardedFor(HttpRequest req, StringBuilder sb)
        {
            if (!req.Headers.TryGetValue("X-Forwarded-For", out var values)) return;
            sb.AppendLine("\r\nX-Forwarded-For:");
            foreach (var stringValue in values) sb.Append(stringValue);
        }
    }
}