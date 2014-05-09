using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VentaElectrodomesticos.Core.Model.Containers;
using VentaElectrodomesticos.Core.Model.Entities;
using VentaElectrodomesticos.Core.Common;
using VentaElectrodomesticos.Core.Repositories;

namespace VentaElectrodomesticos.Core.Services.Implementations
{
    sealed class EmpleadoService : CrudService<Empleado, IEmpleadosRepository>, IEmpleadoService
    {
        /// <summary>
        /// Retorna los filtros para la busqueda de empleados   .
        /// </summary>
        /// <returns>Filtros para la busqueda de empleados.</returns>
        Empleado[] IEmpleadoService.ListWithoutUsuarios()
        {
            return Repository.LocateIt<IEmpleadosRepository>().ListEmpleadosWithoutUsuarios();
        }

        /// <summary>
        /// Retorna los filtros para la busqueda de empleados   .
        /// </summary>
        /// <returns>Filtros para la busqueda de empleados.</returns>
        EmpleadoFiltros IEmpleadoService.GetFiltros()
        {
            return Repository.LocateIt<IEmpleadosRepository>().GetFiltros();
        }
    }
}
