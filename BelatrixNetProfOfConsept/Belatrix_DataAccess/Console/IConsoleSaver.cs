using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix_DataAccess
{
    public interface IConsoleSaver
    {
        void SaveToConsole(string message, string color);
    }
}
