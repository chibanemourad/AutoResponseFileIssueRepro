using Buildalyzer;

namespace NunitIssueReproTests
{
    public class RspFileIssueTests
    {
        private AnalyzerManager _manager;
        [SetUp]
        public void Setup()
        {
            _manager = new AnalyzerManager();
        }

        [TestCase("ClassLibrarySample", ExpectedResult = 0)]
        [TestCase("AutoResponseFileIssueRepro", ExpectedResult = 1)]
        public int WithoutRspMsBuildFileBuildProjectAnalyzerSuccessfullyTest(string pojectTargetName)
        {
            var rootDir = Path.Combine(Environment.CurrentDirectory, ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar);
            var targetProject = Path.Combine(rootDir, pojectTargetName + Path.DirectorySeparatorChar + $"{pojectTargetName}.csproj");
            Assert.IsTrue(File.Exists(targetProject));
            var analyzer = _manager.GetProject(targetProject);
            var buildResult = analyzer.Build();
            return buildResult.Count;
        }
    }
}