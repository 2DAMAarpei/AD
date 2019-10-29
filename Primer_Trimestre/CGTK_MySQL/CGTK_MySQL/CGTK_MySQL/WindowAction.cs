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

        //Constructor
        public WindowAction(string source,List<string> campos,List<string> valoresCampos) : base(Gtk.WindowType.Toplevel)
        {
            this.source = source;
            this.campos = campos;
            this.valoresCampos = valoresCampos;

            BuildWindow();
            this.SetDefaultSize(100, 100);

            this.Build();
        }

        //Build a vBox with necessary entrys
        private void BuildWindow() {
            VBox vBox = new VBox();
            Button button = new Button("Enviar");
            button.Clicked += new EventHandler(Send);
            for (int i = 0; i < campos.Count; i++)
            {
                    HBox hBox = new HBox();
                    Label label = new Label(campos[i]);
                    label.SetSizeRequest(50, 0);
                    Entry entry = new Entry(valoresCampos[i]);
                    allEntrys.Add(entry);
                    hBox.Add(label);
                    hBox.Add(entry);
                    vBox.Add(hBox);
            }

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
