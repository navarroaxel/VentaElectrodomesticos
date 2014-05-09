using VentaElectrodomesticos.Core.Model.Entities;

namespace VentaElectrodomesticos.Core.Repositories
{
    /// <summary>
    /// Define metodos para un repositorio de la entidad Producto.
    /// </summary>
    internal interface IProductosRepository : ICrudRepository<Producto>
    {
        /// <summary>
        /// Registra el ingreso de stock al producto.
        /// </summary>
        /// <param name="ingresoStock">Datos del ingreso de stock.</param>
        void AddStock(IngresoStock ingresoStock);
        /// <summary>
        /// Retorna el stock por sucursal del producto indicado.
        /// </summary>
        /// <param name="productoId">Id del producto.</param>
        /// <returns>Coleccion de stock de producto, uno por sucursal.</returns>
        ProductoStock[] GetStockSucursales(int productoId);
        /// <summary>
        /// Retorna los stocks de cada producto por sucursal.
        /// </summary>
        /// <param name="productoIds">Ids de los productos a buscar.</param>
        /// <param name="sucursalId">Id de la sucursal.</param>
        /// <returns>Coleccion de stock de producto, uno por producto.</returns>
        ProductoStock[] GetProductoStocksBySucursal(int[] productoIds, int sucursalId);
        /// <summary>
        /// Retorna la coleccion de marcas del sistema.
        /// </summary>
        /// <returns>Coleccion de marcas de productos.</returns>
        ProductoMarca[] ListMarcas();
    }
}
