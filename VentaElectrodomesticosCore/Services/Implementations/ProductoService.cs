using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VentaElectrodomesticos.Core.Model.Entities;
using VentaElectrodomesticos.Core.Common;
using VentaElectrodomesticos.Core.Repositories;
using VentaElectrodomesticos.Core.Model.Containers;
using VentaElectrodomesticos.Core.Resources;

namespace VentaElectrodomesticos.Core.Services.Implementations
{
    /// <summary>
    /// Representa un servicio para la entidad Producto.
    /// </summary>
    sealed class ProductoService : CrudService<Producto, IProductosRepository>, IProductoService
    {
        /// <summary>
        /// Retorna los productos con su stock por sucursal.
        /// </summary>
        /// <param name="producto">Filtros para busqueda de productos.</param>
        /// <param name="sucursalId">Id de la sucursal.</param>
        /// <returns>Coleccion de productos con stock por sucursal.</returns>
        ProductoSucursalStock[] IProductoService.ListWithStock(Producto producto, int sucursalId)
        {
            var repo = Repository.LocateIt<IProductosRepository>();
            var productos = repo.List(producto);

            var productoStocks = repo.GetProductoStocksBySucursal(productos.Select(x => x.Id).ToArray(), sucursalId);

            return (from prod in productos
                    select new ProductoSucursalStock
                    {
                        Producto = prod,
                        Stock = productoStocks.FirstOrDefault(x => x.ProductoId == prod.Id)
                    }).ToArray();
        }
        
        /// <summary>
        /// Retorna el stock de un producto por sucursal.
        /// </summary>
        /// <param name="productoId">Id del producto.</param>
        /// <returns>Coleccion de stock del producto.</returns>
        ProductoStock[] IProductoService.GetStockSucursales(int productoId)
        {
            var producto = Repository.LocateIt<IProductosRepository>().Get(productoId);
            if (producto == null)
                throw new BusinessException(MessageProvider.ProductoNotExist);

            return producto.GetStockSucursales();
        }
        
        /// <summary>
        /// Registra un ingreso de stock en el sistema.
        /// </summary>
        /// <param name="ingresoStock">Datos del ingreso de stock.</param>
        void IProductoService.AddStock(IngresoStock ingresoStock)
        {
            var producto = Repository.LocateIt<IProductosRepository>().Get(ingresoStock.ProductoId);
            if (producto == null)
                throw new BusinessException(MessageProvider.ProductoNotExist);

            producto.AddStock(ingresoStock);
        }
        
        /// <summary>
        /// Retorna las marcas de los productos del sistema.
        /// </summary>
        /// <returns>Coleccion de marcas de productos.</returns>
        ProductoMarca[] IProductoService.ListMarcas()
        {
            return Repository.LocateIt<IProductosRepository>().ListMarcas();
        }
    }
}
