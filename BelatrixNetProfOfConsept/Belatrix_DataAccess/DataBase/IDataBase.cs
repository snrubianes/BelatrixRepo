using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix_DataAccess
{
    public interface IDataBase
    {
        void SaveToDatababes(string message, string typeId);
    }
}
