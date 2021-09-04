using System.Collections.Generic;

namespace TestCaseManager
{
    public interface ITestCaseService
    {
        public void CrateNewCase(string caseName);

        public TestCase GetCase(string caseName);

        void InvalidCase(string suitName, int index);
    }
}