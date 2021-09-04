using System.Collections.Generic;

namespace TestCaseManager
{
    public class Project
    {
        public string ProjectName { get; set; }
        public List<Suite> SuiteList = new List<Suite>();

        public Project(string projectName)
        {
            this.ProjectName = projectName;
        }

        public Project()
        {
        }
    }
}