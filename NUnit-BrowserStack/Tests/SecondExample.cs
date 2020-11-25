using NUnit.Framework;
using OpenQA.Selenium;

namespace BrowserStack
{
    [TestFixture("chrome")]
    //[TestFixture("firefox")]
    //[TestFixture("safari")]
    [TestFixture("ie")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class SecondExample : BrowserStackNUnitTest
    {
        public SecondExample(string environment) : base(environment) { }

        [Test]
        public void SearchGoogleSecond()
        {
            driver.Navigate().GoToUrl("https://www.google.com/ncr");
            IWebElement query = driver.FindElement(By.Name("q"));
            query.SendKeys("BrowserStack");
            query.Submit();
            System.Threading.Thread.Sleep(5000);
            Assert.AreEqual("BrowserStack - Google Search", driver.Title);
        }

        [Test]
        public void SearchJeevesSecond()
        {
            driver.Navigate().GoToUrl("https://uk.ask.com/");
            IWebElement query = driver.FindElement(By.Name("q"));
            query.SendKeys("BrowserStack");
            query.Submit();
            System.Threading.Thread.Sleep(5000);
            Assert.AreEqual("BrowserStack, , Ask", driver.Title);
        }
    }
}
