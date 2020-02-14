package Hibernate;

import javax.persistence.*;

import org.hibernate.annotations.GenericGenerator;

@Entity
@Table(name="productos")
public class Producto {
	@Id
	@GenericGenerator(name="kaugen" , strategy="increment")
	private int idProd;
    @Override
	public String toString() {

		return " ID del Producto --> " + idProd + "\n ID de la Categoria --> " + categoria.getIdCat() + " \n Precio --> " + precio + "\n Nombre --> " + nombre;
	}
	@ManyToOne
    @JoinColumn(name="idCat", nullable=false)
	private Categoria categoria;
	private float precio;
	private String nombre;
	
	public int getIdProd() {
		return idProd;
	}
	public void setIdProd(int idProd) {
		this.idProd = idProd;
	}
	public Categoria getCategoria() {
		return categoria;
	}
	public void setCategoria(Categoria categoria) {
		this.categoria = categoria;
	}
	public float getPrecio() {
		return precio;
	}
	public void setPrecio(float precio) {
		this.precio = precio;
	}
	public String getNombre() {
		return nombre;
	}
	public void setNombre(String nombre) {
		this.nombre = nombre;
	}

	

}
