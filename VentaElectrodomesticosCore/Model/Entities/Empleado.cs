using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VentaElectrodomesticos.Core.Resources;
using VentaElectrodomesticos.Core.Common;
using VentaElectrodomesticos.Core.Repositories;
using VentaElectrodomesticos.Core.Model.Containers;

namespace VentaElectrodomesticos.Core.Model.Entities
{
    public class Empleado : ICrudEntity<Empleado>, ILogicalRemovableEntity
    {
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int TipoEmpleadoId { get; set; }
        public int ProvinciaId { get; set; }
        public int SucursalId { get; set; }
        public bool Activo { get; set; }

        int ICrudEntity<Empleado>.Id { get { return Dni; } }

        void Validate()
        {
            var requiredFields = new List<string>(9);

            if (Dni <= 0)
                requiredFields.Add(MessageProvider.Dni);
            if (String.IsNullOrEmpty(Nombre))
                requiredFields.Add(MessageProvider.Nombre);
            if (String.IsNullOrEmpty(Apellido))
                requiredFields.Add(MessageProvider.Apellido);
            if (String.IsNullOrEmpty(Mail))
                requiredFields.Add(MessageProvider.Mail);
            if (String.IsNullOrEmpty(Direccion))
                requiredFields.Add(MessageProvider.Direccion);
            if (String.IsNullOrEmpty(Telefono))
                requiredFields.Add(MessageProvider.Telefono);
            if (ProvinciaId <= 0)
                requiredFields.Add(MessageProvider.Provincia);
            if (SucursalId <= 0)
                requiredFields.Add(MessageProvider.Sucursal);
            if (TipoEmpleadoId <= 0)
                requiredFields.Add(MessageProvider.TipoEmpleado);

            if (requiredFields.Count > 0)
                throw new BusinessException(MessageProviderExtensions.RequiredFields(String.Join("\n", requiredFields.ToArray())));
        }

        void ICrudEntity<Empleado>.Save()
        {
            var repo = Repository.LocateIt<IEmpleadosRepository>();
            var empleado = repo.Get(Dni);
            if (empleado != null)
                throw new BusinessException(MessageProvider.ExistEmpleado);

            Validate();
            repo.Add(this);
        }

        void ICrudEntity<Empleado>.Update(Empleado entity)
        {
            if (!Activo)
                throw new BusinessException(MessageProvider.ErrorUpdateEmpleadoDisabled);

            Nombre = entity.Nombre;
            Apellido = entity.Apellido;
            Mail = entity.Mail;
            Direccion = entity.Direccion;
            Telefono = entity.Telefono;

            Validate();
            Repository.LocateIt<IEmpleadosRepository>().Update(entity);
        }

        void ICrudEntity<Empleado>.Enable()
        {
            if (!Activo)
                Repository.LocateIt<IEmpleadosRepository>().SetEnable(Dni, true);
        }

        void ICrudEntity<Empleado>.Disable()
        {
            if (Activo)
                Repository.LocateIt<IEmpleadosRepository>().SetEnable(Dni, false);
        }

        /// <summary>
        /// Retorna las sucursales en las que puede operar el empleado.
        /// </summary>
        /// <returns>Coleccion de sucursales.</returns>
        internal Sucursal[] GetSucursalesParaOperar()
        {
            var sucursales = Repository.LocateIt<ISucursalesRepository>().List();

            if (TipoEmpleadoId == (int)TipoEmpleadoEnum.Analista)
            {
                return sucursales;
            }
            return sucursales.Where(sucursal => sucursal.Id == SucursalId).ToArray();
        }

        /// <summary>
        /// Retorna las sucursales en las que puede operar el empleado.
        /// </summary>
        /// <returns>Coleccion de sucursales.</returns>
        internal SucursalFiltros GetSucursalesPronvinciasParaOperar()
        {
            var sucursalesFiltros = Repository.LocateIt<ISucursalesRepository>().GetFiltros();

            if (TipoEmpleadoId == (int)TipoEmpleadoEnum.Analista)
            {
                return sucursalesFiltros;
            }

            sucursalesFiltros.Sucursales = sucursalesFiltros.Sucursales.Where(sucursal => sucursal.Id == SucursalId).ToArray();
            sucursalesFiltros.Provincias = sucursalesFiltros.Provincias.Where(provincia => sucursalesFiltros.Sucursales.Any(x => x.ProvinciaId == provincia.Id)).ToArray();

            return sucursalesFiltros;
        }
    }
}