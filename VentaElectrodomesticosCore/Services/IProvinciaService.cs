using System;
using VentaElectrodomesticos.Core.Model.Entities;

namespace VentaElectrodomesticos.Core.Services
{
    /// <summary>
    /// Define metodos para el servicio de la entidad Provincia.
    /// </summary>
    public interface IProvinciaService
    {
        /// <summary>
        /// Retorna las provincias registradas en el sistema.
        /// </summary>
        /// <returns>Coleccion de provincias.</returns>
        Provincia[] List();
    }
}
