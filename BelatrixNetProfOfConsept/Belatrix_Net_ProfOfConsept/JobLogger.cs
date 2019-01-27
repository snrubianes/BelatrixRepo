using System;

namespace Belatrix_Net_ProfOfConsept
{
    public class JobLogger
    {
        private static bool _logToFile;
        private static bool _logToConsole;
        private static bool _logMessage;
        private static bool _logWarning;
        private static bool _logError;
        private static bool _LogToDatabase;

        private static Belatrix_DataAccess.IDataBase _dataBase;
        private static Belatrix_DataAccess.IConsoleSaver _consoleSaver;
        private static Belatrix_DataAccess.IFileSaver _fileSaver;

        public JobLogger(bool logToFile, bool logToConsole, bool logToDatabase,
            bool logMessage, bool logWarning, bool logError, Belatrix_DataAccess.IDataBase dataBase,
            Belatrix_DataAccess.IConsoleSaver consoleSaver, Belatrix_DataAccess.IFileSaver fileSaver)
        {
            _logError = logError;
            _logMessage = logMessage;
            _logWarning = logWarning;
            _LogToDatabase = logToDatabase;
            _logToFile = logToFile;
            _logToConsole = logToConsole;
            _dataBase = dataBase;
            _fileSaver = fileSaver;
            _consoleSaver = consoleSaver;
        }

        public bool LogMessage(string message, bool isAMessage, bool isAwarning, 
            bool isAError)
        {
            #region InitialValidations
            if (!_logToConsole && !_logToFile && !_LogToDatabase)
            {
                throw new Exception("Invalid configuration");
            }

            if ((!_logError && !_logMessage && !_logWarning) ||
                (!isAMessage && !isAwarning && !isAError))
            {
                throw new Exception("Error or Warning or Message must be specified");
            }

            if ((isAError && isAMessage) || (isAError && isAwarning) || (isAMessage && isAwarning))
            {
                throw new Exception("A message can not be more than one Type");
            }

            if (string.IsNullOrEmpty(message))
            {
                throw new Exception("Invalid input");
            }
            #endregion

            #region DataBaseLog
            if (_LogToDatabase)
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

                try
                {
                    _dataBase.SaveToDatababes(message.Trim(), typeID.ToString());
                }
                catch (Exception)
                {
                    throw new Exception("There is an issue with the database, Please try again later");
                }
                
            }
            #endregion

            #region FileLog
            if (_logToFile)
            {
                string value = string.Empty;

                if (isAError && _logError)
                {
                    value = value + DateTime.Now.ToShortDateString() + message.Trim();
                }
                if (isAwarning && _logWarning)
                {
                    value = value + DateTime.Now.ToShortDateString() + message.Trim();
                }
                if (isAMessage && _logMessage)
                {
                    value = value + DateTime.Now.ToShortDateString() + message.Trim();
                }

                _fileSaver.SaveToFile(value);
            }
            #endregion

            #region ConsolLog
            if (_logToConsole)
            {
                if (isAError && _logError)
                {
                    _consoleSaver.SaveToConsole(message.Trim(), "Red");
                }
                if (isAwarning && _logWarning)
                {
                    _consoleSaver.SaveToConsole(message.Trim(), "Yellow");
                }
                if (isAMessage && _logMessage)
                {
                    _consoleSaver.SaveToConsole(message.Trim(), "White");
                }
            }
            #endregion

            return true;
        }
    }
}

