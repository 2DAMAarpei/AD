package Hibernate;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

import org.hibernate.annotations.GenericGenerator;
public class Menu {
	private static EntityManagerFactory emf = Persistence.createEntityManagerFactory("hibernate");
	private static  boolean finished = false;
	public static void printMenu() {
		Scanner tcl=new Scanner(System.in);
		List<String> respuestas= new ArrayList<String>();
		
		String[] tablas= {"categorias","productos","pedidos","clientes","lineasPedido","salir"};
		String[] options ={"guardar","borrar","listar","salir"};
		
		String[] argsCategoria= {"nombre","categoria"};
		String[] argsProducto= {"id categoria","nombre","precio","producto"};
		String[] argsPedidos= {"fecha","id cliente","pedidos"};
		String[] argsClientes= {"nombre","clientes"};
		String[] argsLineasPedidos= {"id pedido","id producto","lineasPedido"};
		
		String[][] allArgsArrays= {argsCategoria,argsProducto,argsPedidos,argsClientes,argsLineasPedidos};
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
			switch(action) {
				case 0:
					tcl.nextLine();
					for(int i=0; i<allArgsArrays[option].length-1;i++) {
						System.out.println("Introduce "+allArgsArrays[option][i]+" para "+allArgsArrays[option][allArgsArrays[option].length-1]+" :");
						respuestas.add(tcl.nextLine());
					}
					respuestas.add(Integer.toString(option));
					save(respuestas);
					break;
				case 1:
					System.out.println("Introduce el id de la fila a borrar:");
					int id=tcl.nextInt();
					delete(tablas[option],id);
					break;
				case 2:
					list(tablas[option]);
					break;
				default:
					finished = true;
					break;
			}

		}else {
			finished = true;
		}
		
	}
	public static void main(String[] args) {
		while(!finished) {
			printMenu();
		}
		
	}
	public static EntityManager getEntityManager() {
	    return emf.createEntityManager();
	}
	public static void save(List<String> data) {
	    EntityManager em = getEntityManager(); 
	    em.getTransaction().begin();
	    switch (Integer.parseInt(data.get(data.size()-1))){
	    	case 0:
			    Categoria categoria = new Categoria();
			    categoria.setNombre(data.get(0));
			    em.persist(categoria);
			    em.getTransaction().commit();
			    break;
	    	case 1:
			    Producto producto = new Producto();
			    Categoria categoriaProd=new Categoria();
			    categoriaProd.setIdCat(Integer.parseInt(data.get(0)));	
			    producto.setCategoria(categoriaProd);
			    producto.setNombre(data.get(1));
			    producto.setPrecio(Float.parseFloat(data.get(2)));
			    em.persist(producto);
			    em.getTransaction().commit();
			    break;
	    	case 2:
			    Pedido pedido = new Pedido();
			    pedido.setFecha(data.get(0));
			    Cliente clientePed=new Cliente();
			    clientePed.setIdCli(Integer.parseInt(data.get(1)));
			    pedido.setCliente(clientePed);
			    em.persist(pedido);
			    em.getTransaction().commit();
			    break;
	    	case 3:
			    Cliente cliente = new Cliente();
			    cliente.setNombre(data.get(0));
			    em.persist(cliente);
			    em.getTransaction().commit();
			    break;
	    	case 4:
			    LineasPedido lineaPedido = new LineasPedido();
			    Pedido pedidoLin=new Pedido();
			    pedidoLin.setIdPed(Integer.parseInt(data.get(0)));
			    Producto productoLin=new Producto();
			    productoLin.setIdProd(Integer.parseInt(data.get(1)));

			    lineaPedido.setPedido(pedidoLin);
			    lineaPedido.setProducto(productoLin);

			    em.persist(lineaPedido);
			    em.getTransaction().commit();
	    		break;
	    }
	    System.out.println("¡Guardado!");

	}
	public static void delete(String tabla,int id) {
		    String parsedTabla=tabla.substring(0,1).toUpperCase();
		    if(tabla.substring(tabla.length()-1).equals("s")) 
		    	parsedTabla+=tabla.substring(1,tabla.length()-1);
		    else
		    	parsedTabla+=tabla.substring(1,tabla.length());
		    try {
				Class target=Class.forName("Hibernate."+parsedTabla);
				
			    EntityManager em =getEntityManager();
			    em.getTransaction().begin();
			    em.remove(em.find(target.newInstance().getClass(), new Integer(id)));
			    em.getTransaction().commit();
		    }catch(Exception e) {
		    	System.out.println("No se puede borrar la fila ya que depende más datos de esta!");
		    }

		
	}
	public static void list(String tabla) {
	    EntityManager em = getEntityManager();
	    String parsedTabla=tabla.substring(0,1).toUpperCase();
	    if(tabla.substring(tabla.length()-1).equals("s")) 
	    	parsedTabla+=tabla.substring(1,tabla.length()-1);
	    else
	    	parsedTabla+=tabla.substring(1,tabla.length());
	    List<?> resultados = em.createQuery("from "+parsedTabla).getResultList();
	    for (Object object : resultados) {
			System.out.println(object.toString());
		}
	    try {
		    Class c =Class.forName("Hibernate.Categoria");
		    System.out.println(c.newInstance().getClass());
	    }catch(Exception e) {
	    	e.printStackTrace();
	    }

	}



}
