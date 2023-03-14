using log4net;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace MyBaseFramework
{
    [Binding]
    public sealed class HooksUtil
    {
        private static readonly ILog LOG = log4net.LogManager.GetLogger("Task");
        private static DataUtil dataUtil;
        private static ConfigSetting config;
        private static ReportUtil reportUtil;
        
        public HooksUtil(DataUtil dataUtil)
        {
            HooksUtil.dataUtil = dataUtil;
            
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            //Setting for log4Net
            Log4NetUtil.log4NetConfiguration();
            string filePath = System.IO.Directory.GetParent("../../../").FullName + "/configuration/configSetting.json";
            Console.WriteLine(filePath);

            /*
            //Setting for global Variables
             config= new ConfigSetting();
             
             ConfigurationBinder builder = new ConfigurationBinder();

             builder.AddJsonFile(filePath);
             IConfigurationRoot configuration = builder.Build();
             configuration.Bind(config);
            */
            reportUtil = new ReportUtil();
            reportUtil.generateReport();
            dataUtil.reportUtil= reportUtil;
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            reportUtil.createTest(ScenarioContext.Current.ScenarioInfo.Title);
        }
            [AfterTestRun]
        public static void AfterTest()
        {
            reportUtil.closeReport();
        }
        [AfterStep]
        public void reportStepStatus()
        {
            string stepText= ScenarioStepContext.Current.StepInfo.Text;
            string stepStatus=ScenarioStepContext.Current.Status.ToString();
            switch (stepStatus)
            {
                case "OK":
                    reportUtil.testPass(stepText);
                    break;
                case "StepDefinitionPending":
                    break;
                case "UndefinedStep":
                    break;
                case "BindingError":
                    break;
                case "TestError":
                    break;
                case "Skipped":
                    break;
                
            }
        }
    }
}