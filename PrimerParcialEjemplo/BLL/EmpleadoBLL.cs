using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PrimerParcialEjemplo.DAL;
using PrimerParcialEjemplo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PrimerParcialEjemplo.BLL
{
    public class EmpleadoBLL
    {
		public static bool Guardar(Empleado empleado)
		{
			if (!Existe(empleado.empleadoId))
				return Insertar(empleado);
			else
				return Modificar(empleado);
		}
        private static bool Insertar(Empleado empleado)
        {
			Contexto contexto = new Contexto();
			bool guardado = false;
			try
			{
				contexto.Empleados.Add(empleado);
				guardado = contexto.SaveChanges() > 0;
				
			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				contexto.Dispose();
			}
			return guardado;
        }

		private static bool Modificar(Empleado empleado)
		{
			Contexto contexto = new Contexto();
			bool modificado = false;
			try
			{
				contexto.Entry(empleado).State = EntityState.Modified;
				modificado = contexto.SaveChanges() > 0;

			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				contexto.Dispose();
			}
			return modificado;
		}

		public static Empleado Buscar(int id)
		{
			Contexto contexto = new Contexto();
			Empleado empleado;
			try
			{
				empleado = contexto.Empleados.Find(id);
			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				contexto.Dispose();
			}
			return empleado;
		}

		public static bool Eliminar(int id)
		{
			Contexto contexto = new Contexto();
			bool eliminado = false;
			try
			{
				var auxEmpleado = contexto.Empleados.Find(id);
				contexto.Empleados.Remove(auxEmpleado);

				eliminado = contexto.SaveChanges() > 0;
			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				contexto.Dispose();
			}

			return eliminado;
		}

		public static List<Empleado> GetList(Expression<Func<Empleado, bool>> empleado)
		{
			List<Empleado> lista = new List<Empleado>();
			Contexto contexto = new Contexto();

			try
			{
				lista = contexto.Empleados.Where(empleado).ToList();
			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				contexto.Dispose();
			}
			return lista;
		}

		public static bool Existe(int id)
		{
			Contexto contexto = new Contexto();
			bool exite = false;
			try
			{
				exite = contexto.Empleados.Any(e => e.empleadoId == id);

			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				contexto.Dispose();
			}
			return exite;
		}

	}
}
