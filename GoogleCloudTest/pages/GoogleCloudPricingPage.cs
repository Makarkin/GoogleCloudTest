using OpenQA.Selenium;

namespace GoogleCloudTest.pages
{
    class GoogleCloudPricingPage
    {
        private IWebDriver driver;

        public GoogleCloudPricingPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public GoogleCloudCalculatorPage switchToCalculatorPage()
        {
            new UtilityUIMetods(this.driver).clickOnLink("Calculator");
            return new GoogleCloudCalculatorPage(driver);
        }
    }
}
