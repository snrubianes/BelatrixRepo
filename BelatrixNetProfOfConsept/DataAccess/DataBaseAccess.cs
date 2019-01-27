using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataBaseAccess
    {
        public void SaveToDatababes(string message, string typeId)
        {
            using (var connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]))
            {
                try
                {
                    var command = new System.Data.SqlClient.SqlCommand(string.Format("Insert into Log Values('{0}', {1})", message, typeId));
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
    }
}
