using System;
using VentaElectrodomesticos.Core.Model.Entities;

namespace VentaElectrodomesticos.Core.Repositories
{
    /// <summary>
    /// Define metodos para el repositorio de la entidad Provincia.
    /// </summary>
    internal interface IProvinciasRepository
    {
        /// <summary>
        /// Retorna las provincias registradas en el sistema.
        /// </summary>
        /// <returns>Coleccion de provincias.</returns>
        Provincia[] List();
    }
}
