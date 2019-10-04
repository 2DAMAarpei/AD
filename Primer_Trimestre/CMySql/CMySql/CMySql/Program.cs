using System;
using System.Data;
using MySql.Data.MySqlClient;
namespace CMySql
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Accediendo a la base de datos.");
            IDbConnection dbConnetion = new MySqlConnection("server=localhost;database=dbprueba;user=root;password=sistemas;ssl-mode=none");
            dbConnetion.Open();
            //IDbCommand dbCommand = dbConnetion.CreateCommand();
            //dbCommand.CommandText = "select * from categoria";
            //IDataReader dataReader = dbCommand.ExecuteReader();

            //while (dataReader.Read()) {
            //    Console.WriteLine("id={0} nombre={1}",dataReader["id"],dataReader["nombre"]);
            //}
            IDbCommand dbCommand = dbConnetion.CreateCommand();
            string nombre = "nuevo" + DateTime.Now;
            dbCommand.CommandText = String.Format("insert into categoria (nombre) values ('{0}')",nombre);
            dbCommand.ExecuteNonQuery();

            dbConnetion.Close();
        }
    }
}
