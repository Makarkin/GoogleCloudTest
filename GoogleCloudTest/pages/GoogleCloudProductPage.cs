using OpenQA.Selenium;

namespace GoogleCloudTest.pages
{
    class GoogleCloudProductPage
    {
        private IWebDriver driver;

        public GoogleCloudProductPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public GoogleCloudPricingPage switchToPricingPagePage()
        {
            new UtilityUIMetods(this.driver).clickOnLink("See pricing");
            return new GoogleCloudPricingPage(driver);
        }
    }
}
