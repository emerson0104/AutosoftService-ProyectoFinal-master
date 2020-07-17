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
    public class ClienteBLL
    {

        public static bool Guardar(Clientes clientes)
        {
            if (!Existe(clientes.ClienteId))
                return Insertar(clientes);
            else
                return Modificar(clientes);
        }


        private static bool Insertar(Clientes clientes)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.clientes.Add(clientes) != null)
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



        public static bool Modificar(Clientes clientes)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(clientes).State = EntityState.Modified;
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
                var eliminar = db.clientes.Find(id);
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


        public static Clientes Buscar(int id)
        {

            Contexto db = new Contexto();
            Clientes clientes = new Clientes();

            try
            {
                clientes = db.clientes.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }


            return clientes;
        }


        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto db = new Contexto();


            try
            {

                encontrado = db.clientes.Any(p => p.ClienteId == id);


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


        public List<Clientes> GetList(Expression<Func<Clientes, bool>> expression)
        {


            List<Clientes> lista = new List<Clientes>();
            Contexto db = new Contexto();


            try
            {
                lista = db.clientes.Where(expression).ToList();
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
