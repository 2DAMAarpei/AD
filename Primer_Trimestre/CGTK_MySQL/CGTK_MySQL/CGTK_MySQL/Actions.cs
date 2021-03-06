﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
namespace CGTK_MySQL
{
    public class Actions
    {
        public static void New(IDbCommand dbCommand, ArrayList listaCampos, ArrayList listaValores, string tabla)
        {

            for (int i=0;i<listaValores.Count;i++) {
                MySQL_Helper.DBCommand_Helper.addParameter(dbCommand, i.ToString(), listaValores[i]);
            }

            ///////////// ********* Create string for CommandText ****** /////////////
            string comando = "insert into " + tabla + " (";
            for (int i = 0; i < listaCampos.Count; i++)
            {
                if(i < listaCampos.Count) {
                    comando += listaCampos[i] + ",";
                }else {
                    comando += listaCampos[i];
                }

            }
            comando += ") values (";

            for (int i = 0; i < listaCampos.Count; i++)
            {
                if (i < listaCampos.Count)
                {
                    comando += "@" + i + ",";
                }
                else
                {
                    comando += "@" + i + ")";
                }

            }
            ////////////////////////////////////////////////////////////////////////

            dbCommand.CommandText = String.Format(comando);
            dbCommand.ExecuteNonQuery();
            dbCommand.Parameters.Clear();


        }

        public static void Edit(IDbCommand dbCommand, List<string> listaCampos, List<string> listaValores, string tabla, string campo,string valorCampo)
        {
        
            for (int i = 0; i < listaValores.Count; i++)
            {
                MySQL_Helper.DBCommand_Helper.addParameter(dbCommand, i.ToString(), listaValores[i]);
            }
                //MySQL_Helper.DBCommand_Helper.addParameter(dbCommand, campo, valorCampo);

            ///////////// ********* Create string for CommandText ****** /////////////
            System.Console.WriteLine(campo+" "+valorCampo);
            string comando = "update " + tabla + " set ";
            for (int i = 0; i < listaCampos.Count; i++)
            {
                if (i < listaCampos.Count-1)
                {
                    comando += listaCampos[i] + "=@"+i+",";
                }
                else
                {
                    comando += listaCampos[i] + "=@" + i;
                }

            }
            comando += " where "+campo+"="+Int32.Parse(valorCampo);
            ////////////////////////////////////////////////////////////////////////


            System.Console.WriteLine(comando);
            dbCommand.CommandText = String.Format(comando);
            dbCommand.ExecuteNonQuery();
            dbCommand.Parameters.Clear();


        }

        public static void Delete(IDbCommand dbCommand,string campo,string valorCampo,string tabla)
        {

            MySQL_Helper.DBCommand_Helper.addParameter(dbCommand, campo, valorCampo);

            dbCommand.CommandText = String.Format("delete from "+tabla+" where "+campo+"=@"+campo);
            dbCommand.ExecuteNonQuery();
            dbCommand.Parameters.Clear();
        }

        public static List<string> Consult(IDbCommand dbCommand,string campo,string valorCampo,string tabla)
        {
            List<string> resultado=new List<string>();

            MySQL_Helper.DBCommand_Helper.addParameter(dbCommand, campo, valorCampo);

            dbCommand.CommandText = String.Format("select * from "+tabla+" where "+campo+"=@"+campo);

            // Makes a List with all rows obtained from DB
            IDataReader reader = dbCommand.ExecuteReader();
            while (reader.Read())
            {
                for(int i=0;i<reader.FieldCount;i++){
                    resultado.Add(reader[i].ToString());
                }
            }
            reader.Close();
            ////////////////////////////////////////////

            dbCommand.Parameters.Clear();

            return resultado;

        }

        public static List<string> List(IDbCommand dbCommand, string tabla)
        {
            List<string> resultado = new List<string>();

            dbCommand.CommandText = String.Format("select * from "+tabla);

            // Makes a List with all rows obtained from DB
            IDataReader reader = dbCommand.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    resultado.Add(reader[i].ToString());
                }
            }
            reader.Close();
            ////////////////////////////////////////////

            dbCommand.Parameters.Clear();
            return resultado;

        }
    }
}
