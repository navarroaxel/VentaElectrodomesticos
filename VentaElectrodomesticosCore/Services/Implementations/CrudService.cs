using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VentaElectrodomesticos.Core.Common;
using VentaElectrodomesticos.Core.Repositories;
using VentaElectrodomesticos.Core.Model.Entities;

namespace VentaElectrodomesticos.Core.Services.Implementations
{
    internal abstract class CrudService<TEntity, TRepository> : ICrudService<TEntity>
        where TEntity : ICrudEntity<TEntity>
        where TRepository : ICrudRepository<TEntity>
    {
        TEntity[] ICrudService<TEntity>.List()
        {
            return Repository.LocateIt<TRepository>().List();
        }

        TEntity[] ICrudService<TEntity>.List(TEntity entity)
        {
            return Repository.LocateIt<TRepository>().List(entity);
        }

        void ICrudService<TEntity>.Add(TEntity entity)
        {
            entity.Save();
        }

        void ICrudService<TEntity>.Update(TEntity entity)
        {
            var originalEntity = Repository.LocateIt<TRepository>().Get(entity.Id);
            originalEntity.Update(entity);
        }

        void ICrudService<TEntity>.Disable(int id)
        {
            var entity = Repository.LocateIt<TRepository>().Get(id);
            entity.Disable();
        }

        void ICrudService<TEntity>.Enable(int id)
        {
            var entity = Repository.LocateIt<TRepository>().Get(id);
            entity.Enable();
        }
    }
}
