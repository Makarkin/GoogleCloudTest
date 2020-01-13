using OpenQA.Selenium;
using System;
namespace GoogleCloudTest.pages
{
    class GoogleCloudCalculatorPage : IAbstractPage
    {
        private IWebDriver driver;

        public GoogleCloudCalculatorPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public GoogleCloudCalculatorPage navigateToComputeInputTab()
        {
            new UtilityUIMetods(this.driver).navigateToTab("Compute Engine");
            return this;
        }

        public GoogleCloudCalculatorPage setValueToInstanceInputField(String value)
        {
            new UtilityUIMetods(this.driver).setValueToInputField("Number of instances", value);
            return this;
        }

        public GoogleCloudCalculatorPage selectValueInSelector(String selectorName, String value)
        {
            new UtilityUIMetods(this.driver).selectValueInSelectorWithSpecifiedName(selectorName, value);
            return this;
        }

        public GoogleCloudCalculatorPage addToEstimate()
        {
            new UtilityUIMetods(this.driver).clickOnButton("Add to Estimate");
            return this;
        }

        public bool checkTheEstimateWindow(string valueName, string expectedValue)
        {
            String xpath = String.Format(".//div[@class='md-list-item-text ng-binding' and contains(text(), '{0}')]", valueName);
            IWebElement element = driver.FindElement(By.XPath(xpath));
            return expectedValue.Equals(element.Text.Split(": ")[1], StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
