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
    public class UsuarioBLL
    {
		public static bool Guardar(Usuario usuario)
		{
			if (!Existe(usuario.usuarioId))
				return Insertar(usuario);
			else
				return Modificar(usuario);
		}
		private static bool Insertar(Usuario usuario)
		{
			Contexto contexto = new Contexto();
			bool guardado = false;
			try
			{
				contexto.Usuarios.Add(usuario);
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

		private static bool Modificar(Usuario usuario)
		{
			Contexto contexto = new Contexto();
			bool modificado = false;
			try
			{
				contexto.Entry(usuario).State = EntityState.Modified;
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

		public static Usuario Buscar(int id)
		{
			Contexto contexto = new Contexto();
			Usuario usuario;
			try
			{
				usuario = contexto.Usuarios.Find(id);
			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				contexto.Dispose();
			}
			return usuario;
		}

		public static bool Eliminar(int id)
		{
			Contexto contexto = new Contexto();
			bool eliminado = false;
			try
			{
				var auxUsuario = contexto.Usuarios.Find(id);
				contexto.Usuarios.Remove(auxUsuario);

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

		public static List<Usuario> GetList(Expression<Func<Usuario, bool>> expression)
		{
			List<Usuario> lista = new List<Usuario>();
			Contexto contexto = new Contexto();

			try
			{
				lista = contexto.Usuarios.Where(expression).ToList();
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
				exite = contexto.Usuarios.Any(u => u.usuarioId == id);

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

		public static string NivelUsuario(string Usuario)
		{
			string nivel = "Cajero";
			Contexto db = new Contexto();
			try
			{
				nivel = db.Usuarios.Where(A => A.nombre.Equals(Usuario)).Select(A => A.nivel).FirstOrDefault();
			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				db.Dispose();
			}

			return nivel;
		}

		public static bool VerificarExistenciaYClaveDelUsuario(string NombreUsuario, string clave)
		{
			bool paso = false;
			Contexto contexto = new Contexto();

			try
			{
				if (contexto.Usuarios.Any(A => A.nombre == NombreUsuario && A.contraseña == clave))
				{
					paso = true;

				}

				if (NombreUsuario == "Administrador" && clave == "1234")
				{
					paso = true;
				}

			}
			catch (Exception)
			{
				throw;
			}
			return paso;
		}
	}
}
