using Buildalyzer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class RspFileIssueUnitTest
    {
        private readonly AnalyzerManager _manager = new AnalyzerManager();

        [TestMethod]
        public void WithoutRspMsBuildFileSuccessTest()
        {
            var analyzer = _manager.GetProject(@"C:\workgit\AutoResponseFileIssueRepro\AutoResponseFileIssueRepro\AutoResponseFileIssueRepro.csproj");
            var buildResult = analyzer.Build();
            Assert.AreEqual(buildResult.Count, 1);
        }

        [TestMethod]
        public void WithRspMsBuildFileFailedTest()
        {
            var analyzer = _manager.GetProject(@"C:\workgit\AutoResponseFileIssueRepro\ClassLibrarySample\ClassLibrarySample.csproj");
            var buildResult = analyzer.Build();
            Assert.AreEqual(buildResult.Count, 1);
        }
    }
}
