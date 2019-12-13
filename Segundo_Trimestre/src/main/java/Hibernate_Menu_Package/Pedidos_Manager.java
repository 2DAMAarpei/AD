package Hibernate_Menu_Package;
import org.hibernate.Session;

import org.hibernate.SessionFactory;
import org.hibernate.boot.MetadataSources;
import org.hibernate.boot.registry.StandardServiceRegistry;
import org.hibernate.boot.registry.StandardServiceRegistryBuilder;

import maps.Categoria;

import java.time.LocalDateTime;
import java.util.List;
import java.util.Scanner;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
public class Pedidos_Manager {
    protected static EntityManagerFactory entity;

	public static void main(String[] args) {
		EntityManagerFactory entityManagerFactory = Persistence.createEntityManagerFactory("serpis.ad.ghibernate");
		
		Categoria categoria = new Categoria();
		categoria.setNombre("cat " + LocalDateTime.now());
		
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		entityManager.persist(categoria);
		
		List<Categoria> categorias = entityManager.createQuery("from Categoria order by Id", Categoria.class).getResultList();
		show(categorias);
		entityManager.getTransaction().commit();
		entityManager.close();
		
		
		entityManagerFactory.close();
	}

	private static void show(List<Categoria> categorias) {
		for (Categoria categoria : categorias)
			System.out.printf("%3d %s %n", categoria.getId(), categoria.getNombre());		
}
}
