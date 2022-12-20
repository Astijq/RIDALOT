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

        public async Task Invoke(HttpContext context)
        {
            // Create a stopwatch to measure the elapsed time
            var stopwatch = new Stopwatch();
            stopwatch.Start();


            // Call the next middleware in the pipeline
            await _next(context);

            // Stop the stopwatch and record the elapsed time
            stopwatch.Stop();
            var elapsed = stopwatch.Elapsed;

            // Log the elapsed time and the action name
            var action = context.Request.Path;
            if (action == "/")
            {
                action = "/LoadProgram";
            }
            var message = $"{action} took {elapsed.TotalMilliseconds} milliseconds";
            using (StreamWriter writer = new StreamWriter("LoadTimeLog.txt", true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }
    }

}
