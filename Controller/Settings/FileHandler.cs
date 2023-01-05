using System;
using System.IO;
using System.Windows.Forms;

namespace EXIN.Controller.Settings
{
    public class FileHandler
    {
        public void copyExcelFile(string rawFile, string fileName)
        {

            string sourcePath = AppDomain.CurrentDomain.BaseDirectory + rawFile;
            string targetPath = @"C:\EXINReleases\" + fileName;
            string targetPathDir = @"C:\EXINReleases\";

            // Creates target directory if it does not exists

            if (!Directory.Exists(targetPathDir))
            {
                Directory.CreateDirectory(targetPathDir);
            }

            // Code to copy file
            try
            {
                File.Copy(sourcePath, targetPath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public void clearFiles()
        {
            string EXINExcelPath = @"C:\EXINReleases";
            string UploadPath = @"C:\EXINReleases\Uploads";
            bool fileError = false;


            if (!Directory.Exists(EXINExcelPath))
            {
                // Try to create the directory.
                DirectoryInfo EXINdi = Directory.CreateDirectory(EXINExcelPath);
                MessageBox.Show("EXIN excel file directory was created successfully");
            }

            if (!Directory.Exists(UploadPath))
            {
                // Try to create the directory.
                DirectoryInfo Uploadsdi = Directory.CreateDirectory(UploadPath);
                MessageBox.Show("Uploads directory was created successfully");
            }

            string[] EXINfiles = Directory.GetFiles(EXINExcelPath);

            foreach (string file in EXINfiles)
            {
                if (File.Exists(file))
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch (IOException ex)
                    {
                        fileError = true;
                        MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                    }

                }
            }

            string[] files = Directory.GetFiles(UploadPath);

            foreach (string file in files)
            {
                if (File.Exists(file))
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch (IOException ex)
                    {
                        fileError = true;
                        MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                    }

                }
            }

        }


    }
}
