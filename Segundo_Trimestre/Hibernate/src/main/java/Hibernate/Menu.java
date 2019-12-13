package Hibernate;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
public class Menu {
	public static void printMenu() {
		Scanner tcl=new Scanner(System.in);
		List<String> respuestas= new ArrayList<String>();
		
		String[] tablas= {"categoria","productos","pedidos","categoria","salir"};
		String[] options ={"guardar","borrar","listar"};
		
		String[] argsCategoria= {"nombre","categoria"};
		String[] argsProducto= {"id categoria","nombre","precio","producto"};
		String[] argsPedidos= {"fecha","id cliente","pedidos"};
		String[] argsClientes= {"nombre","clientes"};
		
		String[][] allArgsArrays= {argsCategoria,argsProducto,argsPedidos,argsClientes};
		System.out.println("Sobre que tabla quieres realizar la acción: ");
		int option=0;
		for(int i=0;i<tablas.length;i++) {
			System.out.println("\t"+i+"- "+tablas[i]);
		}
		option=tcl.nextInt();
		if(option!=tablas.length-1) {
			int action=0;
			System.out.println("Introduce la acción que quieres realizar:");
			for(int i=0;i<options.length;i++) {
				System.out.println("\t"+i+"- "+options[i]);
			}
			action=tcl.nextInt();
			if(action==0) {
				tcl.nextLine();
				for(int i=0; i<allArgsArrays[option].length-1;i++) {
					System.out.println("Introduce "+allArgsArrays[option][i]+" para "+allArgsArrays[option][allArgsArrays[option].length-1]+" :");
					respuestas.add(tcl.nextLine());
				}
			}
		}
		
	}
	public static void main(String[] args) {
		printMenu();
		
	}

}
