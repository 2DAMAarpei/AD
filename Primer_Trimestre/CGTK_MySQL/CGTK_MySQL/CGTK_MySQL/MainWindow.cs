using System;
using Gtk;
using CGTK_MySQL;
using System.Data;
using MySql.Data.MySqlClient;
public partial class MainWindow : Gtk.Window
{
    private static IDbConnection dbConnetion = new MySqlConnection("server=localhost;database=productos;user=root;password=sistemas;ssl-mode=none");
    public static Window mainWindow;
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
        dbConnetion.Open();


    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
        dbConnetion.Close();
    }

    protected void OnCategoriaClicked(object sender, EventArgs e)
    {
        Categorias ventanaCategorias = new Categorias(dbConnetion);
        ventanaCategorias.Show();
        this.Hide();
        mainWindow = this;
    }

    protected void OnProductosClicked(object sender, EventArgs e)
    {
        Productos ventanaProductos = new Productos(dbConnetion);
        ventanaProductos.Show();
        this.Hide();
        mainWindow = this;
    }
}








