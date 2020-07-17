using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutosoftService.Model;
using AutosoftService.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AutosoftService.BLL
{
    public class ArticuloBLL
    {

        public static bool Guardar(Articulos articulos)
        {
            if (!Existe(articulos.ArticuloId))
                return Insertar(articulos);
            else
                return Modificar(articulos);
        }


        private static bool Insertar(Articulos articulos)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.articulos.Add(articulos) != null)
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



        public static bool Modificar(Articulos articulos)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(articulos).State = EntityState.Modified;
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
                var eliminar = db.articulos.Find(id);
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


        public static Articulos Buscar(int id)
        {

            Contexto db = new Contexto();
            Articulos articulos = new Articulos();

            try
            {
                articulos = db.articulos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return articulos;


        }

        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto db = new Contexto();


            try
            {

                encontrado = db.articulos.Any(p => p.ArticuloId == id);


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


        public List<Articulos> GetList(Expression<Func<Articulos, bool>> expression)
        {


            List<Articulos> lista = new List<Articulos>();
            Contexto db = new Contexto();


            try
            {
                lista = db.articulos.Where(expression).ToList();
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
