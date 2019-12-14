package Hibernate;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Table;

import org.hibernate.annotations.GenericGenerator;

@Entity
@Table(name="pedidos")
public class Pedido {
	@Id
	@GenericGenerator(name="kaugen" , strategy="increment")
	@GeneratedValue(generator="kaugen")
	private int idPed;
    @ManyToOne
    @JoinColumn(name="idCli", nullable=false)
	private Cliente cliente;
    private String fecha;
	public int getIdPed() {
		return idPed;
	}
	public void setIdPed(int idPed) {
		this.idPed = idPed;
	}
	public Cliente getCliente() {
		return cliente;
	}
	public void setCliente(Cliente cliente) {
		this.cliente = cliente;
	}
	public String getFecha() {
		return fecha;
	}
	public void setFecha(String fecha) {
		this.fecha = fecha;
	}
	@Override
	public String toString() {
		return "Pedido [idPed=" + idPed + ", cliente=" + cliente + ", fecha=" + fecha + "]";
	}

}
