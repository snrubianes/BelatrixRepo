using Belatrix_DataAccess;
using System;

namespace Belatrix_DataAccess
{
    public class DataBase : IDataBase
    {
        public void SaveToDatababes(string message, string typeId)
        {
            try
            {
                using (var connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DBConnectionString"]))
                {
                    var command = new System.Data.SqlClient.SqlCommand(string.Format("Insert into Log Values('{0}', {1})", message, typeId));
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
