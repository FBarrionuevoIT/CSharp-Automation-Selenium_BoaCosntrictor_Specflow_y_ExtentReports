// <auto-generated />
#pragma warning disable

using System.CodeDom.Compiler;
using System.Diagnostics;
using global::Microsoft.VisualStudio.TestTools.UnitTesting;
using global::TechTalk.SpecFlow;
using global::TechTalk.SpecFlow.MSTest.SpecFlowPlugin;
using global::System.Runtime.CompilerServices;

[GeneratedCode("SpecFlow", "3.9.74")]
[TestClass]
public class BoaCosntrictorYSpecflowConExtentReports_MSTestAssemblyHooks
{
    [AssemblyInitialize]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void AssemblyInitialize(TestContext testContext)
    {
        var currentAssembly = typeof(BoaCosntrictorYSpecflowConExtentReports_MSTestAssemblyHooks).Assembly;
        var containerBuilder = new MsTestContainerBuilder(testContext);

        TestRunnerManager.OnTestRunStart(currentAssembly, containerBuilder);
    }

    [AssemblyCleanup]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void AssemblyCleanup()
    {
        var currentAssembly = typeof(BoaCosntrictorYSpecflowConExtentReports_MSTestAssemblyHooks).Assembly;

        TestRunnerManager.OnTestRunEnd(currentAssembly);
    }
}
#pragma warning restore
