using System;
using System.Collections.Generic;
using Gtk;

namespace CGTK_MySQL
{
    public class TreeViewHelper
    {
        public void BuildTreeView(List<string> valoresCelda, List<string> campos, TreeView treeView)
        {
            ClearTreeView(treeView);

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
            for (int i = 0; i < types.Length; i++)
            {
                types[i] = typeof(string);
            }


            //Put values in cells row by row 
            try
            {
                ListStore valoresCeldas = new ListStore(types);
                for (int i = types.Length; i <= valoresCelda.Count; i += types.Length)
                {
                
                    string[] valoresFila = new string[valoresCelda.Count];

                    for (int z = types.Length; z > 0; z--)
                    {
                        Console.WriteLine("i:" + i + " z: " + z + " ---- " + valoresCelda[i - z]);
                        valoresFila[i - z] = valoresCelda[i - z];

                    }
                    valoresCeldas.AppendValues(valoresFila);
                }
                treeView.Model = valoresCeldas;

            }
            catch (Exception e)
            {
                Console.WriteLine("Values " + e);
            }
        }
    private void ClearTreeView(TreeView treeView)
        {
            //Remove all columns from the TreeView
            foreach (TreeViewColumn treeViewColumn in treeView.Columns)
                treeView.RemoveColumn(treeViewColumn);
        }
    }
}
