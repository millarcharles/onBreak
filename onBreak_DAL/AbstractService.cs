using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onBreak_DAL
{
    public abstract class AbstractService <T>
    {
        protected OnBreakEntities em = new OnBreakEntities();

        public abstract void addEntity(T entity);
        public abstract void updEntity(T entity, object campo);
        public abstract void delEntity(Object pk);
        public abstract List<T> getEntiies();
        public abstract T getEntity(Object pk);


    }
}
