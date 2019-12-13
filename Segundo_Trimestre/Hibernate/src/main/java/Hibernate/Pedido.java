package Hibernate;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Table;

@Entity
@Table(name="productos")
public class Pedido {
	@Id
	private int id_prod;
    @ManyToOne
    @JoinColumn(name="id_categoria", nullable=false)
	private Categoria categoria;
	private float precio;
	private String nombre;
	public int getId_prod() {
		return id_prod;
	}
	public void setId_prod(int id_prod) {
		this.id_prod = id_prod;
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
https://stackoverflow.com/questions/3585034/how-to-map-a-composite-key-with-hibernate