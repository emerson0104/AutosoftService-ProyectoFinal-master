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
    public class FacturaBLL
    {

        public static bool Guardar(Facturas facturas)
        {
            if (!Existe(facturas.FacturaId))
                return Insertar(facturas);
            else
                return Modificar(facturas);
        }


        private static bool Insertar(Facturas facturas)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.facturas.Add(facturas) != null)
                {
                    foreach (var item in facturas.Factura_Detalle)
                    {
                        var articulo = db.articulos.Find(item.ArticuloId);
                        articulo.Existencia -= item.Cantidad;
                    }

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




        public static bool Modificar(Facturas facturas)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {

                var anterior = FacturaBLL.Buscar(facturas.FacturaId);

                foreach (var item in anterior.Factura_Detalle)
                {
                    if (!facturas.Factura_Detalle.Exists(d => d.Id == item.Id))
                        db.Entry(item).State = EntityState.Deleted;
                }

                foreach (var item in facturas.Factura_Detalle)
                {
                    var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                    db.Entry(item).State = estado;
                }

                db.Entry(facturas).State = EntityState.Modified;
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
                var eliminar = db.facturas.Find(id);
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


        public static Facturas Buscar(int id)
        {
            Facturas facturas = new Facturas();
            Contexto db = new Contexto();


            try
            {
                facturas = db.facturas.Include(o => o.Factura_Detalle).Where(o => o.FacturaId == id).SingleOrDefault();
            }

            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return facturas;
        }


        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto db = new Contexto();


            try
            {

                encontrado = db.facturas.Any(p => p.FacturaId == id);


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


        public static List<Facturas> GetList(Expression<Func<Facturas, bool>> expression)
        {
            List<Facturas> Lista = new List<Facturas>();
            Contexto db = new Contexto();

            try
            {
                Lista = db.facturas.Where(expression).ToList();
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
