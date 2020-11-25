using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;

namespace BrowserStack
{
    [TestFixture]
    public class BrowserStackNUnitTest
    {
        protected IWebDriver driver;
        protected string environment;
        private Local browserStackLocal;
        private string sessionID;
        private DateTime runDateTime;
        private bool local = false;
        string username = "";
        string accesskey = "";

        public BrowserStackNUnitTest(string environment)
        {
            if (environment == "local")
                local = true;
            else
                this.environment = environment;

            runDateTime = DateTime.Now;
        }
        
        [SetUp]
        public void Init()
        {
            //Local uses ChromeDriver installed on your PC - can run tests on browserstack or on your machine as required
            if (local)
            {
                driver = new ChromeDriver();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                return;
            }

            NameValueCollection settings = ConfigurationManager.GetSection("environments/" + environment) as NameValueCollection;
            
            DesiredCapabilities capability = new DesiredCapabilities();

            foreach (string key in settings.AllKeys)
            {
                capability.SetCapability(key, settings[key]);
            }

            //CUSTOM - Build name dynamic so we keep each test run separate
            string _buildName = this.GetType().Name + "_" + runDateTime.ToString("dd/MM/yy");
            capability.SetCapability("build", _buildName);

            //CUSTOM - Add name of test to driver so it shows up in browserstack
            capability.SetCapability("name", TestContext.CurrentContext.Test.Name);

            //CUSTOM - debug
            capability.SetCapability("browserstack.debug", true);

            capability.SetCapability("project", "Pulse");

            username = Environment.GetEnvironmentVariable("BROWSERSTACK_USERNAME");
            
            if(username == null)
                username = ConfigurationManager.AppSettings.Get("user");
            
            accesskey = Environment.GetEnvironmentVariable("BROWSERSTACK_ACCESS_KEY");
            
            if (accesskey == null)
                accesskey = ConfigurationManager.AppSettings.Get("key");
            
            capability.SetCapability("browserstack.user", username);
            capability.SetCapability("browserstack.key", accesskey);
            
            if (capability.GetCapability("browserstack.local") != null && capability.GetCapability("browserstack.local").ToString() == "true")
            {
                browserStackLocal = new Local();
                List<KeyValuePair<string, string>> bsLocalArgs = new List<KeyValuePair<string, string>>() {
                    new KeyValuePair<string, string>("key", accesskey)
                };
                
                browserStackLocal.start(bsLocalArgs);
            }
            
            driver = new RemoteWebDriver(new Uri("http://"+ ConfigurationManager.AppSettings.Get("server") +"/wd/hub/"), capability);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //grab session ID from driver if possible, use this to update status
            sessionID = "";
            sessionID = ((RemoteWebDriver)driver).SessionId.ToString();
        }
        
        [TearDown]
        public void Cleanup()
        {
            if(!local)
            {
                if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
                {
                    UpdateTestStatus(false, TestContext.CurrentContext.Result.Message);
                }
                else if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
                {
                    UpdateTestStatus(true);
                }
            }

            driver.Quit();

            if (browserStackLocal != null)
                browserStackLocal.stop();
        }

        private void UpdateTestStatus(bool pass, string reason = "")
        {
            if (sessionID != "")
            {
                string _passfail = pass ? "passed" : "failed";
                string _reason = "";

                if (reason.Length > 0)
                { 
                    int idx = reason.IndexOf('.');
                    _reason = reason.Substring(0, idx);
                }

                string reqString = "{\"status\": \"" + _passfail + "\",\"reason\": \"" + _reason + "\"}";

                byte[] requestData = Encoding.UTF8.GetBytes(reqString);
                Uri myUri = new Uri(string.Format("https://www.browserstack.com/automate/sessions/" + sessionID + ".json"));
                WebRequest myWebRequest = HttpWebRequest.Create(myUri);
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)myWebRequest;
                myWebRequest.ContentType = "application/json";
                myWebRequest.Method = "PUT";
                myWebRequest.ContentLength = requestData.Length;
                using (Stream st = myWebRequest.GetRequestStream()) st.Write(requestData, 0, requestData.Length);

                NetworkCredential myNetworkCredential = new NetworkCredential(username, accesskey);
                CredentialCache myCredentialCache = new CredentialCache();
                myCredentialCache.Add(myUri, "Basic", myNetworkCredential);
                myHttpWebRequest.PreAuthenticate = true;
                myHttpWebRequest.Credentials = myCredentialCache;

                myWebRequest.GetResponse().Close();
            }
        }
    }
}
