using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VentaElectrodomesticos.Core.Common;
using VentaElectrodomesticos.Core.Resources;
using VentaElectrodomesticos.Core.Repositories;

namespace VentaElectrodomesticos.Core.Model.Entities
{
    public class Producto : ICrudEntity<Producto>, ILogicalRemovableEntity
    {
        public class ExtendedFilters
        {
            public double PrecioFrom { get; set; }
            public double PrecioTo { get; set; }
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int MarcaId { get; set; }
        public string Marca { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int CategoriaId { get; set; }
        public bool Activo { get; set; }
        public ExtendedFilters Filters { get; set; }

        public Producto()
        {
            Filters = new ExtendedFilters();
        }

        internal void AddStock(IngresoStock ingresoStock)
        {
            ingresoStock.FechaIngreso = DateTime.Now;
            ingresoStock.Validate();
            Repository.LocateIt<IProductosRepository>().AddStock(ingresoStock);
        }

        void Validate()
        {
            var requiredFields = new List<string>(9);

            if (String.IsNullOrEmpty(Nombre))
                requiredFields.Add(MessageProvider.Nombre);
            if (MarcaId <= 0)
                requiredFields.Add(MessageProvider.Marca);
            if (String.IsNullOrEmpty(Descripcion))
                requiredFields.Add(MessageProvider.Descripcion);
            if (Precio <= 0)
                requiredFields.Add(MessageProvider.Precio);
            if (CategoriaId <= 0)
                requiredFields.Add(MessageProvider.Categoria);

            if (requiredFields.Count > 0)
                throw new BusinessException(MessageProviderExtensions.RequiredFields(String.Join("\n", requiredFields.ToArray())));
        }

        internal ProductoStock[] GetStockSucursales()
        {
            return Repository.LocateIt<IProductosRepository>().GetStockSucursales(Id);
        }

        void ICrudEntity<Producto>.Save()
        {
            Validate();
            Repository.LocateIt<IProductosRepository>().Add(this);
        }

        void ICrudEntity<Producto>.Update(Producto entity)
        {
            if (!Activo)
                throw new BusinessException(MessageProvider.ErrorUpdateProductoDisabled);

            Nombre = entity.Nombre;
            Marca = entity.Marca;
            Descripcion = entity.Descripcion;
            Precio = entity.Precio;

            Validate();
            Repository.LocateIt<IProductosRepository>().Update(entity);
        }

        void ICrudEntity<Producto>.Enable()
        {
            if (!Activo)
                Repository.LocateIt<IProductosRepository>().SetEnable(Id, true);
        }

        void ICrudEntity<Producto>.Disable()
        {
            if (Activo)
                Repository.LocateIt<IProductosRepository>().SetEnable(Id, false);
        }
    }
}
