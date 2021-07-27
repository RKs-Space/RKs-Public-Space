using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Reflection;

namespace UserService.Middleware
{
    /*
    * Custom Middleware to Log all User Request Response details in file, such as :
    * Requested URI, Host, Port, Action Verb and Request Time and Request Processing Time
    */

    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly ILogger _logger;
        private readonly string _logFilePath;

        public LoggingMiddleware(RequestDelegate next)
        {
            //_next = next;
            //_logger = loggerFactory.CreateLogger<LoggingMiddleware>();
            _next = next;
            string folder = Assembly.GetExecutingAssembly().GetName().Name;
            var directory = Environment.CurrentDirectory;
            int position = directory.IndexOf(@"bin");
            // explicit handling for Test executions
            string rootpath = directory.Substring(0, position);
            if (rootpath.Contains(@"GoldGymAPI.Test"))
            {
                rootpath = rootpath.Replace(@"GoldGymAPI.Test", "");
            }
            if (!Directory.Exists(Path.Combine(rootpath, folder)))
            {
                Directory.CreateDirectory(Path.Combine(rootpath, folder));
            }
            _logFilePath = Path.Combine(rootpath, $"{folder}/UserLogFile.txt");
            if (!File.Exists(_logFilePath))
            {
                File.Create(_logFilePath);
            }
        }

        public async Task Invoke(HttpContext context)
        {
            var sw = new Stopwatch();
            try
            {
                sw.Start();
                await _next(context);
                sw.Stop();
            }
            catch (Exception ex)
            {
                string content = $"Exception Occurred: {ex}";
                File.AppendAllText(_logFilePath, content);
            }
            finally
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine($"Request Incoming Time: ${DateTime.Now}");
                stringBuilder.AppendLine($"Processing Time: {sw.Elapsed}");
                stringBuilder.AppendLine($"Host: localhost");
                stringBuilder.AppendLine($"Port: {context.Request.Host.Port}");
                stringBuilder.AppendLine($"URI: {context.Request.Path}");
                stringBuilder.AppendLine($"Method: {context.Request.Method}");
                stringBuilder.AppendLine($"Status: {context.Response.StatusCode}");
                File.AppendAllText(_logFilePath, stringBuilder.ToString());

                
            }
        }
    }
}
