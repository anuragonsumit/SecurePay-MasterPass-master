using Microsoft.VisualStudio.TestTools.LoadTesting;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace SecurePay.MasterPass.PerformanceTest.Plugins
{

    public class AnalysisNotePlugin : ILoadTestPlugin
    {

        private LoadTest LoadTest { get; set; }

        public void Initialize(LoadTest loadTest)
        {
            loadTest.LoadTestFinished += loadTest_LoadTestFinished;
            LoadTest = loadTest;
        }

        void loadTest_LoadTestFinished(object sender, EventArgs e)
        {
            var runId = LoadTest.Context.LoadTestRunId;

            var configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = "LoadTest2010.config";

            // Get the mapped configuration file
            var config = ConfigurationManager.OpenMappedExeConfiguration(
               configFileMap, ConfigurationUserLevel.None);

            var connectionString = config.AppSettings.Settings["LoadTest2010ConnectionString"].Value;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                //Save the load test meta data
                var baseUrl = LoadTest.Context["BaseUrl"].ToString();
                var brand = LoadTest.Context["SiteBrand"].ToString();
                var region = LoadTest.Context["SiteRegion"].ToString();
                var flow = LoadTest.Context["TestFlow"].ToString();
                var project = LoadTest.Context["LoadTestProject"].ToString();

                var testType = "";
                if (LoadTest.Context.ContainsKey("TestType"))
                {
                    testType = LoadTest.Context["TestType"].ToString();
                }
                else
                {
                    testType = Environment.GetEnvironmentVariable("Test.TestType", EnvironmentVariableTarget.Machine);
                }

                var siteVersion = Environment.GetEnvironmentVariable("Test.SiteVersion", EnvironmentVariableTarget.Machine);

                if (String.IsNullOrEmpty(siteVersion))
                {
                    siteVersion = String.Format("Local_{0}", DateTime.Now.ToString("yyyy-MM-dd-Hmmss"));
                }

                var cmd = new SqlCommand("PR_PerformanceTestMetaDataCreate", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@LoadTestRunId", runId));
                cmd.Parameters.Add(new SqlParameter("@SiteVersion", siteVersion));
                cmd.Parameters.Add(new SqlParameter("@Brand", brand));
                cmd.Parameters.Add(new SqlParameter("@Region", region));
                cmd.Parameters.Add(new SqlParameter("@TestFlow", flow));
                cmd.Parameters.Add(new SqlParameter("@TestType", testType));
                cmd.Parameters.Add(new SqlParameter("@Url", baseUrl));
                cmd.Parameters.Add(new SqlParameter("@LoadTestProject", project));

                cmd.ExecuteNonQuery();
                connection.Close();

            }
        }

    }
}
