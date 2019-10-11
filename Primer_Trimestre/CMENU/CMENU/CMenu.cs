using System;
using System.Collections.Generic;

namespace CMENU
{
    public class Menu
    {
        private static List<string> row = new List<string>();
        private static string condition = "";
        private static string title = "DEFAULT";
        private static string option = "";

        public Menu() { }

        public void renderMenu() {
            Console.WriteLine("***** " + title + " *****");
            for (int i = 0; i < row.Count; i++) {
                Console.WriteLine(i + "- " + row[i]);
            }
            Console.WriteLine("Introduce una opción:");
            option = Console.ReadLine();
            while (!esNumerico(option)||(Int32.Parse(option)<0) || Int32.Parse(option) >row.Count ){
                Console.WriteLine("Opción Invalida!!!");
                Console.WriteLine("Introduce una opción:");
                option = Console.ReadLine();
            }


        }

        public bool esNumerico(String cadena) {
            for(int i = 0; i < cadena.Length; i++) {
                Char aux = cadena[i];
                if (!Char.IsDigit(aux)) {
                    return false;
                }
            }
            return true;

        }

        public void addOption(string option){
            row.Add(option);
        }

        public void exitWhen(string conditionUser){
            condition = conditionUser;
        }
        public void addTitle(string name) {
            title = name;
        }
        public string getOption(){
            return option;
        }
    }
}
