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
    public class PersonaBLL
    {
        public static bool Guardar(Persona persona)
        {
            if (!Existe(persona.personaId)) //si no existe
                return Insertar(persona);
            else
                return Modificar(persona);
        }

        public static bool Insertar(Persona persona)
        {
            Contexto contexto = new Contexto();
            bool guardado = false;
            try
            {
                contexto.Personas.Add(persona);
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

        public static bool Modificar(Persona persona)
        {
            Contexto contexto = new Contexto();
            bool modificado = false;
            try
            {
                contexto.Entry(persona).State = EntityState.Modified;
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

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool eliminado = false;

            try
            {
                var auxPersona = contexto.Personas.Find(id);
                contexto.Personas.Remove(auxPersona);

                eliminado = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }

            return eliminado;
        }

        public static Persona Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Persona persona;

            try
            {
                persona = contexto.Personas.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return persona;
        }

        public static List<Persona> GetList(Expression<Func<Persona, bool>> persona)
        {
            List<Persona> lista = new List<Persona>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Personas.Where(persona).ToList();
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
        private static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool existe;
            try
            {
                existe = contexto.Personas.Any(p => p.personaId == id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return existe;
        }
    }
}
