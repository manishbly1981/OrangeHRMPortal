using AventStack.ExtentReports.Reporter;
using log4net;
using RazorEngine.Compilation.ImpromptuInterface.Optimization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBaseFramework
{
    public class ReportUtil
    {
        private static readonly ILog LOG = log4net.LogManager.GetLogger("Task");
        AventStack.ExtentReports.ExtentReports extentReports;
        AventStack.ExtentReports.ExtentTest extentTest;
        private String reportFolderPath;
        
        public ReportUtil()
        {
            this.reportFolderPath = "";
        }

        public string getReportPath()
        {
            return this.reportFolderPath;
        }

        public void generateReport()
        {
            String fPath = "./../../../Reports/ExecutionReport_"+ CompactUtil.getDateTimeStamp(0,"yyMMdd_hhmmss")+"/";
            reportFolderPath= Path.GetFullPath(fPath);
            CompactUtil.createFolder(reportFolderPath);
            ExtentHtmlReporter htmlReporter= new ExtentHtmlReporter(reportFolderPath+ "AutomationExecutionReport.html");
            LOG.Info("Extent Report initialized at location: " + reportFolderPath);
            extentReports= new AventStack.ExtentReports.ExtentReports();
            extentReports.AttachReporter(htmlReporter);
            LOG.Info("Html reporter attached");

        }

        public void createTest(string testName)
        {
            extentTest= extentReports.CreateTest(testName);
        }

        public void createTest(string testName, string testInfo)
        {
            extentTest = extentReports.CreateTest(testName).Info(testInfo);
        }

        public void closeReport()
        {
            extentReports.Flush();
        }

        public void testPass(string msgToLog)
        {
            extentTest.Pass(msgToLog);
            LOG.Info(msgToLog);
        }

        public void testPass(string objective, string expectedResult, string actualResult)
        {
            string valToWriteInReport = "Objective: " + objective + "<BR/>Expected Result: '" + expectedResult + "'<BR/>Actual Result: '" + actualResult + "'";
        }

        public string attachScreenshot(string filePath, string linkTitle)
        {
            FileInfo fi= new FileInfo(filePath);
            if (fi.Extension.ToLower().Equals("html"))
                return "<div align='right' style='float:right'><a " + newWindowPopupCode() + " target='_blank' href= './details/" + System.IO.Path.GetFileName(filePath) + "'>" + linkTitle + "</a";
            else
                return "<div align='right' style='float:right'><a  target='_blank' href= './details/" + System.IO.Path.GetFileName(filePath) + "'>" + linkTitle + "</a";
        }

        public string newWindowPopupCode()
        {
            return "onclick=\"window.open(this.href, 'newwindow', 'width=800,height=600'); return false;\"";
        }

        public bool getStatus()
        {
            bool status = true;
            switch(extentTest.Status.ToString().ToLower()) {
                case "fail":
                    status = false;
                    break;
                case "fatail":
                    status = false;
                    break;
                case "error":
                    status=false;
                    break;
                default: 
                    status = true;
                    break;
            }
            return status;
        }
    }
}
