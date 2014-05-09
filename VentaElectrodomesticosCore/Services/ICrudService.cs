using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VentaElectrodomesticos.Core.Services
{
    /// <summary>
    /// Define metodos CRUD para los servicios de entidades.
    /// </summary>
    public interface ICrudService<TEntity>
    {
        /// <summary>
        /// Lista todas las entidades.
        /// </summary>
        /// <returns>Coleccion de entidades.</returns>
        TEntity[] List();
        /// <summary>
        /// Lista todas las entidades que cumplan con los filtros especificados.
        /// </summary>
        /// <param name="entity">Filtros.</param>
        /// <returns>Coleccion de entidades.</returns>
        TEntity[] List(TEntity entity);
        /// <summary>
        /// Registra la entidad.
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);
        /// <summary>
        /// Actualiza una entidad.
        /// </summary>
        /// <param name="entity">Entidad con datos actualizados.</param>
        void Update(TEntity entity);
        /// <summary>
        /// Realiza la baja logica de una entidad.
        /// </summary>
        /// <param name="id">Campo clave de la entidad.</param>
        void Disable(int id);
        /// <summary>
        /// Restaura una entidad con baja logica.
        /// </summary>
        /// <param name="id">Campo clave de la entidad.</param>
        void Enable(int id);
    }
}
