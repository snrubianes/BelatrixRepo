using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix_DataAccess
{
    public interface IFileSaver
    {
        void SaveToFile(string value);
    }
}
