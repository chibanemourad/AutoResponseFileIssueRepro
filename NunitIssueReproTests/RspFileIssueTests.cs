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

        [TestCase("ClassLibrarySample", TestName = "WithRspFileEmptyAnalyzerResult", ExpectedResult = 0)]
        [TestCase("ConsoleAppSample", TestName = "WithoutRspFilePopulatedAnalyzerResult", ExpectedResult = 1)]
        public int BuildProjectAnalyzerTest(string pojectTargetName)
        {
            var rootDir = Path.Combine(Environment.CurrentDirectory, ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar);
            var targetProject = Path.Combine(rootDir, pojectTargetName + Path.DirectorySeparatorChar + $"{pojectTargetName}.csproj");
            Assert.That(File.Exists(targetProject), Is.True);
            var analyzer = _manager.GetProject(targetProject);
            var buildResult = analyzer.Build();
            return buildResult.Count;
        }
    }
}