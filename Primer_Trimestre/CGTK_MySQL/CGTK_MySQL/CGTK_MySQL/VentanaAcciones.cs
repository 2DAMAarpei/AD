using System;
namespace CGTK_MySQL
{
    public partial class ventanaAcciones : Gtk.Window
    {
        public ventanaAcciones() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }
    }
}
