using System.Threading;
using NUnit.Framework;

namespace SingleTest.Helpers
{
    internal class AccountRegistration : Screen
    {
        internal AccountRegistration(CaptureHelpers captureHelpers) : base (captureHelpers)
        {
        }

        override public void ValidateTitle()
        {
            string _pageTitle = CaptureHelper.GrabTextFromElement("202003261313590656636");
            Assert.AreEqual("Create a StepChange account", _pageTitle);
        }

        public override void CaptureData(int value = 1)
        {
            throw new System.NotImplementedException();
        }

        public override void Submit()
        {
            throw new System.NotImplementedException();
        }

        internal void ClickSkipAccountRegistration()
        {
            CaptureHelper.ClickButton("20181214003416016186262");
            Thread.Sleep(3000);
            CaptureHelper.ClickButton("201806251335470614103160");
            Thread.Sleep(12000);
        }
    }
}
