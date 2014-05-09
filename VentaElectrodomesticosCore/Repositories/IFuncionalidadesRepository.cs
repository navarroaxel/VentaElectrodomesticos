using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VentaElectrodomesticos.Core.Model.Entities;

namespace VentaElectrodomesticos.Core.Repositories
{
    /// <summary>
    /// Define metodos para el repositorio de la entidad Funcionalidad.
    /// </summary>
    internal interface IFuncionalidadesRepository
    {
        /// <summary>
        /// Retorna las funcionalidades del sistema.
        /// </summary>
        /// <returns>Coleccion de funcionalidades.</returns>
        Funcionalidad[] List();
    }
}
