namespace ridalot2._0.Middleware
{
    using Microsoft.AspNetCore.Http;
    using System.Diagnostics;
    using System.Threading.Tasks;

    public class StatisticsMiddleware
    {
        private readonly RequestDelegate _next;

        public StatisticsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            string action = context.Request.Path;

            if (action.EndsWith(".css") || action.EndsWith(".jpg") || action.EndsWith(".png"))
            {
                // Call the next middleware in the pipeline
                await _next(context);

                // Return early
                return;
            }
            // Create a stopwatch to measure the elapsed time
            var stopwatch = new Stopwatch();
            stopwatch.Start();


            // Call the next middleware in the pipeline
            await _next(context);

            // Stop the stopwatch and record the elapsed time
            stopwatch.Stop();
            var elapsed = stopwatch.Elapsed;


            if (action == "/")
            {
                action = "/LoadProgram";
            }
            var message = $"{action} took {elapsed.TotalMilliseconds} milliseconds";
            using (StreamWriter writer = new StreamWriter("LoadTimeLog.txt", true))
            {
                await writer.WriteLineAsync(message);
                writer.Close();
            }
        }
    }

}
