package Hibernate;

import javax.persistence.*;

import org.hibernate.annotations.GenericGenerator;

@Entity
@Table(name="categorias")
public class Categoria {
	@Id
	@GenericGenerator(name="kaugen" , strategy="increment")
	private int idCat;
	private String nombre;
	public int getIdCat() {
		return idCat;
	}
	public void setIdCat(int idCat) {
		this.idCat = idCat;
	}
	public String getNombre() {
		return nombre;
	}
	public void setNombre(String nombre) {
		this.nombre = nombre;
	}
	@Override
	public String toString() {
		return " ID de la Categoria --> " + idCat + "\n Nombre --> " + nombre;
	}

}
