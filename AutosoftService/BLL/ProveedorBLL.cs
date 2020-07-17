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
    public class ProveedorBLL
    {
        public static bool Guardar(Proveedores proveedores)
        {
            if (!Existe(proveedores.ProveedorId))
                return Insertar(proveedores);
            else
                return Modificar(proveedores);
        }


        private static bool Insertar(Proveedores proveedores)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.proveedores.Add(proveedores) != null)
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


        public static bool Modificar(Proveedores proveedores)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(proveedores).State = EntityState.Modified;
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
                var eliminar = db.proveedores.Find(id);
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


        public static Proveedores Buscar(int id)
        {

            Contexto db = new Contexto();
            Proveedores proveedores = new Proveedores();

            try
            {
                proveedores = db.proveedores.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return proveedores;
        }


        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto db = new Contexto();


            try
            {

                encontrado = db.proveedores.Any(p => p.ProveedorId == id);


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

        public static List<Proveedores> GetList(Expression<Func<Proveedores, bool>> proveedores)
        {
            List<Proveedores> Lista = new List<Proveedores>();
            Contexto db = new Contexto();
            try
            {
                Lista = db.proveedores.Where(proveedores).ToList();
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
