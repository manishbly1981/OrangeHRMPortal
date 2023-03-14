using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBaseFramework
{
    public class CompactUtil
    {
        private static readonly ILog LOG = log4net.LogManager.GetLogger("Task");

        public static void createFolder(string folderPath)
        {
            //BasicConfigurator.Configure();
            if(!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            LOG.Info("Folder created with path: " + folderPath);


        }

        public static void deleteFolder(string folderPath)
        {
            //BasicConfigurator.Configure();
            if (Directory.Exists(folderPath))
                Directory.Delete(folderPath, true);
            LOG.Info("Folder deleted with path: " + folderPath);
        }
   
        public static string getDateTimeStamp(int daysToAdd, string dateFormat)
        {
            return DateTime.Now.AddDays(daysToAdd).ToString(dateFormat);
        }

        public static void moveFile(string sourceFile, string targetFile)
        {
            FileInfo fi= new FileInfo(sourceFile);
            if(fi.Exists)
            {
                fi.MoveTo(targetFile);
            }
            else
            {
                LOG.Error(sourceFile + " could not move to " + targetFile);
            }
        }
    

        public static string getFileData(string filePath)
        {
            if (File.Exists(filePath))
                return File.ReadAllText(filePath);
            else
            {
                LOG.Fatal("File not found: " + filePath);
                return null;
            }
        }
    }
}
