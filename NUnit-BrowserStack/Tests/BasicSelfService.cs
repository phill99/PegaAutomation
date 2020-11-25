using NUnit.Framework;
using SingleTest.Helpers;

namespace BrowserStack
{
    [TestFixture("chrome")]
    //[TestFixture("firefox")]
    //[TestFixture("safari")]
    [TestFixture("ie")]
    [TestFixture("local")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class BasicSelfService : BrowserStackNUnitTest
    {
        public BasicSelfService(string environment) : base(environment) { }

        [Test]
        public void StartToDashboard()
        {
            //Go to Dev URL
            driver.Url = "https://stpchn-digtrf-dt2.pegacloud.net/prweb/IAC/app/DeoneroRELEASE_1122/p9l0jRy_bbPe52cNke6ey9xgo-caCc3k*/!DeoneroRELEASE/$DNDA10?pzuiactionzzz=CXtpbn1COVB1R2tZUjk1OEhvY2lkaGkrUnNrY3NFWDd2bDJXZUxuV2IrNWxsNWV3a1U3N21DNDhyeUxlc1hOb0tQbnkyZ2NGOGxXTUNRa0xLSWNuNXF2em1qUG4vTXhVQjdyWlVjN0ZDakFlWkFKd29mU3REaTdKbXZGMXlidUlDejdKaFNBc2ZFbHRnNWdnUDhIOU85Rmc5VFE9PQ%3D%3D*";

            CaptureHelpers _CaptureHelper = new CaptureHelpers(driver);

            AboutYou _aboutYou = new AboutYou(_CaptureHelper);
            _aboutYou.ValidateTitle();
            _aboutYou.CaptureData();
            _aboutYou.ClickSubmit();

            AccountRegistration _accountRegistration = new AccountRegistration(_CaptureHelper);
            _accountRegistration.ValidateTitle();
            _accountRegistration.ClickSkipAccountRegistration();
        }

        [Test]
        public void SelfEmployedNotEligible()
        {
            //Go to Dev URL
            driver.Url = "https://stpchn-digtrf-dt2.pegacloud.net/prweb/IAC/app/DeoneroRELEASE_1122/p9l0jRy_bbPe52cNke6ey9xgo-caCc3k*/!DeoneroRELEASE/$DNDA10?pzuiactionzzz=CXtpbn1COVB1R2tZUjk1OEhvY2lkaGkrUnNrY3NFWDd2bDJXZUxuV2IrNWxsNWV3a1U3N21DNDhyeUxlc1hOb0tQbnkyZ2NGOGxXTUNRa0xLSWNuNXF2em1qUG4vTXhVQjdyWlVjN0ZDakFlWkFKd29mU3REaTdKbXZGMXlidUlDejdKaFNBc2ZFbHRnNWdnUDhIOU85Rmc5VFE9PQ%3D%3D*";

            CaptureHelpers _CaptureHelper = new CaptureHelpers(driver);

            AboutYou _aboutYou = new AboutYou(_CaptureHelper);
            _aboutYou.ValidateTitle();
            _aboutYou.CaptureData(2);
            _aboutYou.ClickSubmit();

            NotEligible _notEligible = new NotEligible(_CaptureHelper);
            _notEligible.ValidateTitle();
        }
    }
}
