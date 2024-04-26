using System.Diagnostics;
using System.Text;
using ToDoList.Models;
using ToDoList.Repositories;
using ToDoList.Services;

namespace ToDoList.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;
        private readonly ILoggerRepository _loggerRepository; 

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger, ILoggerRepository loggerRepository)
        {
            _next = next;
            _logger = logger;
            _loggerRepository = loggerRepository;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();

                var requestBody = await ReadBodyOfRequestAsync(context);

                string requestBodyLog = string.IsNullOrEmpty(requestBody) ? "empty body" : requestBody;

                var remoteIpAddress = context.Connection.RemoteIpAddress == null ? "It is a TCP connection" : context.Connection.RemoteIpAddress.ToString();

                DateTime dateTime = DateTime.Now;

                _logger.LogInformation($"Request: {context.Request.Method} {context.Request.Path} from {remoteIpAddress} body: {requestBodyLog} at:{dateTime}");

                await _next(context);

                stopwatch.Stop();

                CreateRequestLogService createRequestLogService = new(); 

                RequestLog log = createRequestLogService.CreateLogRequest(context.Request.Method, context.Request.Path, remoteIpAddress, dateTime,
                    context.Response.StatusCode, stopwatch.ElapsedMilliseconds); 

                _logger.LogInformation($"Response: {context.Response.StatusCode} in {stopwatch.ElapsedMilliseconds}ms");

                _loggerRepository.AddLog(log);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
                throw;
            }
        }

        private async Task<string> ReadBodyOfRequestAsync(HttpContext context)
        {
            try
            {
                context.Request.EnableBuffering();

                using var reader = new StreamReader(context.Request.Body, Encoding.UTF8, false, 1024, true);
                var requestBody = await reader.ReadToEndAsync();

                context.Request.Body.Position = 0;

                return requestBody;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading the body of the request: {ex.Message}");
                return string.Empty;
            }
        }
    }
}
