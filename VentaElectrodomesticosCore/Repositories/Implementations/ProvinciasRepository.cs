using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VentaElectrodomesticos.Core.Model.Entities;

namespace VentaElectrodomesticos.Core.Repositories.Implementations
{
    /// <summary>
    /// Representa un repositorio la entidad Provincia.
    /// </summary>
    sealed class ProvinciasRepository : BaseRepository, IProvinciasRepository
    {
        /// <summary>
        /// Retorna las provincias registradas en el sistema.
        /// </summary>
        /// <returns>Coleccion de provincias.</returns>
        Provincia[] IProvinciasRepository.List()
        {
            return ExecuteReader(StoredProcedureNames.GetProvincias,
                values => new Provincia
                {
                    Id = (int)values[0],
                    Descripcion = (string)values[1]
                });
        }
    }
}
