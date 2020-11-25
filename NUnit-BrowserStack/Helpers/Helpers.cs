using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SingleTest.Helpers
{
    static internal class Helpers
    {
        static internal By FindElementByDataTestID(string dataTestID)
        {
            return By.XPath("//*[@data-test-id=\"" + dataTestID + "\"]");
        }

        static internal By FindRadioButtonOptionByDataTestID(string dataTestID, YesNo yesNo)
        {
            int answerAsInt = (int)yesNo;

            return By.XPath("//*[@data-test-id=\"" + dataTestID + "\"]" + "/div/span[" + answerAsInt + "]/label");
        }

        static internal By FindStackedRadioButtonOptionByDataTestID(string dataTestID, int itemNumber)
        {
            return By.XPath("//*[@data-test-id=\"" + dataTestID + "\"]" + "/div[" + itemNumber + "]/span/label");
        }
    }

    internal class CaptureHelpers
    {
        IWebDriver _driver;

        internal CaptureHelpers(IWebDriver driver)
        {
            _driver = driver;
        }

        internal void CaptureDropDown(string elementID, string visibleValue)
        {
            SelectElement element = new SelectElement(_driver.FindElement(Helpers.FindElementByDataTestID(elementID)));

            element.SelectByText(visibleValue);
        }

        internal void CaptureJurisdiction(string elementID, Jurisdiction jurisdiction)
        {
            int jurisdictionAsInt = (int)jurisdiction;
            IWebElement _selectedJurisdiction = _driver.FindElement(Helpers.FindStackedRadioButtonOptionByDataTestID(elementID, jurisdictionAsInt));
            _selectedJurisdiction.Click();
        }

        internal void CaptureYesNo(string elementID, YesNo yesNo)
        {
            IWebElement _selectedAnswer = _driver.FindElement(Helpers.FindRadioButtonOptionByDataTestID(elementID, yesNo));
            _selectedAnswer.Click();
        }

        internal void CaptureNumber(string elementID, int value)
        {
            IWebElement element = _driver.FindElement(Helpers.FindElementByDataTestID(elementID));
            element.SendKeys(value.ToString());
        }

        internal void CaptureText(string elementID, string value)
        {
            IWebElement element = _driver.FindElement(Helpers.FindElementByDataTestID(elementID));
            element.SendKeys(value);
        }

        internal void ClickButton(string elementID)
        {
            IWebElement element = _driver.FindElement(Helpers.FindElementByDataTestID(elementID));
            element.Click();
        }

        internal string GrabTextFromElement(string elementID)
        {
            IWebElement element = _driver.FindElement(Helpers.FindElementByDataTestID(elementID));
            return element.Text;

        }
    }

    internal enum YesNo
    {
        Yes = 1,
        No = 2
    }

    internal enum Jurisdiction
    {
        England = 1,
        Scotland = 2
    }
}
