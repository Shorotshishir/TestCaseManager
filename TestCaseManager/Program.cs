using Autofac;
using System;

namespace TestCaseManager

{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Test Case Manager");
            Console.WriteLine("****************");
            Console.WriteLine("Create Project - 0");
            Console.WriteLine(">>");
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<ProgramModule>();
            var container = containerBuilder.Build();

            var caseService = container.Resolve<ITestCaseService>();
            //var suiteService = container.Resolve<ISuiteService>();
            var suiteService = new SuiteService(caseService);
            var projectService = new ProjectService(suiteService);

            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Log("Exit");
            }
            else
            {
                if (int.Parse(input) == 0)
                {
                    Log("Creating New Project");
                    var project1 = projectService.CreateNew("Project1");
                    var project2 = projectService.CreateNew("Project2");
                    var project3 = projectService.CreateNew("Project3");
                    projectService.ShowProjectList();

                    suiteService.CrateNewSuite("Suite1");
                    suiteService.CrateNewSuite("Suite2");
                    suiteService.CrateNewSuite("Suite3");
                    suiteService.CrateNewSuite("Suite4");
                    suiteService.CrateNewSuite("Suite5");
                    suiteService.CrateNewSuite("Suite6");

                    var suite1 = suiteService.GetSuite("Suite1");
                    var suite2 = suiteService.GetSuite("Suite2");
                    var suite3 = suiteService.GetSuite("Suite3");
                    var suite4 = suiteService.GetSuite("Suite4");
                    var suite5 = suiteService.GetSuite("Suite5");
                    var suite8 = suiteService.GetSuite("Suite8");

                    caseService.CrateNewCase("Case1");
                    caseService.CrateNewCase("Case2");
                    caseService.CrateNewCase("Case3");
                    caseService.CrateNewCase("Case4");
                    caseService.CrateNewCase("Case5");

                    var case1 = caseService.GetCase("Case1");
                    var case2 = caseService.GetCase("Case2");
                    var case3 = caseService.GetCase("Case3");
                    var case4 = caseService.GetCase("Case4");
                    var case5 = caseService.GetCase("Case5");
                    var case8 = caseService.GetCase("Case8");

                    suiteService.AddCase(suite1, case1, case2, case8);
                    suiteService.AddCase(suite3, case3, case4, case5);
                    projectService.AddSuite(project1, suite1, suite2);
                    projectService.AddSuite(project2, suite2, suite3, suite8);

                    projectService.ShowDetails(project1);
                    projectService.ShowDetails(project2);
                }
            }
        }

        private static void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}