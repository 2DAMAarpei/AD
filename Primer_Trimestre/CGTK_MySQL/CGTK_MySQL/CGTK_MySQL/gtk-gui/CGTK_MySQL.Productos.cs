
// This file has been generated by the GUI designer. Do not modify.
namespace CGTK_MySQL
{
	public partial class Productos
	{
		private global::Gtk.VBox vbox1;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gtk.TreeView treeview2;

		private global::Gtk.Button listar;

		private global::Gtk.Button consutar;

		private global::Gtk.Button editar;

		private global::Gtk.Button borrar;

		private global::Gtk.Button atras;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget CGTK_MySQL.Productos
			this.Name = "CGTK_MySQL.Productos";
			this.Title = global::Mono.Unix.Catalog.GetString("Productos");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child CGTK_MySQL.Productos.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.treeview2 = new global::Gtk.TreeView();
			this.treeview2.CanFocus = true;
			this.treeview2.Name = "treeview2";
			this.GtkScrolledWindow.Add(this.treeview2);
			this.vbox1.Add(this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.GtkScrolledWindow]));
			w2.Position = 0;
			// Container child vbox1.Gtk.Box+BoxChild
			this.listar = new global::Gtk.Button();
			this.listar.CanFocus = true;
			this.listar.Name = "listar";
			this.listar.UseUnderline = true;
			this.listar.Label = global::Mono.Unix.Catalog.GetString("Listar");
			this.vbox1.Add(this.listar);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.listar]));
			w3.Position = 1;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.consutar = new global::Gtk.Button();
			this.consutar.CanFocus = true;
			this.consutar.Name = "consutar";
			this.consutar.UseUnderline = true;
			this.consutar.Label = global::Mono.Unix.Catalog.GetString("Consultar");
			this.vbox1.Add(this.consutar);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.consutar]));
			w4.Position = 2;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.editar = new global::Gtk.Button();
			this.editar.CanFocus = true;
			this.editar.Name = "editar";
			this.editar.UseUnderline = true;
			this.editar.Label = global::Mono.Unix.Catalog.GetString("Editar");
			this.vbox1.Add(this.editar);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.editar]));
			w5.Position = 3;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.borrar = new global::Gtk.Button();
			this.borrar.CanFocus = true;
			this.borrar.Name = "borrar";
			this.borrar.UseUnderline = true;
			this.borrar.Label = global::Mono.Unix.Catalog.GetString("Borrar");
			this.vbox1.Add(this.borrar);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.borrar]));
			w6.Position = 4;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.atras = new global::Gtk.Button();
			this.atras.CanFocus = true;
			this.atras.Name = "atras";
			this.atras.UseUnderline = true;
			this.atras.Label = global::Mono.Unix.Catalog.GetString("Atrás");
			this.vbox1.Add(this.atras);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.atras]));
			w7.Position = 5;
			w7.Expand = false;
			w7.Fill = false;
			this.Add(this.vbox1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 710;
			this.DefaultHeight = 542;
			this.Show();
			this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
			this.atras.Clicked += new global::System.EventHandler(this.OnAtrasClicked);
		}
	}
}