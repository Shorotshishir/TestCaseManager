namespace TestCaseManager
{
    public interface ISuiteService
    {
        public void CrateNewSuite(string suiteName);

        public Suite GetSuite(string suiteName);

        void InvalidSuite(string projectName, int index);

        void AddCase(Suite suite1, params TestCase[] cases);
    }
}