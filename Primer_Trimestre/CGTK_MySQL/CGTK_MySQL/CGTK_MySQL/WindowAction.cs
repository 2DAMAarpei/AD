using System;
using System.Collections.Generic;
using Gtk;

namespace CGTK_MySQL
{
    public partial class WindowAction : Gtk.Window
    {
        private string source;
        private List<string> campos = new List<string>();
        private List<string> valoresCampos=new List<string>();
        private List<Entry> allEntrys = new List<Entry>();
        //Constructor Consult
        public WindowAction(string source) :base(Gtk.WindowType.Toplevel)
        {
            this.source = source;
            ConstruyeVentanaConsultar();
            this.SetDefaultSize(100, 100);

            this.Build();
        }

        //Constructor Edit
        public WindowAction(string source,List<string> campos,List<string> valoresCampos) : base(Gtk.WindowType.Toplevel)
        {
            this.source = source;
            this.campos = campos;
            this.campos = campos;

            ConstruyeVentanaConsultar();
            this.SetDefaultSize(100, 100);

            this.Build();
        }

        //Build a vBox with an entry 
        private void ConstruyeVentanaConsultar() {
            VBox vBox = new VBox();
            Entry entry = new Entry();
            Button button = new Button("Enviar");
            button.Clicked += new EventHandler(Send);
            allEntrys.Add(entry);
            Label label = new Label("ID de "+source+" a consultar");
            vBox.Add(label);
            vBox.Add(entry);
            vBox.Add(button);
            this.Add(vBox);
        }

        //Build a vBox with necessary entrys for edit a row from db
        private void ConstruyeVentanaEditar(){
            VBox vBox = new VBox();
            for (int i=0;i<campos.Count;i++) {
                HBox hBox = new HBox(); 
                Label label =new Label(campos[i]);
                Entry entry = new Entry(valoresCampos[i]);
                allEntrys.Add(entry);
                hBox.Add(label);
                hBox.Add(entry);
                vBox.Add(hBox);
            }

            Button button = new Button("Enviar");
            vBox.Add(button);

            this.Add(vBox);
        }
        private void Send(object obj, EventArgs args) {
            Destroy();
        }
        public List<String> GetEntrysContent() {
            List<String> contentEntrys = new List<string>();
            foreach (Entry entry in allEntrys) {
                contentEntrys.Add(entry.Text);
            }
            return contentEntrys;
        }
    }
}
