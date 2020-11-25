using OpenQA.Selenium;

namespace SingleTest.Helpers
{
    internal class SettingExpectations
    {
        CaptureHelpers _captureHelpers;

        internal SettingExpectations(CaptureHelpers captureHelpers)
        {
            _captureHelpers = captureHelpers;
        }

        internal void ClickSubmit()
        {
            _captureHelpers.ClickButton("202002111437210005103984");
        }
    }
}
