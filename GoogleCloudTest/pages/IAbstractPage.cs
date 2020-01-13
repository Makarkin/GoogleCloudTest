using System;

namespace GoogleCloudTest.pages
{
    interface IAbstractPage
    {
        public Boolean checkTheEstimateWindow(String valueName, String expectedValue);
    }
}
