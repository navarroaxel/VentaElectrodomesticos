using VentaElectrodomesticos.Core.Common;
using VentaElectrodomesticos.Core.Model.Entities;
using VentaElectrodomesticos.Core.Repositories;

namespace VentaElectrodomesticos.Core.Services.Implementations
{
    /// <summary>
    /// Representa un servicio de la entidad Provincia.
    /// </summary>
    sealed class ProvinciaService : IProvinciaService
    {
        /// <summary>
        /// Retorna las provincias registradas en el sistema.
        /// </summary>
        /// <returns>Coleccion de provincias.</returns>
        Provincia[] IProvinciaService.List()
        {
            return Repository.LocateIt<IProvinciasRepository>().List();
        }
    }
}
