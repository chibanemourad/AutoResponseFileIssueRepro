using Buildalyzer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class RspFileIssueUnitTest
    {
        private readonly AnalyzerManager _manager = new AnalyzerManager();

        [TestMethod]
        public void WithoutRspMsBuildFileBuildProjectAnalyzerSuccessfullyTest()
        {
            var rootDir = Path.Combine(Environment.CurrentDirectory, ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar);
            var targetProject = Path.Combine(rootDir, "AutoResponseFileIssueRepro" + Path.DirectorySeparatorChar + "AutoResponseFileIssueRepro.csproj");
            Assert.IsTrue(File.Exists(targetProject));
            var analyzer = _manager.GetProject(targetProject);
            var buildResult = analyzer.Build();
            Assert.AreEqual(buildResult.Count, 1);
        }

        [TestMethod]
        public void WithRspMsBuildFileFailToBuildProjectAnalyzerTest()
        {
            var rootDir = Path.Combine(Environment.CurrentDirectory, ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar);
            var targetProject = Path.Combine(rootDir, "ClassLibrarySample" + Path.DirectorySeparatorChar + "ClassLibrarySample.csproj");
            Assert.IsTrue(File.Exists(targetProject));
            var analyzer = _manager.GetProject(targetProject);
            var buildResult = analyzer.Build();
            Assert.AreEqual(buildResult.Count, 0);
        }
    }
}
