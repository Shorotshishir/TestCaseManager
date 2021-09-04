using System;
using System.Collections.Generic;

namespace TestCaseManager
{
    public class ProjectService
    {
        private List<Project> _projectList = new List<Project>();
        private ISuiteService _suiteService;

        public ProjectService(ISuiteService suiteService)
        {
            _suiteService = suiteService;
        }

        public Project CreateNew(string projectName)
        {
            var project = _projectList.Find(x => x.ProjectName.Equals(projectName));
            if (project != null)
            {
                Console.WriteLine("Project Exists");
            }
            else
            {
                project = new Project
                {
                    ProjectName = projectName
                };
                _projectList.Add(project);
                Console.WriteLine("Project Created!");
            }
            return project;
        }

        public void AddSuite(Project project, params Suite[] suites)
        {
            if (project != null)
            {
                var index = -1;
                foreach (var suite in suites)
                {
                    index++;
                    if (suite != null)
                    {
                        project.SuiteList.Add(suite);
                    }
                    else
                    {
                        _suiteService.InvalidSuite(project.ProjectName, index);
                    }
                }
            }
        }

        public void ShowProjectList()
        {
            Console.WriteLine("******* Project List *********");
            foreach (var project in _projectList)
            {
                Console.WriteLine(project.ProjectName);
            }
        }

        public void ShowDetails(Project project)
        {
            var suitesCount = project.SuiteList.Count;
            Console.WriteLine($"Project Name {project.ProjectName} Suites { suitesCount}");
            if (suitesCount > 0)
            {
                foreach (var suite in project.SuiteList)
                {
                    var testCaseCount = suite.CaseList.Count;
                    Console.WriteLine($"∟→{project.SuiteList.IndexOf(suite)}: {suite.SuiteName}");
                    if (testCaseCount > 0)
                    {
                        foreach (var testCase in suite.CaseList)
                        {
                            if (testCase != null)
                            {
                                Console.WriteLine($"\t∟→{suite.CaseList.IndexOf(testCase)}: {testCase.CaseName}");
                            }
                            else
                            {
                                Console.WriteLine($"Invalid test case {suite.CaseList.IndexOf(testCase)}");
                            }
                        }
                    }
                }
            }
        }
    }
}