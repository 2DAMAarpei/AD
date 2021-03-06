﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Gtk;
namespace CGTK_MySQL
{
    public partial class Categorias : Gtk.Window
    {
        private static IDbConnection dbConnection;
        private static IDbCommand dbCommand;

        private static TreeViewHelper treeViewHelper = new TreeViewHelper();
        private static List<string> campos = new List<string>() { "id", "nombre" };


        public Categorias(IDbConnection dbCon) :base(Gtk.WindowType.Toplevel){
            this.Build();
            dbConnection = dbCon;
            dbCommand = dbConnection.CreateCommand();
        }

        protected void OnAtrasClicked(object sender, EventArgs e)
        {
            MainWindow.mainWindow.Show();
            this.Destroy();
        }
        protected void OnDeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
            a.RetVal = true;
        }

        protected void OnListarClicked(object sender, EventArgs e)
        {
            List<string> valoresCampo = new List<string>();
            valoresCampo = Actions.List(dbCommand, "categoria");
            treeViewHelper.BuildTreeView(valoresCampo, campos, treeview3);
        }

        protected void OnConsultarClicked(object send, EventArgs eA)
        {
            List<string> entrysText = new List<string>();
            List<string> noneuse = new List<string>() {""};
            List<string> aux = new List<string>() {"id"};
            WindowAction ventanaAcciones = new WindowAction("categoria",aux,noneuse);
            ventanaAcciones.Destroyed+=(sender, e) => {
                entrysText = ventanaAcciones.GetEntrysContent();
                List<string> valoresCeldas = new List<string>();
                valoresCeldas = Actions.Consult(dbCommand, campos[0], entrysText[0],"categoria");
                treeViewHelper.BuildTreeView(valoresCeldas, campos,treeview3);

            };
            ventanaAcciones.Show();

        }

        protected void OnEditarClicked(object send, EventArgs eA)
        {
            try { 
                TreeSelection treeSelection = (TreeSelection)treeview3.Selection;
                treeSelection.GetSelected(out TreeIter iter);
                List<string> values = new List<string>();
                for (int i = 0; i < campos.Count; i++)
                {
                    Console.WriteLine(treeview3.Model.GetValue(iter, i).ToString());
                    values.Add(treeview3.Model.GetValue(iter, i).ToString());
                }
                List<string> copyCampos = new List<string>(campos);
                copyCampos.RemoveAt(0);
                List<string> copyValues = new List<string>(values);
                copyValues.RemoveAt(0);
                List<string> entrysText = new List<string>();
                WindowAction ventanaAcciones = new WindowAction("categoria", copyCampos, copyValues);
                ventanaAcciones.Destroyed += (sender, e) =>
                {
                    entrysText = ventanaAcciones.GetEntrysContent();
                    Actions.Edit(dbCommand, copyCampos, entrysText, "categoria", "id", values[0]);
                    List<string> valoresCeldas = new List<string>(Actions.List(dbCommand, "categoria"));
                    treeViewHelper.BuildTreeView(valoresCeldas, campos, treeview3);

                };
            }
           catch(Exception  e ) {
                Console.WriteLine(e);
                MessageDialog alert = new MessageDialog(this, DialogFlags.DestroyWithParent, MessageType.Warning, ButtonsType.Ok, "¡SELECCIONE UNA FILA PARA EDITARLA!");
                alert.Run();
                alert.Destroy();
            }

        }

        protected void OnBorrarClicked(object sender, EventArgs e)
        {
            try
            {
                TreeSelection treeSelection = (TreeSelection)treeview3.Selection;
                treeSelection.GetSelected(out TreeIter iter);
                List<string> values = new List<string>();
                for (int i = 0; i < campos.Count; i++)
                {
                    Console.WriteLine(treeview3.Model.GetValue(iter, i).ToString());
                    values.Add(treeview3.Model.GetValue(iter, i).ToString());
                }
                Actions.Delete(dbCommand, campos[0], values[0], "categoria");
                List<string> valoresCeldas = new List<string>(Actions.List(dbCommand, "categoria"));
                treeViewHelper.BuildTreeView(valoresCeldas, campos, treeview3);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageDialog alert = new MessageDialog(this, DialogFlags.DestroyWithParent, MessageType.Warning, ButtonsType.Ok, "¡ERROR AL BORRAR!");
                alert.Run();
                alert.Destroy();
            }
        }
    }
}
