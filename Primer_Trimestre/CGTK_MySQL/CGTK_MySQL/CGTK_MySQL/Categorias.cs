using System;
using System.Data;
using Gtk;
namespace CGTK_MySQL
{
    public partial class Categorias : Gtk.Window
    {
        private static IDbConnection dbConnection;
        public Categorias(IDbConnection dbCon) :base(Gtk.WindowType.Toplevel){
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
