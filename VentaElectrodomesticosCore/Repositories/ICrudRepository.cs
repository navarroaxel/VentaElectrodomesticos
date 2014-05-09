namespace VentaElectrodomesticos.Core.Repositories
{
    /// <summary>
    /// Define metodos para repositorios de entidades CRUD.
    /// </summary>
    /// <typeparam name="TEntity">Entidad del repositorio.</typeparam>
    interface ICrudRepository<TEntity>
    {
        /// <summary>
        /// Retorna la entidad con el ID indicado.
        /// </summary>
        /// <param name="id">Campo clave de la entidad.</param>
        /// <returns>entidad con el id indicado.</returns>
        TEntity Get(int id);
        /// <summary>
        /// Retorna las entidades desde la DB.
        /// </summary>
        /// <returns>Coleccion de la entidad.</returns>
        TEntity[] List();
        /// <summary>
        /// Retorna las entidades desde la DB que cumplan con los filtros especificados.
        /// </summary>
        /// <param name="entity">Entidad con valores de filtro.</param>
        /// <returns>Coleccion de la entidad.</returns>
        TEntity[] List(TEntity entity);
        /// <summary>
        /// Persiste una entidad en la DB.
        /// </summary>
        /// <param name="entity">Entidad a persistir en DB.</param>
        void Add(TEntity entity);
        /// <summary>
        /// Actualiza los datos de la entidad en la DB.
        /// </summary>
        /// <param name="entity">Entidad a actualizar en la DB.</param>
        void Update(TEntity entity);
        /// <summary>
        /// Actualiza el estado de baja logica de la entidad en la DB.
        /// </summary>
        /// <param name="id">Clave de la entidad.</param>
        /// <param name="enable">Estado que tomara la entidad.</param>
        void SetEnable(int id, bool enable);
    }
}
