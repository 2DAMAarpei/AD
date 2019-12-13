package maps;

import java.util.Scanner;

import org.hibernate.SessionFactory;
import org.hibernate.boot.MetadataSources;
import org.hibernate.boot.registry.StandardServiceRegistry;
import org.hibernate.boot.registry.StandardServiceRegistryBuilder;

import Hibernate_Menu_Package.Pedidos_Manager;

public class Cliente {
	private String nombre;
    protected SessionFactory sessionFactory;

	public Cliente(String nombre) {
		this.nombre=nombre;
	}

	public static void main(String[] args) {
		Scanner tcl=new Scanner(System.in);
		System.out.println("Introduce el id del cliente: ");
		int idCliente=tcl.nextInt();
		String resp="";
		Pedidos_Manager manager=new Pedidos_Manager();
		manager.setup();
		
		int numeroLinea=0;
		do {
			System.out.println("Introduce el nombre del producto");
			String producto=tcl.nextLine();
			numeroLinea++;
			System.out.println("¿Quieres introducir más productos? Si/No");
			resp=tcl.nextLine();
			
		}while(resp.equalsIgnoreCase("Si"));

		
	}
	public void setup() {
		final StandardServiceRegistry registry = new StandardServiceRegistryBuilder()
				.configure() // configures settings from hibernate.cfg.xml
		        .build();
		try {
			sessionFactory=new MetadataSources(registry).buildMetadata().buildSessionFactory();
		}catch (Exception e) {
		    StandardServiceRegistryBuilder.destroy(registry);
		    e.printStackTrace();
		}
		
	}

}
