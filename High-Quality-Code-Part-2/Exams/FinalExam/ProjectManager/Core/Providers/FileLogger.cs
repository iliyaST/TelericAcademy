using log4net;
using Pesho.Core.Contracts;

namespace ProjectManager.Common
{
    public class FileLogger : IFileLogger
    {
        private ILog log;

        public FileLogger()
        {
            this.log = LogManager.GetLogger(typeof(FileLogger));
        }

        public void Info(string message)
        {
            log.Info(message);
        }

        public void Error(string message)
        {
            log.Error(message);
        }

        public void Fatal(string message)
        {
            log.Fatal(message);
        }
    }
}
