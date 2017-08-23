using Microsoft.VisualStudio.TestTools.LoadTesting;
using System.Collections.Generic;
using System.Linq;

namespace SecurePay.MasterPass.PerformanceTest.Plugins
{
    public class UserLoadPlugin : ILoadTestPlugin
    {
        public class ScenarioDetails
        {
            public ScenarioDetails()
            {
                _numberOfTestComplete = 0;
            }
            public LoadTestScenario Scenario { get; set; }
            public int MaxUsers { get; set; }
            private int _numberOfTestComplete { get; set; }

            public void CompleteTest()
            {
                _numberOfTestComplete++;
                //Find a way to get max tests instead of max users ?
                if (_numberOfTestComplete == MaxUsers)
                {
                    //Turn load off on that test profile as scenario is done
                    Scenario.CurrentLoad = 0;
                }
            }
        }

        private LoadTest LoadTest { get; set; }
        public List<ScenarioDetails> ScenarioList { get; set; }

        public void Initialize(LoadTest loadTest)
        {
            loadTest.TestFinished += webTest_TestFinished;
            LoadTest = loadTest;

            ScenarioList = new List<ScenarioDetails>();
            foreach (var s in LoadTest.Scenarios)
            {

                ScenarioList.Add(new ScenarioDetails
                {
                    Scenario = s,
                    MaxUsers = s.LoadProfile.MaxUserCount
                });
            }
        }

        void webTest_TestFinished(object sender, TestFinishedEventArgs e)
        {
            var scenario = ScenarioList.FirstOrDefault(x => x.Scenario.Name == e.ScenarioName);
            scenario.CompleteTest();
        }
    }
}
