using NCollaborate.Session;
using NUnit.Framework;

namespace Samples.NUnitIntegration
{
    public class NUnitTestSession : ITestSession
    {
        public string GetCurrentExecutingTestName()
        {
            return TestContext.CurrentContext.Test.Name;
        }
    }
}
