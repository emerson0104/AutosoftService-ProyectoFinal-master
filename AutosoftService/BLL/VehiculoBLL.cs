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
    public class VehiculoBLL
    {
        public static bool Guardar(Vehiculos vehiculos)
        {
            if (!Existe(vehiculos.VehiculoId))
                return Insertar(vehiculos);
            else
                return Modificar(vehiculos);
        }


        private static bool Insertar(Vehiculos vehiculos)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.vehiculos.Add(vehiculos) != null)
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



        public static bool Modificar(Vehiculos vehiculos)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(vehiculos).State = EntityState.Modified;
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
                var eliminar = db.vehiculos.Find(id);
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


        public static Vehiculos Buscar(int id)
        {

            Contexto db = new Contexto();
            Vehiculos vehiculos = new Vehiculos();

            try
            {
                vehiculos = db.vehiculos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }


            return vehiculos;
        }


        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto db = new Contexto();


            try
            {

                encontrado = db.vehiculos.Any(p => p.VehiculoId == id);


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


        public List<Vehiculos> GetList(Expression<Func<Vehiculos, bool>> expression)
        {


            List<Vehiculos> lista = new List<Vehiculos>();
            Contexto db = new Contexto();


            try
            {
                lista = db.vehiculos.Where(expression).ToList();
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
