using Castle.DynamicProxy;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Serilog;

namespace ridalot2._0.Data.RIDALOT
{
    public class ExceptionInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            
            try
            {
                string messsage;
                invocation.Proceed();

                var str = ($"Method {invocation.Method.Name} " +
                    $"called with these parameters: {JsonConvert.SerializeObject(invocation.Arguments)}" +
                    $"returned this response: {JsonConvert.SerializeObject(invocation.ReturnValue)}");
                //Console.WriteLine(str);
              
            }
            catch (Exception ex)
            {
                
                var str1= ($"Error happened in method: {invocation.Method}. Error: {JsonConvert.SerializeObject(ex)}");
                ErrorLog.LogError(ex);
                throw;
            }
        }
    }
}
