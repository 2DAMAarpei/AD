using System;
using System.Collections.Generic;
using Gtk;

namespace CGTK_MySQL
{
    public class TreeViewHelper
    {
        public void ConstruirTreeView(List<string> valoresColumna, List<string> campos, TreeView treeView)
        {
            LimpiarTreeView(treeView);

            //Build columns
            for (int i = 0; i < campos.Count; i++)
            {
                TreeViewColumn columna = new TreeViewColumn();
                columna.Title = campos[i];
                CellRendererText celdaColumna = new CellRendererText();
                columna.PackStart(celdaColumna, true);
                treeView.AppendColumn(columna);
                columna.AddAttribute(celdaColumna, "text", i);
            }

            //Build an array of Types
            Type[] types = new Type[campos.Count];
            for (int i=0;i<types.Length;i++) {
                types[i] = typeof(string);
            }

            //Put values in cells row by row 
            ListStore valoresCeldas = new ListStore(types);
            System.Console.Write(valoresColumna.ToString());
            for (int i = types.Length; i <= valoresColumna.Count; i += types.Length)
            {
                string[] valoresFila= new string[types.Length];
                for (int z = types.Length; z > 0; z--)
                {
                    valoresFila[i - z]=valoresColumna[i - z];

                }
                valoresCeldas.AppendValues(valoresFila);
            }
            treeView.Model = valoresCeldas;
        }

        private void LimpiarTreeView(TreeView treeView)
        {
            //Remove all columns from the TreeView
            foreach (TreeViewColumn treeViewColumn in treeView.Columns)
                treeView.RemoveColumn(treeViewColumn);
        }
    }
}
