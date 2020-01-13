using OpenQA.Selenium;

namespace GoogleCloudTest.pages
{
    class GoogleCloudStartPage
    {
        private IWebDriver driver;
        public GoogleCloudStartPage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Url = "https://cloud.google.com/";
        }

        public GoogleCloudProductPage switchToProductsPage()
        {
            new UtilityUIMetods(this.driver).clickOnLink("See all products");
            return new GoogleCloudProductPage(driver);
        }
    }
}
