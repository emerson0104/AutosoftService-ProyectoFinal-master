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
    public class PedidoBLL
    {
        public static bool Guardar(Pedidos pedidos)
        {
            if (!Existe(pedidos.PedidoId))
                return Insertar(pedidos);
            else
                return Modificar(pedidos);
        }


        private static bool Insertar(Pedidos pedidos)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.pedidos.Add(pedidos) != null)
                {
                    foreach (var item in pedidos.Pedido_Detalle)
                    {
                        var proveedor = db.proveedores.Find(item.ProveedorId);

                        proveedor.CantidadPedidos += 1;
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



        public static bool Modificar(Pedidos pedidos)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var anterior = PedidoBLL.Buscar(pedidos.PedidoId);

                foreach (var item in anterior.Pedido_Detalle)
                {
                    if (!pedidos.Pedido_Detalle.Exists(d => d.Id == item.Id))
                        db.Entry(item).State = EntityState.Deleted;
                }

                foreach (var item in pedidos.Pedido_Detalle)
                {
                    var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                    db.Entry(item).State = estado;
                }


                db.Entry(pedidos).State = EntityState.Modified;
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
                var eliminar = db.pedidos.Find(id);
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

        public static Pedidos Buscar(int id)
        {
            Pedidos pedidos = new Pedidos();
            Contexto db = new Contexto();

            try
            {
                pedidos = db.pedidos.Include(o => o.Pedido_Detalle).Where(o => o.PedidoId == id).SingleOrDefault();
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return pedidos;

        }



        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto db = new Contexto();


            try
            {

                encontrado = db.pedidos.Any(p => p.PedidoId == id);


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


        public static List<Pedidos> GetList(Expression<Func<Pedidos, bool>> expression)
        {
            List<Pedidos> Lista = new List<Pedidos>();
            Contexto db = new Contexto();
            try
            {
                Lista = db.pedidos.Where(expression).ToList();
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
