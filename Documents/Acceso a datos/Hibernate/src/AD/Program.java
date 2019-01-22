package AD;



import java.util.Date;

import org.hibernate.Session;

public class Program {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
			System.out.println("Hola");
			
			Session session = HibernateUtilities.getSessionFactory().openSession();
			session.beginTransaction();
			
			Empresa e = new Empresa();
			e.setNombre("Florida");
			e.setEmpleados(200);
			e.setDireccion("C/Rei en Jaume I, 2");
			
			Pedido p = new Pedido();
			p.setFecha(new Date());
			
			Item i = new Item();
			i.nombre=("Silla");
			i.cantidad=(30);
			
			session.save(e);
			System.out.println("Datos de empresa insertados");
			session.save(p);
			System.out.println("\nDatos de pedido insertados");
			session.save(i);
			System.out.println("\nDatos de item insertados");
			
			
			Empresa em = session.get(Empresa.class, 1);
			System.out.println("\nEmpresa con nombre: " + em.getNombre() +"\nDirección "+ em.getDireccion() + "\nTiene " + 
					em.getEmpleados()+" empleados");
			
			Item it = session.get(Item.class, 1);
			System.out.println("\nObjeto: " + it.getNombre() +"\nCantidad: "+ it.getCantidad());
			
			Pedido pe = session.get(Pedido.class, 1);
			System.out.println("\nPedido con fecha: " + pe.getFecha().toString());
			
			
			session.getTransaction().commit();
			
			session.close();
			HibernateUtilities.getSessionFactory().close();
	}

}
