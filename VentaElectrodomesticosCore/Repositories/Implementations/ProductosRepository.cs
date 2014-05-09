using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VentaElectrodomesticos.Core.Model.Entities;

namespace VentaElectrodomesticos.Core.Repositories.Implementations
{
    /// <summary>
    /// Representa un repositorio de la entidad Producto.
    /// </summary>
    sealed class ProductosRepository : BaseRepository, IProductosRepository
    {
        Func<object[], Producto> Mapper
        {
            get
            {
                return values => new Producto
                {
                    Id = (int)values[0],
                    MarcaId = (int)values[1],
                    Marca = (string)values[2],
                    Nombre = (string)values[3],
                    Descripcion = (string)values[4],
                    CategoriaId = (int)values[5],
                    Precio = values[6] == DBNull.Value ? 0 : (double)values[6],
                    Activo = (bool)values[7]
                };
            }
        }

        Producto ICrudRepository<Producto>.Get(int id)
        {
            return ExecuteReaderSingle(StoredProcedureNames.GetProducto, Mapper, id);
        }

        Producto[] ICrudRepository<Producto>.List()
        {
            return ExecuteReader(StoredProcedureNames.GetProductos, Mapper);
        }

        Producto[] ICrudRepository<Producto>.List(Producto producto)
        {
            return ExecuteReader(StoredProcedureNames.GetProductosByFiltros, Mapper, producto.Id, producto.Nombre, producto.CategoriaId, producto.Filters.PrecioFrom, producto.Filters.PrecioTo, producto.Activo ? (bool?)true : null); 
        }

        void ICrudRepository<Producto>.Add(Producto producto)
        {
            ExecuteNonQuery(StoredProcedureNames.AddProducto, producto.MarcaId, producto.Nombre, producto.Descripcion, producto.CategoriaId, producto.Precio);
        }

        void ICrudRepository<Producto>.Update(Producto producto)
        {
            ExecuteNonQuery(StoredProcedureNames.UpdateProducto, producto.Id, producto.MarcaId, producto.Nombre, producto.Descripcion, producto.Precio);
        }

        void ICrudRepository<Producto>.SetEnable(int id, bool enable)
        {
            ExecuteNonQuery(StoredProcedureNames.SetEnableProducto, id, enable);
        }

        /// <summary>
        /// Registra el ingreso de stock al producto.
        /// </summary>
        /// <param name="ingresoStock">Datos del ingreso de stock.</param>
        void IProductosRepository.AddStock(IngresoStock ingresoStock)
        {
            ExecuteNonQuery(StoredProcedureNames.AddStock,
                ingresoStock.FechaIngreso,
                ingresoStock.SucursalId,
                ingresoStock.ProductoId,
                ingresoStock.DniEmpleado,
                ingresoStock.Cantidad);
        }

        /// <summary>
        /// Retorna la coleccion de marcas del sistema.
        /// </summary>
        /// <returns>Coleccion de marcas de productos.</returns>
        ProductoMarca[] IProductosRepository.ListMarcas()
        {
            return ExecuteReader(StoredProcedureNames.GetMarcas,
                values => new ProductoMarca
                {
                    Id = (int)values[0],
                    Descripcion = (string)values[1]
                });
        }

        /// <summary>
        /// Retorna el stock por sucursal del producto indicado.
        /// </summary>
        /// <param name="productoId">Id del producto.</param>
        /// <returns>Coleccion de stock de producto, uno por sucursal.</returns>
        ProductoStock[] IProductosRepository.GetStockSucursales(int productoId)
        {
            return ExecuteReader(StoredProcedureNames.GetProductoStocks,
                values => new ProductoStock
                {
                    ProductoId = (int)values[0],
                    SucursalId = (int)values[1],
                    Cantidad = (int)values[2]
                },
                productoId);
        }

        /// <summary>
        /// Retorna los stocks de cada producto por sucursal.
        /// </summary>
        /// <param name="productoIds">Ids de los productos a buscar.</param>
        /// <param name="sucursalId">Id de la sucursal.</param>
        /// <returns>Coleccion de stock de producto, uno por producto.</returns>
        ProductoStock[] IProductosRepository.GetProductoStocksBySucursal(int[] ids, int sucursalId)
        {
            return ExecuteReader(StoredProcedureNames.GetProductoStocksBySucursal,
                values => new ProductoStock
                {
                    ProductoId = (int)values[0],
                    SucursalId = (int)values[1],
                    Cantidad = (int)values[2]
                },
                sucursalId,
                ids.ToCommaSeparatedString());
        }
    }
}
