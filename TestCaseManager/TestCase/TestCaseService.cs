using System.Collections.Generic;

namespace TestCaseManager
{
    public class TestCaseService : ITestCaseService
    {
        private List<TestCase> _caseList = new List<TestCase>();

        public void CrateNewCase(string caseName)
        {
            var testCase = _caseList.Find(x => x.CaseName.Equals(caseName));
            if (testCase == null)
            {
                testCase = new TestCase
                {
                    CaseName = caseName
                };
                _caseList.Add(testCase);
            }
            else
            {
                System.Console.WriteLine("Suite Name Conflict");
            }
        }

        public TestCase GetCase(string caseName)
        {
            var testCase = _caseList.Find(x => x.CaseName.Equals(caseName));
            return testCase;
        }

        public void InvalidCase(string suiteName, int index)
        {
            System.Console.WriteLine($"Invalid Parameter at {index}: {suiteName}");
        }
    }
}