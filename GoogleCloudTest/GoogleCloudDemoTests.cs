using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoogleCloudTest.busenessObjects;
using GoogleCloudTest.pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GoogleCloudTest
{
    [TestClass]
    public class GoogleCloudDemoTests
    {
        private IWebDriver driver;

        [TestInitialize]
        public void config()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void googleCloudTestRun()
        {
            GoogleCloudCalculatorPage page = new GoogleCloudStartPage(driver)
                    .switchToProductsPage()
                    .switchToPricingPagePage()
                    .switchToCalculatorPage()
                    .navigateToComputeInputTab()
                    .setValueToInstanceInputField("4")
                    .selectValueInSelector("Operating System / Software",
                            "Free: Debian, CentOS, CoreOS, Ubuntu, or other User Provided OS")
                    .selectValueInSelector("Machine Class", "Regular")
                    .selectValueInSelector("Machine type", "n1-standard-8 (vCPUs: 8, RAM: 30GB)")
                    .selectValueInSelector("Local SSD", "2x375 GB")
                    .selectValueInSelector("Datacenter location", "Frankfurt (europe-west3)")
                    .selectValueInSelector("Committed usage", "1 Year")
                    .addToEstimate();
            Assert.IsTrue(UtilityBusinessMethods.checkTheEstimateResultsOnPage(new AssertionPairs(), page));
        }

       // [TestCleanup]
        public void kill()
        {
            driver.Quit();
        }
    }
}
