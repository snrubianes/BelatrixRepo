using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Belatrix_Net_ProfOfConsept_UniTest
{
    [TestClass]
    public class JobLoggerTest
    {
        #region HappyTests
        [TestMethod]
        public void SaveToDB()
        {
            var dbSaver = new Moq.Mock<Belatrix_DataAccess.IDataBase>();
            dbSaver.Setup(x => x.SaveToDatababes("test", "1"));
            var fileSaver = new Moq.Mock<Belatrix_DataAccess.IFileSaver>();
            fileSaver.Setup(x => x.SaveToFile("test"));
            var ConsoleSaver = new Moq.Mock<Belatrix_DataAccess.IConsoleSaver>();
            ConsoleSaver.Setup(x => x.SaveToConsole("test", "White"));

            var logger = new Belatrix_Net_ProfOfConsept.JobLogger(false, false, true, true, false, false, dbSaver.Object, ConsoleSaver.Object, fileSaver.Object);

            Assert.IsTrue(logger.LogMessage("test", true, false, false));
        }

        [TestMethod]
        public void SaveToFile()
        {
            var dbSaver = new Moq.Mock<Belatrix_DataAccess.IDataBase>();
            dbSaver.Setup(x => x.SaveToDatababes("test", "1"));
            var fileSaver = new Moq.Mock<Belatrix_DataAccess.IFileSaver>();
            fileSaver.Setup(x => x.SaveToFile("test"));
            var ConsoleSaver = new Moq.Mock<Belatrix_DataAccess.IConsoleSaver>();
            ConsoleSaver.Setup(x => x.SaveToConsole("test", "White"));

            var logger = new Belatrix_Net_ProfOfConsept.JobLogger(true, false, false, true, false, false, dbSaver.Object, ConsoleSaver.Object, fileSaver.Object);
            
            Assert.IsTrue(logger.LogMessage("test", true, false, false));
        }

        [TestMethod]
        public void SaveToConsoleMessage()
        {
            var dbSaver = new Moq.Mock<Belatrix_DataAccess.IDataBase>();
            dbSaver.Setup(x => x.SaveToDatababes("test", "1"));
            var fileSaver = new Moq.Mock<Belatrix_DataAccess.IFileSaver>();
            fileSaver.Setup(x => x.SaveToFile("test"));
            var ConsoleSaver = new Moq.Mock<Belatrix_DataAccess.IConsoleSaver>();
            ConsoleSaver.Setup(x => x.SaveToConsole("test", "White"));

            var logger = new Belatrix_Net_ProfOfConsept.JobLogger(false, true, false, true, false, false, dbSaver.Object, ConsoleSaver.Object, fileSaver.Object);

            Assert.IsTrue(logger.LogMessage("test", true, false, false));
        }

        [TestMethod]
        public void SaveToConsoleError()
        {
            var dbSaver = new Moq.Mock<Belatrix_DataAccess.IDataBase>();
            dbSaver.Setup(x => x.SaveToDatababes("test", "1"));
            var fileSaver = new Moq.Mock<Belatrix_DataAccess.IFileSaver>();
            fileSaver.Setup(x => x.SaveToFile("test"));
            var ConsoleSaver = new Moq.Mock<Belatrix_DataAccess.IConsoleSaver>();
            ConsoleSaver.Setup(x => x.SaveToConsole("test", "Red"));

            var logger = new Belatrix_Net_ProfOfConsept.JobLogger(false, true, false, false, false, true, dbSaver.Object, ConsoleSaver.Object, fileSaver.Object);

            Assert.IsTrue(logger.LogMessage("test", false, false, true));
        }

        [TestMethod]
        public void SaveToConsoleWarning()
        {
            var dbSaver = new Moq.Mock<Belatrix_DataAccess.IDataBase>();
            dbSaver.Setup(x => x.SaveToDatababes("test", "1"));
            var fileSaver = new Moq.Mock<Belatrix_DataAccess.IFileSaver>();
            fileSaver.Setup(x => x.SaveToFile("test"));
            var ConsoleSaver = new Moq.Mock<Belatrix_DataAccess.IConsoleSaver>();
            ConsoleSaver.Setup(x => x.SaveToConsole("test", "Yellow"));

            var logger = new Belatrix_Net_ProfOfConsept.JobLogger(false, true, false, false, true, false, dbSaver.Object, ConsoleSaver.Object, fileSaver.Object);

            Assert.IsTrue(logger.LogMessage("test", false, true, false));
        }

        [TestMethod]
        public void SaveToConsoleFileDb()
        {
            var dbSaver = new Moq.Mock<Belatrix_DataAccess.IDataBase>();
            dbSaver.Setup(x => x.SaveToDatababes("test", "1"));
            var fileSaver = new Moq.Mock<Belatrix_DataAccess.IFileSaver>();
            fileSaver.Setup(x => x.SaveToFile("test"));
            var ConsoleSaver = new Moq.Mock<Belatrix_DataAccess.IConsoleSaver>();
            ConsoleSaver.Setup(x => x.SaveToConsole("test", "White"));

            var logger = new Belatrix_Net_ProfOfConsept.JobLogger(true, true, true, true, false, false, dbSaver.Object, ConsoleSaver.Object, fileSaver.Object);

            Assert.IsTrue(logger.LogMessage("test", true, false, false));
        }

        [TestMethod]
        public void SaveMessagesToAll()
        {
            var dbSaver = new Moq.Mock<Belatrix_DataAccess.IDataBase>();
            dbSaver.Setup(x => x.SaveToDatababes("test", "1"));
            var fileSaver = new Moq.Mock<Belatrix_DataAccess.IFileSaver>();
            fileSaver.Setup(x => x.SaveToFile("test"));
            var ConsoleSaver = new Moq.Mock<Belatrix_DataAccess.IConsoleSaver>();
            ConsoleSaver.Setup(x => x.SaveToConsole("test", "White"));

            var logger = new Belatrix_Net_ProfOfConsept.JobLogger(true, true, true, true, true, true, dbSaver.Object, ConsoleSaver.Object, fileSaver.Object);

            Assert.IsTrue(logger.LogMessage("test", true, false, false));
        }

        [TestMethod]
        public void SaveWarningsToAll()
        {
            var dbSaver = new Moq.Mock<Belatrix_DataAccess.IDataBase>();
            dbSaver.Setup(x => x.SaveToDatababes("test", "1"));
            var fileSaver = new Moq.Mock<Belatrix_DataAccess.IFileSaver>();
            fileSaver.Setup(x => x.SaveToFile("test"));
            var ConsoleSaver = new Moq.Mock<Belatrix_DataAccess.IConsoleSaver>();
            ConsoleSaver.Setup(x => x.SaveToConsole("test", "White"));

            var logger = new Belatrix_Net_ProfOfConsept.JobLogger(true, true, true, true, true, true, dbSaver.Object, ConsoleSaver.Object, fileSaver.Object);

            Assert.IsTrue(logger.LogMessage("test", false, true, false));
        }

        [TestMethod]
        public void SaveErrorToAll()
        {
            var dbSaver = new Moq.Mock<Belatrix_DataAccess.IDataBase>();
            dbSaver.Setup(x => x.SaveToDatababes("test", "1"));
            var fileSaver = new Moq.Mock<Belatrix_DataAccess.IFileSaver>();
            fileSaver.Setup(x => x.SaveToFile("test"));
            var ConsoleSaver = new Moq.Mock<Belatrix_DataAccess.IConsoleSaver>();
            ConsoleSaver.Setup(x => x.SaveToConsole("test", "White"));

            var logger = new Belatrix_Net_ProfOfConsept.JobLogger(true, true, true, true, true, true, dbSaver.Object, ConsoleSaver.Object, fileSaver.Object);

            Assert.IsTrue(logger.LogMessage("test", false, false, true));
        }
        #endregion

        #region notHappyTest
        [TestMethod]
        [ExpectedException(typeof(Exception), "Invalid configuration")]
        public void BadConfigurationLogNothing()
        {
            var dbSaver = new Moq.Mock<Belatrix_DataAccess.IDataBase>();
            dbSaver.Setup(x => x.SaveToDatababes("test", "1"));
            var fileSaver = new Moq.Mock<Belatrix_DataAccess.IFileSaver>();
            fileSaver.Setup(x => x.SaveToFile("test"));
            var ConsoleSaver = new Moq.Mock<Belatrix_DataAccess.IConsoleSaver>();
            ConsoleSaver.Setup(x => x.SaveToConsole("test", "White"));

            var logger = new Belatrix_Net_ProfOfConsept.JobLogger(false, false, true, false, false, false, dbSaver.Object, ConsoleSaver.Object, fileSaver.Object);

            logger.LogMessage("test", true, false, false);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Invalid configuration")]
        public void BadConfigurationLogToNothing()
        {
            var dbSaver = new Moq.Mock<Belatrix_DataAccess.IDataBase>();
            dbSaver.Setup(x => x.SaveToDatababes("test", "1"));
            var fileSaver = new Moq.Mock<Belatrix_DataAccess.IFileSaver>();
            fileSaver.Setup(x => x.SaveToFile("test"));
            var ConsoleSaver = new Moq.Mock<Belatrix_DataAccess.IConsoleSaver>();
            ConsoleSaver.Setup(x => x.SaveToConsole("test", "White"));

            var logger = new Belatrix_Net_ProfOfConsept.JobLogger(false, false, false, false, false, false, dbSaver.Object, ConsoleSaver.Object, fileSaver.Object);

            logger.LogMessage("test", true, false, false);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Error or Warning or Message must be specified")]
        public void BadConfigurationNoLogParameters()
        {
            var dbSaver = new Moq.Mock<Belatrix_DataAccess.IDataBase>();
            dbSaver.Setup(x => x.SaveToDatababes("test", "1"));
            var fileSaver = new Moq.Mock<Belatrix_DataAccess.IFileSaver>();
            fileSaver.Setup(x => x.SaveToFile("test"));
            var ConsoleSaver = new Moq.Mock<Belatrix_DataAccess.IConsoleSaver>();
            ConsoleSaver.Setup(x => x.SaveToConsole("test", "White"));

            var logger = new Belatrix_Net_ProfOfConsept.JobLogger(false, false, true, false, false, false, dbSaver.Object, ConsoleSaver.Object, fileSaver.Object);

            logger.LogMessage("test", false, false, false);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Invalid input")]
        public void EmptyInput()
        {
            var dbSaver = new Moq.Mock<Belatrix_DataAccess.IDataBase>();
            dbSaver.Setup(x => x.SaveToDatababes("test", "1"));
            var fileSaver = new Moq.Mock<Belatrix_DataAccess.IFileSaver>();
            fileSaver.Setup(x => x.SaveToFile("test"));
            var ConsoleSaver = new Moq.Mock<Belatrix_DataAccess.IConsoleSaver>();
            ConsoleSaver.Setup(x => x.SaveToConsole("test", "White"));

            var logger = new Belatrix_Net_ProfOfConsept.JobLogger(false, false, true, false, false, false, dbSaver.Object, ConsoleSaver.Object, fileSaver.Object);

            logger.LogMessage(string.Empty, true, false, false);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Invalid input")]
        public void NullInput()
        {
            var dbSaver = new Moq.Mock<Belatrix_DataAccess.IDataBase>();
            dbSaver.Setup(x => x.SaveToDatababes("test", "1"));
            var fileSaver = new Moq.Mock<Belatrix_DataAccess.IFileSaver>();
            fileSaver.Setup(x => x.SaveToFile("test"));
            var ConsoleSaver = new Moq.Mock<Belatrix_DataAccess.IConsoleSaver>();
            ConsoleSaver.Setup(x => x.SaveToConsole("test", "White"));

            var logger = new Belatrix_Net_ProfOfConsept.JobLogger(false, false, true, true, false, false, dbSaver.Object, ConsoleSaver.Object, fileSaver.Object);

            logger.LogMessage(null, true, false, false);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "A message can not be a Message and a Warning and An Error")]
        public void BadMessageType()
        {
            var dbSaver = new Moq.Mock<Belatrix_DataAccess.IDataBase>();
            dbSaver.Setup(x => x.SaveToDatababes("test", "1"));
            var fileSaver = new Moq.Mock<Belatrix_DataAccess.IFileSaver>();
            fileSaver.Setup(x => x.SaveToFile("test"));
            var ConsoleSaver = new Moq.Mock<Belatrix_DataAccess.IConsoleSaver>();
            ConsoleSaver.Setup(x => x.SaveToConsole("test", "White"));

            var logger = new Belatrix_Net_ProfOfConsept.JobLogger(false, false, true, false, false, false, dbSaver.Object, ConsoleSaver.Object, fileSaver.Object);

            logger.LogMessage(null, true, true, true);
        }
        #endregion

    }
}
