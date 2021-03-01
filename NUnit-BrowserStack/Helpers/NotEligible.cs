using NUnit.Framework;

namespace SingleTest.Helpers
{
    internal class NotEligible : Screen
    {
        internal NotEligible(CaptureHelpers captureHelpers) : base (captureHelpers)
        {
        }

        override public void ValidateTitle()
        {
            string _pageTitle = CaptureHelper.GrabTextFromElement("202002261824380516574");
            Assert.IsTrue(_pageTitle.StartsWith("Sorry, we can't help right now"));
        }

        public override void CaptureData(int value = 1)
        {
            throw new System.NotImplementedException();
        }

        public override void Submit()
        {
            throw new System.NotImplementedException();
        }

        public override void ValidateAccessibility()
        {
            throw new System.NotImplementedException();
        }
    }
}
