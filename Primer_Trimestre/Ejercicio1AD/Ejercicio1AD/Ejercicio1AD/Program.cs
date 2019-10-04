using System;
using System.Data;
using MySql.Data.MySqlClient;
namespace Ejercicio1AD
{
    class MainClass
    {
        private static IDbConnection dbConnetion = new MySqlConnection("server=localhost;database=dbprueba;user=root;password=sistemas;ssl-mode=none");

        public static void Main(string[] args){
            //Articulo ---->>> ID -> Nombre -> Categoria CAJ -> Precio BIGINT UNSIGNED
            Console.WriteLine("Opciones: \n \t 0-Salir \n \t 1-Nuevo \n \t 2-Editar \n \t 3-Borrar \n \t 4-Consultar \n \t 5-Listar");
            dbConnetion.Open();
            int option = Console.Read();
            IDbCommand dbCommand = dbConnetion.CreateCommand();
            switch (option)
            {
                case 0:
                    this.close();
                    break;
                case 1:
                    //nuevo
                    break;
                case 2:
                    //editar
                    break;
                case 3:
                    //borrar
                    break;
                case 4:
                    //consultar
                    break;
                case 5:
                    //listar
                    break;
            }
            //IDbCommand dbCommand = dbConnetion.CreateCommand();
            //dbCommand.CommandText = "select * from categoria";
            //IDataReader dataReader = dbCommand.ExecuteReader();

            //while (dataReader.Read()) {
            //    Console.WriteLine("id={0} nombre={1}",dataReader["id"],dataReader["nombre"]);
            //}

            dbConnetion.Close();
        }
        public static void Nuevo(IDbCommand dbCommand) {
            Console.WriteLine("Inserta el nombre del nuevo articulo: ");
            string nombre = Console.ReadLine();
            MySQL_Helper.DBCommand_Helper.addParameter(dbCommand, "nombre", nombre);

            Console.WriteLine("Inserta el  id de la categoría: ");
            string id_cat = Console.ReadLine();
            addParameter(dbCommand, "id_cat", id_cat);

            Console.WriteLine("Inserta el precio del articulo: ");
            string precio = Console.ReadLine();
            addParameter(dbCommand, "precio", precio);

            dbCommand.CommandText = String.Format("insert into productos (nombre,id_categoria,precio) values (@nombre,@id_cat,@precio)");
            dbCommand.ExecuteNonQuery();

        }

        public static void addParameter(IDbCommand dbCommand, string name,object value){
            IDbDataParameter dbDataParameter = dbCommand.CreateParameter();
            dbDataParameter.ParameterName = name;
            dbDataParameter.Value = value;
            dbCommand.Parameters.Add(dbDataParameter);

        }
    }
}
