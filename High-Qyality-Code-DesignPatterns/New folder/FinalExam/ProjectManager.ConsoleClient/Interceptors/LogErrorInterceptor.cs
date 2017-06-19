using Ninject.Extensions.Interception;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;
using System;

namespace ProjectManager.ConsoleClient.Interceptors
{
    public class LogErrorInterceptor : IInterceptor
    {
        private ILogger logger;

        public LogErrorInterceptor(ILogger logger)
        {
            this.logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (UserValidationException ex)
            {
                this.logger.Error(ex.Message);
            }
            catch (Exception ex)
            {
                this.logger.Error(ex.Message);
            }
        }
    }
}
