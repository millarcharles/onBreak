using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onBreak_DAL
{
    public class ServiceTipo : AbstractService<TipoEmpresa> 
    { 
        public override void addEntity(TipoEmpresa entity)
        {
            throw new NotImplementedException();
        }

        public override void delEntity(object pk)
        {
            throw new NotImplementedException();
        }

        public override List<TipoEmpresa> getEntities()
        {
           return em.TipoEmpresas.ToList<TipoEmpresa>();
        }

        public override TipoEmpresa getEntity(object pk)
        {
            throw new NotImplementedException();
        }

        public override void updEntity(object pk, TipoEmpresa entity)
        {
            throw new NotImplementedException();
        }

    }
}
