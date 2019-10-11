using System;
using System.Data;
using MySql.Data.MySqlClient;
using CMENU;
namespace Ejercicio1AD
{
    class MainClass
    {
        private static IDbConnection dbConnetion = new MySqlConnection("server=localhost;database=productos;user=root;password=sistemas;ssl-mode=none");

        public static void Main(string[] args){
            Menu menu = new Menu();

            menu.addTitle("Opciones para la BD");
            menu.addOption("Salir");
            menu.addOption("Nuevo");
            menu.addOption("Editar");
            menu.addOption("Borrar");
            menu.addOption("Consultar");
            menu.addOption("Listar");
            menu.exitWhen("0");
            menu.renderMenu();

            dbConnetion.Open();
            IDbCommand dbCommand = dbConnetion.CreateCommand();

            while (Int32.Parse(menu.getOption()) < 6 )
            {
                switch (Int32.Parse(menu.getOption()))
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        nuevo(dbCommand);
                        menu.renderMenu();
                        break;
                    case 2:
                        editar(dbCommand);
                        menu.renderMenu();

                        break;
                    case 3:
                        borrar(dbCommand);
                        menu.renderMenu();

                        break;
                    case 4:
                        consultar(dbCommand);
                        menu.renderMenu();

                        break;
                    case 5:
                        listar(dbCommand);
                        menu.renderMenu();

                        break;
                }
            }



            //IDbCommand dbCommand = dbConnetion.CreateCommand();
            //dbCommand.CommandText = "select * from categoria";
            //IDataReader dataReader = dbCommand.ExecuteReader();

            //while (dataReader.Read()) {
            //    Console.WriteLine("id={0} nombre={1}",dataReader["id"],dataReader["nombre"]);
            //}

            dbConnetion.Close();
        }

        public static void nuevo(IDbCommand dbCommand) {
            Console.WriteLine("Inserta el nombre del nuevo articulo: ");
            string nombre = Console.ReadLine();
            MySQL_Helper.DBCommand_Helper.addParameter(dbCommand, "nombre", nombre);

            Console.WriteLine("Inserta el  id de la categoría: ");
            string id_cat = Console.ReadLine();
            MySQL_Helper.DBCommand_Helper.addParameter(dbCommand, "id_cat", id_cat);

            Console.WriteLine("Inserta el precio del articulo: ");
            string precio = Console.ReadLine();
            MySQL_Helper.DBCommand_Helper.addParameter(dbCommand, "precio", precio);

            dbCommand.CommandText = String.Format("insert into productos (nombre,id_categoria,precio) values (@nombre,@id_cat,@precio)");
            dbCommand.ExecuteNonQuery();
            dbCommand.Parameters.Clear();


        }

        public static void editar(IDbCommand dbCommand){
            Console.WriteLine("Inserta el ID del articulo a modificar");
            int id = Int32.Parse(Console.ReadLine());
            Console.WriteLine();

            MySQL_Helper.DBCommand_Helper.addParameter(dbCommand, "id_prod", id);

            Console.WriteLine("Inserta el nuevo nombre del articulo: ");
            string nombre = Console.ReadLine();
            MySQL_Helper.DBCommand_Helper.addParameter(dbCommand, "nombre", nombre);

            Console.WriteLine("Inserta el id de la nueva categoría: ");
            int id_cat = Int32.Parse(Console.ReadLine());
            Console.WriteLine();
            MySQL_Helper.DBCommand_Helper.addParameter(dbCommand, "id_cat", id_cat);

            Console.WriteLine("Inserta el nuevo precio del articulo: ");
            float precio = float.Parse(Console.ReadLine());
            Console.WriteLine();

            MySQL_Helper.DBCommand_Helper.addParameter(dbCommand, "precio", precio);

            dbCommand.CommandText = String.Format("update productos set nombre=@nombre,id_categoria=@id_cat,precio=@precio where id_prod=@id_prod");
            dbCommand.ExecuteNonQuery();
            dbCommand.Parameters.Clear();


        }

        public static void borrar(IDbCommand dbCommand){
            Console.WriteLine("Inserta el ID del articulo a borrar");
            int id = Int32.Parse(Console.ReadLine());
            Console.WriteLine();

            MySQL_Helper.DBCommand_Helper.addParameter(dbCommand, "id_prod", id);

            dbCommand.CommandText = String.Format("delete from productos where id_prod=@id_prod");
            dbCommand.ExecuteNonQuery();
            dbCommand.Parameters.Clear();
        }

        public static void consultar(IDbCommand dbCommand){
            Console.WriteLine("Inserta el ID del articulo a consultar");
            int id = Int32.Parse(Console.ReadLine());
            Console.WriteLine();

            MySQL_Helper.DBCommand_Helper.addParameter(dbCommand, "id_prod", id);

            dbCommand.CommandText = String.Format("select * from productos where id_prod=@id_prod");

            IDataReader reader=dbCommand.ExecuteReader();

            while (reader.Read()) {
                Console.WriteLine("###########################");
                Console.WriteLine();
                Console.WriteLine("ID producto: " + reader[0]);
                Console.WriteLine("Nombre: " + reader[1]);
                Console.WriteLine("ID Categoria: " + reader[2]);
                Console.WriteLine("Precio: " + reader[3]);
                Console.WriteLine();
                Console.WriteLine("###########################");
            }
            reader.Close();
            dbCommand.Parameters.Clear();

        }

        public static void listar(IDbCommand dbCommand){
        
            dbCommand.CommandText = String.Format("select * from productos");

            IDataReader reader = dbCommand.ExecuteReader();
            Console.WriteLine("//// LISTA PRODUCTOS //// \n");
            while (reader.Read())
            {
                Console.WriteLine("###########################");
                Console.WriteLine();
                Console.WriteLine("ID producto: " + reader[0]);
                Console.WriteLine("Nombre: " + reader[1]);
                Console.WriteLine("ID Categoria: " + reader[2]);
                Console.WriteLine("Precio: " + reader[3]);
                Console.WriteLine();
                Console.WriteLine("########################### \n");
            }
            Console.WriteLine("\n///////////////////// \n");
            reader.Close();
            dbCommand.Parameters.Clear();


        }


        //public static void addParameter(IDbCommand dbCommand, string name,object value){
        //    IDbDataParameter dbDataParameter = dbCommand.CreateParameter();
        //    dbDataParameter.ParameterName = name;
        //    dbDataParameter.Value = value;
        //    dbCommand.Parameters.Add(dbDataParameter);

        //}

    }
}
