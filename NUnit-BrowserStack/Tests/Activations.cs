using NUnit.Framework;
using OpenQA.Selenium;

namespace BrowserStack
{
    [TestFixture("chrome")]
    [TestFixture("firefox")]
    //[TestFixture("safari")]
    //[TestFixture("ie")]
    [TestFixture("local")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class Activations : BrowserStackNUnitTest
    {
        public Activations(string environment) : base(environment) { }

        [Test]
        public void SearchGoogle()
        {
            driver.Navigate().GoToUrl("https://www.google.com/ncr");
            IWebElement query = driver.FindElement(By.Name("q"));
            query.SendKeys("BrowserStack");
            query.Submit();
            System.Threading.Thread.Sleep(5000);
            Assert.AreEqual("BrowserStack - Google Search", driver.Title);
        }

        [Test]
        public void SearchJeeves()
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
