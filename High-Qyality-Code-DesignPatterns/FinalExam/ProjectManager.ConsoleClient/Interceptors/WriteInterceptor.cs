using System;
using Ninject.Extensions.Interception;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;

namespace ProjectManager.ConsoleClient.Interceptors
{
    public class WriteInterceptor : IInterceptor
    {
        private IWriter writer;

        public WriteInterceptor(IWriter writer)
        {
            this.writer = writer;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
                this.writer.WriteLine(invocation.ReturnValue.ToString());
            }
            catch (UserValidationException ex)
            {
                this.writer.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                this.writer.WriteLine("Opps, something happened. Check the log file :(");
            }
        }
    }
}
