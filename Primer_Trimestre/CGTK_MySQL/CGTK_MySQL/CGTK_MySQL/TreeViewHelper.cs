using System;
using System.Collections.Generic;
using Gtk;

namespace CGTK_MySQL
{
    public class TreeViewHelper
    {
        private void ConstruirTreeView(List<string> valoresColumna, List<string> campos, TreeView treeView)
        {
            LimpiarTreeView(treeView);
            //Construimos columnas
            TreeViewColumn columna = new TreeViewColumn();
            for (int i = 0; i < campos.Count; i++)
            {
                columna.Title = campos[i];
                CellRendererText celdaColumna = new CellRendererText();
                columna.PackStart(celdaColumna, true);
                treeView.AppendColumn(columna);
                columna.AddAttribute(celdaColumna, "text", i);
            }
            //Array Types
            Type[] types = new Type[campos.Count];
            for (int i=0;i<types.Length;i++) {
                types[i] = typeof(string);
            }
            //Asignamos valores a las columnas
            ListStore valoresCeldas = new ListStore(types);
            for (int i = types.Length; i <= valoresColumna.Count; i += types.Length)
            {
                Array 
                valoresCeldas.AppendValues(valoresColumna[i - 4], valoresColumna[i - 3], valoresColumna[i - 2], valoresColumna[i - 1]);
            }
            treeView.Model = valoresCeldas;
        }
        private void LimpiarTreeView(TreeView treeView)
        {
            foreach (TreeViewColumn treeViewColumn in treeView.Columns)
                treeView.RemoveColumn(treeViewColumn);
        }
    }
}
