using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VentaElectrodomesticos.Core.Model.Containers;
using VentaElectrodomesticos.Core.Model.Entities;

namespace VentaElectrodomesticos.Core.Services
{
    /// <summary>
    /// Define metodos para el servicio de empleado.
    /// </summary>
    public interface IEmpleadoService : ICrudService<Empleado>
    {
        /// <summary>
        /// Retorna los filtros para la busqueda de empleados   .
        /// </summary>
        /// <returns>Filtros para la busqueda de empleados.</returns>
        EmpleadoFiltros GetFiltros();
        /// <summary>
        /// Retorna los empleados sin usuarios asociados en el sistema.
        /// </summary>
        /// <returns>Coleccion de empleados</returns>
        Empleado[] ListWithoutUsuarios();
    }
}
