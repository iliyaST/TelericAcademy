using System;
using System.Collections.Generic;

using Bytes2you.Validation;
using ProjectManager.Framework.Core.Common.Contracts;

namespace ProjectManager.Framework.Services
{
    public class CachingService : ICachingService
    {
        private readonly TimeSpan duration;
        private DateTime timeExpiring;
        private IDictionary<string, object> cache;
        private IDateTimeProvider timeProvider;

        public CachingService(TimeSpan duration, IDateTimeProvider timeProvider)
        {
            Guard.WhenArgument(duration, "duration").IsLessThan(TimeSpan.Zero).Throw();

            this.timeProvider = timeProvider;
            this.duration = duration;
            this.timeExpiring = timeProvider.GetDate();
            this.cache = new Dictionary<string, object>();
        }

        public void ResetCache()
        {
            this.cache = new Dictionary<string, object>();
            this.timeExpiring = this.timeProvider.GetDate() + this.duration;
        }

        public bool IsExpired
        {
            get
            {
                if (this.timeExpiring < this.timeProvider.GetDate())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public object GetCacheValue(string className, string methodName)
        {
            return this.cache[$"{className}.{methodName}"];
        }

        public void AddCacheValue(string className, string methodName, object value)
        {
            this.cache.Add($"{className}.{methodName}", value);
        }
    }
}
