using NUnit.Framework;
using SingleTest.Helpers;

namespace BrowserStack
{
    [TestFixture("chrome")]
    [TestFixture("firefox")]
    //[TestFixture("safari")]
    //[TestFixture("ie")]
    [TestFixture("local")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class BasicSelfService : BrowserStackNUnitTest
    {
        //string SSStartURL = "https://dev-advice.stepchange.org/prweb/IAC/app/DeoneroRELEASE_2277/p9l0jRy_bbPe52cNke6ey9xgo-caCc3k*/!DeoneroRELEASE/$DNDA10?pyActivity=%40baseclass.MashupController&pzSkinName=FCCCore&ApplicationName=Deonero&Cls=4&isWebMashup=true";
        string SSStartURL = "https://test-advice.stepchange.org/prweb/IAC/app/DeoneroRELEASE_2277/p9l0jRy_bbPe52cNke6ey9xgo-caCc3k*/!DeoneroRELEASE/$DNDA10?pyActivity=%40baseclass.MashupController&pzSkinName=FCCCore&ApplicationName=Deonero&Cls=4&isWebMashup=true";

        public BasicSelfService(string environment) : base(environment) { }

        [Test]
        public void StartToDashboard()
        {
            //Go to Dev URL
            driver.Url = SSStartURL;

            CaptureHelpers _CaptureHelper = new CaptureHelpers(driver);

            AboutYou _aboutYou = new AboutYou(_CaptureHelper);
            _aboutYou.ValidateTitle();
            _aboutYou.CaptureData();
            _aboutYou.Submit();

            AccountRegistration _accountRegistration = new AccountRegistration(_CaptureHelper);
            _accountRegistration.ValidateTitle();
            _accountRegistration.ClickSkipAccountRegistration();
        }

        [Test]
        public void SelfEmployedNotEligible()
        {
            //Go to Dev URL
            driver.Url = SSStartURL;

            CaptureHelpers _CaptureHelper = new CaptureHelpers(driver);

            AboutYou _aboutYou = new AboutYou(_CaptureHelper);
            _aboutYou.ValidateTitle();
            _aboutYou.CaptureData(2);
            _aboutYou.Submit();

            NotEligible _notEligible = new NotEligible(_CaptureHelper);
            _notEligible.ValidateTitle();
        }
    }
}
