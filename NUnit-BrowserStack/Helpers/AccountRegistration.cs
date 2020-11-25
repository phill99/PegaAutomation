using System.Threading;
using NUnit.Framework;

namespace SingleTest.Helpers
{
    internal class AccountRegistration
    {
        CaptureHelpers _captureHelpers;

        internal AccountRegistration(CaptureHelpers captureHelpers)
        {
            _captureHelpers = captureHelpers;
        }

        internal void ValidateTitle()
        {
            string _pageTitle = _captureHelpers.GrabTextFromElement("202003261313590656636");
            Assert.AreEqual("Create a StepChange account", _pageTitle);
        }

        internal void ClickSkipAccountRegistration()
        {
            _captureHelpers.ClickButton("20181214003416016186262");
            Thread.Sleep(3000);
            _captureHelpers.ClickButton("201806251335470614103160");
            Thread.Sleep(12000);
        }
    }
}
