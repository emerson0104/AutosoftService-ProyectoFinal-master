using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutosoftService.DAL;
using AutosoftService.Model;
using Microsoft.EntityFrameworkCore;

namespace AutosoftService.BLL
{
    public class UsuarioBLL
    {
        public static bool Guardar(Usuarios usuarios)
        {
            if (!Existe(usuarios.UsuarioId))
                return Insertar(usuarios);
            else
                return Modificar(usuarios);
        }


        private static bool Insertar(Usuarios usuarios)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.usuarios.Add(usuarios) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }



        public static bool Modificar(Usuarios usuarios)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(usuarios).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }


        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var eliminar = db.usuarios.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = db.SaveChanges() > 0;
            }

            catch (Exception)
            {
                throw;
            }

            finally
            {
                db.Dispose();
            }

            return paso;
        }


        public static Usuarios Buscar(int id)
        {

            Contexto db = new Contexto();
            Usuarios usuarios = new Usuarios();

            try
            {
                usuarios = db.usuarios.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }


            return usuarios;
        }


        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto db = new Contexto();


            try
            {

                encontrado = db.usuarios.Any(p => p.UsuarioId == id);


            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return encontrado;

        }


        public List<Usuarios> GetList(Expression<Func<Usuarios, bool>> expression)
        {


            List<Usuarios> lista = new List<Usuarios>();
            Contexto db = new Contexto();


            try
            {
                lista = db.usuarios.Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                db.Dispose();

            }

            return lista;
        }


    }
}
