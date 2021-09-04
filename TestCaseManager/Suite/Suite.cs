using System.Collections.Generic;

namespace TestCaseManager
{
    public class Suite
    {
        public string SuiteName { get; set; } = string.Empty;

        public List<TestCase> CaseList = new List<TestCase>();
    }
}