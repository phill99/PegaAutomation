using System.Threading;
using NUnit.Framework;

namespace SingleTest.Helpers
{
    internal class AboutYou : Screen
    {
        internal AboutYou(CaptureHelpers captureHelpers) : base(captureHelpers)
        {
        }

        /// <summary>
        /// Configuration to derive which scenario to build for About You
        /// </summary>
        /// <param name="scenarioNumber"></param>
        public override void CaptureData(int scenarioNumber = 1)
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
            CaptureHelper.CaptureJurisdiction("ECNClientJurisdictionRadio", Jurisdiction.England);

            //Does client have UK debts - ECNClientUKDebtRadio
            CaptureHelper.CaptureYesNo("ECNClientUKDebtRadio", YesNo.Yes);

            //clients age - ECNClientAgeText
            CaptureHelper.CaptureNumber("ECNClientAgeText", 22);

            //Self Employed - 20191009094349010764198
            CaptureHelper.CaptureYesNo("20191009094349010764198", YesNo.No);

            //What prompted you to seek help from StepChange - 20180905123004057517348
            CaptureHelper.CaptureDropDown("20180905123004057517348", "Other");

            //Main cause of financial Difficulty - 20200225101701099349448
            CaptureHelper.CaptureDropDown("20200225101701099349448", "Drugs");

            //Does client live with a partner - 2018021310141006912016266
            CaptureHelper.CaptureYesNo("2018021310141006912016266", YesNo.No);
        }
        
        /// <summary>
        /// Self employed scenario
        /// </summary>
        private void Scenario2()
        {
            //Clients jurisdiction - ECNClientJurisdictionRadio
            CaptureHelper.CaptureJurisdiction("ECNClientJurisdictionRadio", Jurisdiction.England);

            //Does client have UK debts - ECNClientUKDebtRadio
            CaptureHelper.CaptureYesNo("ECNClientUKDebtRadio", YesNo.Yes);

            //clients age - ECNClientAgeText
            CaptureHelper.CaptureNumber("ECNClientAgeText", 22);

            //Self Employed - 20191009094349010764198
            CaptureHelper.CaptureYesNo("20191009094349010764198", YesNo.Yes);

            //What prompted you to seek help from StepChange - 20180905123004057517348
            CaptureHelper.CaptureDropDown("20180905123004057517348", "Other");

            //Main cause of financial Difficulty - 20200225101701099349448
            CaptureHelper.CaptureDropDown("20200225101701099349448", "Drugs");

            //Does client live with a partner - 2018021310141006912016266
            CaptureHelper.CaptureYesNo("2018021310141006912016266", YesNo.No);
        }

        override public void ValidateTitle()
        {
            string _pageTitle = CaptureHelper.GrabTextFromElement("2019112711352504444390");
            Assert.AreEqual("Your debt advice journey starts here", _pageTitle);
        }

        public override void Submit()
        {
            //click submit
            CaptureHelper.ClickButton("20150213063700071316413");
            Thread.Sleep(3000);
        }
    }
}
