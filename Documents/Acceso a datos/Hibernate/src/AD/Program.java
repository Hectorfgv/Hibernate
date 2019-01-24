package AD;



import java.util.Date;

import org.hibernate.Session;

public class Program {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
			System.out.println("Hola");
			
			Session session = HibernateUtilities.getSessionFactory().openSession();
			session.beginTransaction();
			
			Festival f = new Festival();
			f.setNombre("Res");
			f.setLugar("Vigo");
			f.setFecha("4/8/19");
			session.save(f);
			session.getTransaction().commit();
			Festival f2 = new Festival();
			f2.setNombre("Leyendas del Rock");
			f2.setLugar("Albacete");
			f2.setFecha("17/6/19");
			
			
			session.save(f2);
			session.getTransaction().commit();
			System.out.println("Datos de festival insertados");
			
			Actuacion a = new Actuacion();
			a.setHora("1:30");
			a.setEscenario(2);
			session.save(a);
			session.getTransaction().commit();
			
			Actuacion a2 = new Actuacion();
			a2.setHora("23:00");
			a2.setEscenario(1);
			session.save(a2);
			session.getTransaction().commit();
			System.out.println("Datos de actuación insertados");
			
			Grupo g = new Grupo();
			g.setNombre("La Raíz");
			g.setEstilo("Rock");
			g.setMiembros(11);
			session.save(g);
			session.getTransaction().commit();
			
			Grupo g2 = new Grupo();
			g2.setNombre("Dragon Force");
			g2.setEstilo("Rock");
			g2.setMiembros(6);
			session.save(g2);
			session.getTransaction().commit();
			System.out.println("Datos de grupo insertados");
			
			Festival fe = session.get(Festival.class, 1);
			System.out.println("\nFestival con nombre: " + fe.getNombre() +"\nLugar "+ fe.getLugar() + "\nFecha : " + 
					fe.getFecha());
			/*Festival fes = session.get(Festival.class, 2);
			System.out.println("\nFestival con nombre: " + fe.getNombre() +"\nLugar "+ fe.getLugar() + "\nFecha : " + 
					fe.getFecha());*/
			
			Actuacion ac = session.get(Actuacion.class, 1);
			System.out.println("\nActuación con hora: " + ac.getHora() +"\ny Escenario : "+ ac.getEscenario());
			/*Actuacion act = session.get(Actuacion.class, 2);
			System.out.println("\nActuación con hora: " + ac.getHora() +"\ny Escenario : "+ ac.getEscenario());*/
			
			Grupo gr = session.get(Grupo.class, 1);
			System.out.println("\nGrupo con nombre: " + gr.getNombre() +"\nEstilo "+ gr.getEstilo() + "\nNúmero de miembros " + 
					gr.getMiembros());

			/*Grupo gru = session.get(Grupo.class, 2);
			System.out.println("\nGrupo con nombre: " + gr.getNombre() +"\nEstilo "+ gr.getEstilo() + "\nNúmero de miembros " + 
					gr.getMiembros());*/
		/*	
			Empresa e = new Empresa();
			e.setCif(6);
			e.setNombre("Florida");
			e.setEmpleados(280);
			e.setDireccion("C/Rei en Jaume I, 2");
			
			java.util.Date utilDate = new java.util.Date();
			Date dateAux = new java.util.Date(utilDate.getTime());
			Pedido p = new Pedido(1, dateAux);
			//Pedido p = new Pedido();
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
			
			
			Empresa em = session.get(Empresa.class, 13);
			System.out.println("\nEmpresa con nombre: " + em.getNombre() +"\nDirección "+ em.getDireccion() + "\nTiene " + 
					em.getEmpleados()+" empleados");
			
			Item it = session.get(Item.class, 1);
			System.out.println("\nObjeto: " + it.getNombre() +"\nCantidad: "+ it.getCantidad());
			
			Pedido pe = session.get(Pedido.class, 1);
			System.out.println("\nPedido con fecha: " + pe.getFecha().toString());
			
			*/
			session.getTransaction().commit();
			
			session.close();
			HibernateUtilities.getSessionFactory().close();
	}

}
