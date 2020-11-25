using System.Threading;
using NUnit.Framework;

namespace SingleTest.Helpers
{
    internal class AboutYou
    {
        CaptureHelpers _captureHelpers;

        internal AboutYou(CaptureHelpers captureHelpers)
        {
            _captureHelpers = captureHelpers;
        }

        /// <summary>
        /// Configuration to derive which scenario to build for About You
        /// </summary>
        /// <param name="scenarioNumber"></param>
        internal void CaptureData(int scenarioNumber = 1)
        {
            switch (scenarioNumber)
            {
                case 1:
                    Scenario1();
                    break;
                case 2:
                    Scenario2();
                    break;
                default:
                    Scenario1();
                    break;
            }
        }

        /// <summary>
        /// Basic eligible english person scenario
        /// </summary>
        private void Scenario1()
        {
            //Clients jurisdiction - ECNClientJurisdictionRadio
            _captureHelpers.CaptureJurisdiction("ECNClientJurisdictionRadio", Jurisdiction.England);

            //Does client have UK debts - ECNClientUKDebtRadio
            _captureHelpers.CaptureYesNo("ECNClientUKDebtRadio", YesNo.Yes);

            //clients age - ECNClientAgeText
            _captureHelpers.CaptureNumber("ECNClientAgeText", 22);

            //Self Employed - 20191009094349010764198
            _captureHelpers.CaptureYesNo("20191009094349010764198", YesNo.No);

            //What prompted you to seek help from StepChange - 20180905123004057517348
            _captureHelpers.CaptureDropDown("20180905123004057517348", "Other");

            //Main cause of financial Difficulty - 20200225101701099349448
            _captureHelpers.CaptureDropDown("20200225101701099349448", "Drugs");

            //Does client live with a partner - 2018021310141006912016266
            _captureHelpers.CaptureYesNo("2018021310141006912016266", YesNo.No);
        }
        
        /// <summary>
        /// Self employed scenario
        /// </summary>
        private void Scenario2()
        {
            //Clients jurisdiction - ECNClientJurisdictionRadio
            _captureHelpers.CaptureJurisdiction("ECNClientJurisdictionRadio", Jurisdiction.England);

            //Does client have UK debts - ECNClientUKDebtRadio
            _captureHelpers.CaptureYesNo("ECNClientUKDebtRadio", YesNo.Yes);

            //clients age - ECNClientAgeText
            _captureHelpers.CaptureNumber("ECNClientAgeText", 22);

            //Self Employed - 20191009094349010764198
            _captureHelpers.CaptureYesNo("20191009094349010764198", YesNo.Yes);

            //What prompted you to seek help from StepChange - 20180905123004057517348
            _captureHelpers.CaptureDropDown("20180905123004057517348", "Other");

            //Main cause of financial Difficulty - 20200225101701099349448
            _captureHelpers.CaptureDropDown("20200225101701099349448", "Drugs");

            //Does client live with a partner - 2018021310141006912016266
            _captureHelpers.CaptureYesNo("2018021310141006912016266", YesNo.No);
        }

        internal void ValidateTitle()
        {
            string _pageTitle = _captureHelpers.GrabTextFromElement("2019112711352504444390");
            Assert.AreEqual("Your debt advice journey starts here", _pageTitle);
        }

        internal void ClickSubmit()
        {
            //click submit
            _captureHelpers.ClickButton("20150213063700071316413");
            Thread.Sleep(3000);
        }
    }
}
