package maps;
import javax.persistence.*;
@Entity
@Table(name = "pedido")
public class Pedido {
	private int idCliente;
	
	public Pedido() {}
	public Pedido(int idCliente) {
		this.idCliente=idCliente;
	}
    @Id
    @Column(name = "id_pedido")
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    
	public int getIdCliente() {
		return idCliente;
	}
	
	public void setIdCliente(int idCliente) {
		this.idCliente = idCliente;
	}

}
