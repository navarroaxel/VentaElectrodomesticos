using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VentaElectrodomesticos.Core.Model.Entities;
using VentaElectrodomesticos.Core.Model.Containers;

namespace VentaElectrodomesticos.Core.Repositories
{
    /// <summary>
    /// Define metodos para el repositorio de la entidad Empleado.
    /// </summary>
    internal interface IEmpleadosRepository : ICrudRepository<Empleado>
    {
        /// <summary>
        /// Retorna todos los empleados que no tienen un usuario cargado en el sistema.
        /// </summary>
        /// <returns>Coleccion de empleados sin usuarios</returns>
        Empleado[] ListEmpleadosWithoutUsuarios();
        /// <summary>
        /// Retorna los filtros necesarios para realizar la busqueda de empleados.
        /// </summary>
        /// <returns>Objeto contenedor de los filtros.</returns>
        EmpleadoFiltros GetFiltros();
    }
}
