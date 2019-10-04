using System;
using System.Data;
using MySql.Data.MySqlClient;
namespace MySQL_Helper
{
    public class DBCommand_Helper
    {
        public static void addParameter(IDbCommand dbCommand, string name, object value)
        {
            IDbDataParameter dbDataParameter = dbCommand.CreateParameter();
            dbDataParameter.ParameterName = name;
            dbDataParameter.Value = value;
            dbCommand.Parameters.Add(dbDataParameter);

        }
    }
}
