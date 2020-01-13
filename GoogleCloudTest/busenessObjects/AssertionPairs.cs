using System.Collections;

namespace GoogleCloudTest.busenessObjects
{
    class AssertionPairs
    {
        private ArrayList assertionPairs;

        public AssertionPairs()
        {
            this.assertionPairs = new ArrayList();
            assertionPairs.Add(new AssertionPair("VM class", "Regular"));
            assertionPairs.Add(new AssertionPair("Instance type", "n1-standard-8"));
            assertionPairs.Add(new AssertionPair("Region", "Frankfurt"));
            assertionPairs.Add(new AssertionPair("Commitment term", "1 Year"));
        }

        public ArrayList getAssertionPairs()
        {
            return assertionPairs;
        }
    }
}
