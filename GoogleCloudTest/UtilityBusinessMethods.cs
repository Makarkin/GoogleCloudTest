using GoogleCloudTest.busenessObjects;
using GoogleCloudTest.pages;
using System;
using System.Collections;

namespace GoogleCloudTest
{
    class UtilityBusinessMethods
    {
        public static Boolean checkTheEstimateResultsOnPage(AssertionPairs assertionPairs, IAbstractPage page)
        {
            Boolean hasNoFalseResult = true;
            ArrayList list = assertionPairs.getAssertionPairs();
            foreach (AssertionPair assertionPair in list)
            {
                if (!page.checkTheEstimateWindow(assertionPair.getVariable(), assertionPair.getValue()))
                {
                    hasNoFalseResult = false;
                    break;
                }
            }

            return hasNoFalseResult;
        }
    }
}
