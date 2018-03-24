using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gerenciador_Aniversario.Repository
{
    public abstract class AbstractRepository<TEntity, Tkey> where TEntity : class
    {
        string StringConnection;

        public abstract List<TEntity> GetAll();
        public abstract TEntity GetById(Tkey id);
        public abstract void Save(TEntity entity);
        public abstract void Update(TEntity entity);
        public abstract void Delete(TEntity entity);
        public abstract void DeleteById(Tkey id);
    }
}