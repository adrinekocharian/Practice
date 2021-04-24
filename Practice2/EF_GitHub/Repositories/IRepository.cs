using System;
using System.Collections.Generic;
using System.Text;

namespace EF_GitHub.Repository
{
    public interface IRepository<TEntity, TIdentity>
    {
        IList<TEntity> ReadAll();
        TEntity ReadById(TIdentity id);
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
