using Ejercicio1_2020_3.DAL;
using Ejercicio1_2020_3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ejercicio1_2020_3.BLL
{
    public class PersonasBLL
    {
        public static bool Guardar(Personas personas)
        {
            if (!Existe(personas.PersonaId))
                return Insertar(personas);
            else
            {
                return Modificar(personas);
            }
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Estudiantes.Any(e => e.EstudianteId == id);
            }catch(Exception)
            {
                throw;
            }finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }

        private static bool Insertar(Personas persona)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Personas.Add(persona);
                paso = contexto.SaveChanges() > 0;

            }catch(Exception)
            {
                throw;

            }finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Personas personas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(personas).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;

        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var persona = contexto.Personas.Find(id);
                if (persona != null)
                {
                    contexto.Personas.Remove(persona);
                    paso = contexto.SaveChanges() > 0;
                }
            }catch(Exception)
            {
                throw;
            }finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Personas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Personas personas;
            try
            {
                personas = contexto.Personas.Find(id);
            }catch(Exception)
            {
                throw;
            }finally
            {
                contexto.Dispose();
            }
            return personas;
        }

        public static List<Personas> GetList(Expression<Func<Personas, bool>> persona)
        {
            List<Personas> lista = new List<Personas>();
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
    }
}
