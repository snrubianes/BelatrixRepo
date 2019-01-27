using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Belatrix_DataAccess
{
    public class FileSaver: IFileSaver
    {
        public void SaveToFile(string value)
        {
            try
            {
                string path = System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"];

                if (System.IO.File.Exists(string.Format(path + "LogFile{0}.txt", DateTime.Now.ToShortDateString())))
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(string.Format(path + "LogFile{0}.txt", DateTime.Now.ToShortDateString()), true))
                    {
                        file.WriteLine(value);
                    }
                }
                else
                {
                    using (FileStream fs = File.Create(path))
                    {
                        Byte[] info = new UTF8Encoding(true).GetBytes(value);
                        fs.Write(info, 0, info.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
