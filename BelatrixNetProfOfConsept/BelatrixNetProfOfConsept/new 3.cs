using System;
using System.Linq;
using System.Text;

public class JobLogger
{
	private static bool _logToFile;
	private static bool _logToConsole;
	private static bool _logMessage;
	private static bool _logWarning;
	private static bool _logError;
	private static bool _LogToDatabase;
	private bool _initialized;

	public JobLogger(bool logToFile, bool logToConsole, bool logToDatabase, 
						bool logMessage, bool logWarning, bool logError)
	{
		_logError = logError;
		_logMessage = logMessage;
		_logWarning = logWarning;
		_LogToDatabase = logToDatabase;
		_logToFile = logToFile;
		_logToConsole = logToConsole;
	}
	public static void LogMessage(string message, bool isAMessage, bool isAwarning, 
									bool isAError)
	{		
		if (!_logToConsole && !_logToFile && !_LogToDatabase)
		{
			throw new Exception("Invalid configuration");
		}
		if ((!_logError && !_logMessage && !_logWarning) || (!isAMessage && !isAwarning && !isAError))
		{
			throw new Exception("Error or Warning or Message must be specified");
		}
		
		if(string.IsNullOrEmpty(message))
		{
			throw new Exception("Invalid input");
		}
		
		if(_LogToDatabase)
		{
			int typeID = 0;
		
			if (isAMessage && _logMessage)
			{
				typeID = 1;
			}
			if (isAError && _logError)
			{
				typeID = 2;
			}
			if (isAwarning && _logWarning)
			{
				typeID = 3;
			}

            Belatrix_DataAccess.BelatrixDatababes.SaveToDatababes(message, typeID.ToString());

        }
		
		if(_logToFile)
		{
			string value = string.Empty;
			string path = System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"];
			
			if (isAError && _logError)
			{
				value = value + DateTime.Now.ToShortDateString() + message;
			}
			if (isAwarning && _logWarning)
			{
				value = value + DateTime.Now.ToShortDateString() + message;
			}
			if (isAMessage && _logMessage)
			{
				value = value + DateTime.Now.ToShortDateString() + message;
			}
			
			if (System.IO.File.Exists(string.Format(path+"LogFile{0}.txt",DateTime.Now.ToShortDateString())))
			{							
				using (System.IO.StreamWriter file = new System.IO.StreamWriter(string.Format(path+"LogFile{0}.txt",DateTime.Now.ToShortDateString()), true))
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
		
		if(_logToConsole)
		{
			if (error && _logError)
			{
				Console.ForegroundColor = ConsoleColor.Red;
			}
			if (warning && _logWarning)
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
			}
			if (message && _logMessage)
			{
				Console.ForegroundColor = ConsoleColor.White;
			}
			
			Console.WriteLine(DateTime.Now.ToShortDateString() + message);
		}	
	}
}