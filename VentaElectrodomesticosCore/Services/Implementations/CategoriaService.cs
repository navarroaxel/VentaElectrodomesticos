using System.Data;
using System.Linq;
using VentaElectrodomesticos.Core.Common;
using VentaElectrodomesticos.Core.Model.Entities;
using VentaElectrodomesticos.Core.Repositories;

namespace VentaElectrodomesticos.Core.Services.Implementations
{
    /// <summary>
    /// Define metodos para el servicio de la entidad Categoria.
    /// </summary>
    class CategoriaService : ICategoriaService
    {
        /// <summary>
        /// Retorna las categorias del sistema.
        /// </summary>
        /// <returns>Coleccion de categorias.</returns>
        Categoria[] ICategoriaService.List()
        {
            var categorias = Repository.LocateIt<ICategoriasRepository>().List();

            return BuildTree(categorias);
        }

        /// <summary>
        /// Retorna los datos de las mejores categorias del Año y Sucursal.
        /// </summary>
        /// <param name="sucursalId">Sucursal a analizar.</param>
        /// <param name="anio">Año a analizar.</param>
        /// <returns>Datos de las mejores categorias.</returns>
        DataTable ICategoriaService.GetMejoresCategorias(int sucursalId, int anio)
        {
            return Repository.LocateIt<ICategoriasRepository>().GetMejoresCategorias(sucursalId, anio);
        }

        /// <summary>
        /// Genera el primer nivel del arbol de categorias.
        /// </summary>
        /// <param name="categorias">Coleccion de categorias.</param>
        /// <returns>Coleccion de categorias con estructura de arbol.</returns>
        private Categoria[] BuildTree(Categoria[] categorias)
        {
            var categoriasRoot = categorias.Where(x => !x.PadreCategoriaId.HasValue).ToArray();

            var childrenCategorias = categorias.Where(x => x.PadreCategoriaId.HasValue).ToArray();

            categoriasRoot.ForEach(x => BuildBranch(x, childrenCategorias));

            return categoriasRoot;
        }

        /// <summary>
        /// Genera un nivel de una rama del arbol de categorias.
        /// </summary>
        /// <param name="parent">Categoria padre del nivel.</param>
        /// <param name="categorias">Categorias sin insertar en el arbol.</param>
        private void BuildBranch(Categoria parent, Categoria[] categorias)
        {
            parent.Children = categorias.Where(x => x.PadreCategoriaId == parent.Id).ToArray();

            var childrenCatagorias = categorias.Where(x => x.PadreCategoriaId != parent.Id).ToArray();

            parent.Children.ForEach(x => BuildBranch(x, childrenCatagorias));
        }
    }
}
