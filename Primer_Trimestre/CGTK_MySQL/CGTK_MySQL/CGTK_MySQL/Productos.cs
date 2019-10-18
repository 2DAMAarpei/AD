using System;
using System.Collections.Generic;
using System.Data;
using Gtk;
namespace CGTK_MySQL
{
    public partial class Productos : Gtk.Window
    {
        //private static TreeView treeView = new TreeView();
        private static IDbConnection dbConnection;
        private static List<string> campos = new List<string>() { "id_prod", "id_categoria", "nombre", "precio" };
        public Productos(IDbConnection dbCon) : base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            dbConnection = dbCon;
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


    }

}
