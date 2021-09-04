using Autofac;

namespace TestCaseManager
{
    public class ProgramModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProjectService>().AsSelf();
            builder.RegisterType<TestCaseService>().As<ITestCaseService>();
            builder.RegisterType<SuiteService>().As<ISuiteService>();
        }
    }
}