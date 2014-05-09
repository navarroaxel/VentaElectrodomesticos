using VentaElectrodomesticos.Core.Model.Entities;
using VentaElectrodomesticos.Core.Model.Containers;

namespace VentaElectrodomesticos.Core.Services
{
    /// <summary>
    /// Define metodos para el servicio de la entidad Producto.
    /// </summary>
    public interface IProductoService : ICrudService<Producto>
    {
        /// <summary>
        /// Retorna los productos con su stock por sucursal.
        /// </summary>
        /// <param name="producto">Filtros para busqueda de productos.</param>
        /// <param name="sucursalId">Id de la sucursal.</param>
        /// <returns>Coleccion de productos con stock por sucursal.</returns>
        ProductoSucursalStock[] ListWithStock(Producto producto, int sucursalId);
        /// <summary>
        /// Retorna el stock de un producto por sucursal.
        /// </summary>
        /// <param name="productoId">Id del producto.</param>
        /// <returns>Coleccion de stock del producto.</returns>
        ProductoStock[] GetStockSucursales(int productoId);
        /// <summary>
        /// Registra un ingreso de stock en el sistema.
        /// </summary>
        /// <param name="ingresoStock">Datos del ingreso de stock.</param>
        void AddStock(IngresoStock ingresoStock);
        /// <summary>
        /// Retorna las marcas de los productos del sistema.
        /// </summary>
        /// <returns>Coleccion de marcas de productos.</returns>
        ProductoMarca[] ListMarcas();
    }
}
