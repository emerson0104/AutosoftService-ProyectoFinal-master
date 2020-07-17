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
    public class EntradaArtBLL
    {

        public static bool Guardar(EntradasArticulos entradasArticulos)
        {
            if (!Existe(entradasArticulos.EntradasArtId))
                return Insertar(entradasArticulos);
            else
                return Modificar(entradasArticulos);
        }


        private static bool Insertar(EntradasArticulos entradasArticulos)
        {
            bool paso = false;
            Contexto db = new Contexto();


            try
            {
                if (db.entradaArt.Add(entradasArticulos) != null)
                {

                    Articulos articulos = BLL.ArticuloBLL.Buscar(entradasArticulos.ArticuloId);

                    articulos.Existencia += entradasArticulos.Cantidad;

                    BLL.ArticuloBLL.Modificar(articulos);

                    db.SaveChanges();
                    paso = true;


                }

                db.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public static bool Modificar(EntradasArticulos entradasArticulos)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                EntradasArticulos EntArt = BLL.EntradaArtBLL.Buscar(entradasArticulos.EntradasArtId);
                decimal resta;

                resta = entradasArticulos.Cantidad - EntArt.Cantidad;

                Articulos articulos = BLL.ArticuloBLL.Buscar(entradasArticulos.ArticuloId);
                articulos.Existencia += resta;
                BLL.ArticuloBLL.Modificar(articulos);

                db.Entry(entradasArticulos).State = EntityState.Modified;

                if (db.SaveChanges() > 0)
                {
                    paso = true;
                }

                db.Dispose();
            }



            catch (Exception)
            {
                throw;
            }

            return paso;
        }


        public static bool Eliminar(int id)
        {

            bool paso = true;
            Contexto db = new Contexto();

            try
            {
                EntradasArticulos entradaArticulos = db.entradaArt.Find(id);

                if (entradaArticulos != null)
                {
                    Articulos articulos = BLL.ArticuloBLL.Buscar(entradaArticulos.EntradasArtId);
                    articulos.Existencia -= entradaArticulos.Cantidad;
                    BLL.ArticuloBLL.Modificar(articulos);

                    db.Entry(entradaArticulos).State = EntityState.Deleted;
                }

                if (db.SaveChanges() > 0)
                {
                    paso = true;
                    db.Dispose();
                }



            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }


        public static EntradasArticulos Buscar(int id)
        {

            Contexto db = new Contexto();
            EntradasArticulos entradasArticulos = new EntradasArticulos();

            try
            {
                entradasArticulos = db.entradaArt.Find(id);
                db.Dispose();


            }
            catch (Exception)
            {
                throw;
            }

            return entradasArticulos;
        }



        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto db = new Contexto();


            try
            {

                encontrado = db.entradaArt.Any(p => p.EntradasArtId == id);


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





        public static List<EntradasArticulos> GetList(Expression<Func<EntradasArticulos, bool>> expression)
        {
            List<EntradasArticulos> Lista = new List<EntradasArticulos>();
            Contexto db = new Contexto();
            try
            {
                Lista = db.entradaArt.Where(expression).ToList();
            }

            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Lista;

        }

    }
}
