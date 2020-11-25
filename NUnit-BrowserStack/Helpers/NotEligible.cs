using NUnit.Framework;

namespace SingleTest.Helpers
{
    internal class NotEligible
    {
        CaptureHelpers _captureHelpers;

        internal NotEligible(CaptureHelpers captureHelpers)
        {
            _captureHelpers = captureHelpers;
        }

        internal void ValidateTitle()
        {
            string _pageTitle = _captureHelpers.GrabTextFromElement("202002261824380516574");
            Assert.IsTrue(_pageTitle.StartsWith("Sorry, we can't help right now"));
        }
    }
}
