using System.Collections.Generic;

namespace TestCaseManager
{
    public class SuiteService : ISuiteService
    {
        private readonly List<Suite> _suiteList = new List<Suite>();
        private ITestCaseService _testCaseService;

        public SuiteService(ITestCaseService testCaseService)
        {
            _testCaseService = testCaseService;
        }

        public void AddCase(Suite suite, params TestCase[] testCases)
        {
            if (suite != null)
            {
                var index = -1;
                foreach (var testCase in testCases)
                {
                    index++;
                    if (testCase != null)
                    {
                        suite.CaseList.Add(testCase);
                    }
                    else
                    {
                        _testCaseService.InvalidCase(suite.SuiteName, index);
                    }
                }
            }
        }

        public void CrateNewSuite(string suiteName)
        {
            var suite = _suiteList.Find(x => x.SuiteName.Equals(suiteName));
            if (suite == null)
            {
                suite = new Suite
                {
                    SuiteName = suiteName
                };
                _suiteList.Add(suite);
            }
            else
            {
                System.Console.WriteLine("Suite Name Conflict");
            }
        }

        public Suite GetSuite(string suiteName)
        {
            var suite = _suiteList.Find(x => x.SuiteName.Equals(suiteName));
            return suite;
        }

        public void InvalidSuite(string projectName, int index)
        {
            System.Console.WriteLine($"Invalid Parameter at {index}: {projectName}");
        }
    }
}