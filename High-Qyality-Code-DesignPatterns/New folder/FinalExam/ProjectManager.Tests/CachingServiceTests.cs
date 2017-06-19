using Moq;
using NUnit.Framework;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Services;
using System;
using System.Collections.Generic;

namespace ProjectManager.Tests
{
    [TestFixture]
    public class CachingServiceTests
    {
        [Test]
        public void Constructor_ShouldThrow_WhenTimeSpanIsUnderZero()
        {
            var dateProviderMocked = new Mock<IDateTimeProvider>();

            Assert.Throws<ArgumentOutOfRangeException>(
                () => new CachingService(new TimeSpan(-1, -1, -1),
                dateProviderMocked.Object));
        }

        [Test]
        public void Constructor_DoesNotThrow_WhenTimeSpanIsNotNegative()
        {
            var dateProviderMocked = new Mock<IDateTimeProvider>();

            Assert.DoesNotThrow(
                () => new CachingService(new TimeSpan(1, 1, 1),
                dateProviderMocked.Object));
        }

        [Test]
        public void GetCacheValue_ShouldAddCacheCorretcly()
        {
            var testClassName = "TestClass";
            var testMethodName = "TestMethod";
            var testObject = "Test object";

            var dateProviderMocked = new Mock<IDateTimeProvider>();
            var service = new CachingService(new TimeSpan(1, 1, 1),
                dateProviderMocked.Object);

            service.AddCacheValue(testClassName, testMethodName, testObject);

            var result = service.GetCacheValue(testClassName, testMethodName);

            Assert.IsTrue(result == "Test object");
        }

        [Test]
        public void GetCacheValue_ShouldReturnCorrectResult()
        {
            var testClassName = "TestClass";
            var testMethodName = "TestMethod";
            var testObject = "Test object";

            var dateProviderMocked = new Mock<IDateTimeProvider>();
            var service = new CachingService(new TimeSpan(1, 1, 1),
                dateProviderMocked.Object);

            service.AddCacheValue(testClassName, testMethodName, testObject);

            var result = service.GetCacheValue(testClassName, testMethodName);

            Assert.IsTrue(result == "Test object");
        }

        [Test]
        public void ResetCache_ShouldWorkCorretcly()
        {
            var testClassName = "TestClass";
            var testMethodName = "TestMethod";
            var testObject = "Test object";

            var dateProviderMocked = new Mock<IDateTimeProvider>();
            var service = new CachingService(new TimeSpan(1, 1, 1),
                dateProviderMocked.Object);

            service.AddCacheValue(testClassName, testMethodName, testObject);

            service.ResetCache();

            Assert.Throws<KeyNotFoundException>(() =>
            service.GetCacheValue(testClassName, testMethodName));
        }
    }
}
