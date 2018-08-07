using System.Threading;
using TechTalk.SpecFlow;

namespace Framework.Steps.Actions
{
    [Binding]
    public class Common
    {
        [Given(@"User waits (.*) seconds")]
        [When(@"User waits (.*) seconds")]
        public void UserWaitsSeconds(int seconds)
        {
            // Replace later
            Thread.Sleep(seconds * 1000);
        }
    }
}
