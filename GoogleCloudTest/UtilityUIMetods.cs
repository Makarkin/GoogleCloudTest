using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace GoogleCloudTest
{
    class UtilityUIMetods
    {
        private static String SCREENSHOTS_NAME_TPL = "screenshots/scr";
        private IWebDriver driver;
        IWait<IWebDriver> wait;
        IJavaScriptExecutor javascriptExecutor;

        public UtilityUIMetods(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(10000));
            javascriptExecutor = (IJavaScriptExecutor)driver;
        }

        public void clickOnLink(String elementName)
        {
            String link = driver.Url.ToString();
            String xpath = String.Format(".//a[contains(text(), '{0}')]", elementName);
            IWebElement element = driver.FindElement(By.XPath(xpath));
            wait.Until(ExpectedConditions.ElementToBeClickable((element)));
            highlightElement(element);
            element.Click();
            takeScreenshot();
            //unHighlightElement(element);
        }

        public void clickOnButton(String elementName)
        {
            String xpath = String.Format(".//button[contains(text(), '{0}') and not(@disabled)]", elementName);
            IWebElement element = driver.FindElement(By.XPath(xpath));
            wait.Until(ExpectedConditions.ElementToBeClickable((element)));
            highlightElement(element);
            javascriptExecutor.ExecuteScript("arguments[0].click();", element);
            takeScreenshot();
            //unHighlightElement(element);
        }

        public void navigateToTab(String tabName)
        {
            driver.SwitchTo().Frame(0);
            String xpath = String.Format(".//div[@title='{0}' and parent::md-tab-item]", tabName);
            IWebElement element = driver.FindElement(By.XPath(xpath));
            wait.Until(ExpectedConditions.ElementToBeClickable((element)));
            highlightElement(element);
            javascriptExecutor.ExecuteScript("arguments[0].click();", element);
            takeScreenshot();
            //unHighlightElement(element);
        }

        public void setValueToInputField(String elementName, String value)
        {
            String xpath = String.Format(".//label[contains(text(), '{0}')]/following-sibling::input", elementName);
            IWebElement element = driver.FindElement(By.XPath(xpath));
            wait.Until(ExpectedConditions.ElementToBeClickable((element)));
            element.SendKeys(value);
            highlightElement(element);
            takeScreenshot();
            //unHighlightElement(element);
        }

        public void selectValueInSelectorWithSpecifiedName(String selectorName, String value)
        {
            String xpath = String.Format(".//span[@class='md-select-icon' and ancestor::md-select[preceding-sibling::label[contains(text(), '{0}')]]]", selectorName);
            IWebElement element = driver.FindElement(By.XPath(xpath));
            wait.Until(ExpectedConditions.ElementToBeClickable((element)));
            javascriptExecutor.ExecuteScript("arguments[0].click();", element);
            xpath = String.Format(".//div[contains(text(), '{0}') and parent::md-option]", value);
            element = driver.FindElements(By.XPath(xpath))[0];
            javascriptExecutor.ExecuteScript("arguments[0].click();", element);
            takeScreenshot();
        }

        private void highlightElement(IWebElement element)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable((element)));
            javascriptExecutor.ExecuteScript("arguments[0].style.border='5px solid green'", element);
        }

        private void unHighlightElement(IWebElement element)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable((element)));
            javascriptExecutor.ExecuteScript("arguments[0].style.border='0px'", element);
        }

        private void takeScreenshot()
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();

            try
            {
                String screenshotName = SCREENSHOTS_NAME_TPL + DateTimeOffset.Now.ToUnixTimeMilliseconds();
                String scrPath = screenshotName + ".png";
                screenshot.SaveAsFile("scrPath", ScreenshotImageFormat.Png);

                captureScreenshot(driver);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private byte[] captureScreenshot(IWebDriver driver)
        {
            byte[] screenshot = null;
            screenshot = ((ITakesScreenshot)driver).GetScreenshot().AsByteArray;
            return screenshot;
        }
    }
}
