using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VentaElectrodomesticos.Core.Model.Entities;

namespace VentaElectrodomesticos.Core.Repositories.Implementations
{
    /// <summary>
    /// Representa un repositorio de la entidad Funcionalidad.
    /// </summary>
    sealed class FuncionalidadesRepository : BaseRepository, IFuncionalidadesRepository
    {
        /// <summary>
        /// Retorna las funcionalidades del sistema.
        /// </summary>
        /// <returns>Coleccion de funcionalidades.</returns>
        Funcionalidad[] IFuncionalidadesRepository.List()
        {
            return ExecuteReader(StoredProcedureNames.GetFuncionalidades,
                values => new Funcionalidad
                {
                    Id = (int)values[0],
                    Descripcion = (string)values[1]
                });
        }
    }
}
