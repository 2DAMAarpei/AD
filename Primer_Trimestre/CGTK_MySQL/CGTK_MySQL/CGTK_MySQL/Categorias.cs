using System;
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
            WindowAction ventanaAcciones = new WindowAction("categoria");
            ventanaAcciones.Destroyed+=(sender, e) => {
                entrysText = ventanaAcciones.GetEntrysContent();
                List<string> valoresCeldas = new List<string>();
                valoresCeldas = Actions.Consult(dbCommand, campos[0], entrysText[0],"categoria");
                treeViewHelper.BuildTreeView(valoresCeldas, campos,treeview3);

            };
            ventanaAcciones.Show();

        }
    }
}
