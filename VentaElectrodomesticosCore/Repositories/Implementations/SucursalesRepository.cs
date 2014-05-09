using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using VentaElectrodomesticos.Core.Model.Entities;
using VentaElectrodomesticos.Core.Model.Containers;

namespace VentaElectrodomesticos.Core.Repositories.Implementations
{
    /// <summary>
    /// Representa un repositorio para la entidad sucursales.
    /// </summary>
    sealed class SucursalesRepository : BaseRepository, ISucursalesRepository
    {
        /// <summary>
        /// Retorna la coleccion de sucursales del sistema.
        /// </summary>
        /// <returns>Coleccion de Sucursales.</returns>
        Sucursal[] ISucursalesRepository.List()
        {
            return ExecuteReader(StoredProcedureNames.GetSucursales,
                values => new Sucursal
                {
                    Id = (int)values[0],
                    TipoSucursalId = (int)values[1],
                    Direccion = (string)values[2],
                    ProvinciaId = (int)values[3],
                    Telefono = (string)values[4]
                });
        }

        /// <summary>
        /// Retorna los filtros necesarios para buscar una sucursal.
        /// </summary>
        /// <param name="dniEmpleado">Dni del usuario loggueado.</param>
        /// <returns>Filtros para buscar sucursales.</returns>
        SucursalFiltros ISucursalesRepository.GetFiltros()
        {
            var db = GetDatabase();
            using (var cmd = db.GetStoredProcCommand(StoredProcedureNames.GetSucuralFiltros))
            {
                using (var reader = db.ExecuteReader(cmd))
                {
                    var sucursalFiltros = new SucursalFiltros();
                    sucursalFiltros.Provincias = reader.Read(values => new Provincia
                    {
                        Id = (int)values[0],
                        Descripcion = (string)values[1]
                    }).ToArray();

                    if (reader.NextResult())
                    {
                        sucursalFiltros.Sucursales = reader.Read(values => new Sucursal
                        {
                            Id = (int)values[0],
                            TipoSucursalId = (int)values[1],
                            Direccion = (string)values[2],
                            ProvinciaId = (int)values[3],
                            Telefono = (string)values[4]
                        }).ToArray();
                    }
                    return sucursalFiltros;
                }
            }
        }

        /// <summary>
        /// Retorna el tablero de control de la sucursal y el año seleccionado.
        /// </summary>
        /// <param name="sucursalId">Sucursal a analizar.</param>
        /// <param name="anio">Año a analizar.</param>
        /// <returns>Informacion de los datos del tablero de control.</returns>
        TableroControlInfo ISucursalesRepository.GetTableControl(int sucursalId, int anio)
        {
            return ExecuteReaderSingle(StoredProcedureNames.GetTableroControl,
                values =>
                {
                    if ((values[0] as int? ?? 0) == 0)
                        return null;

                    return new TableroControlInfo
                    {
                        TotalVentas = (int)values[0],
                        TotalFacturacion = values[1] as double?,
                        FacturasEfectivo = values[2] as int?,
                        MayorFactura = values[3] as double?,
                        MayorDeudor = values[4] as string,
                        VendedorAnio = values[5] as string,
                        ProductoAnio = values[6] as string,
                        FaltanteStock = values[7] as string
                    };
                },
                sucursalId,
                anio);
        }
    }
}
