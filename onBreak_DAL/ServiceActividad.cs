using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onBreak_DAL
{
    public class ServiceActividad : AbstractService<ActividadEmpresa>
    {
        public override void addEntity(ActividadEmpresa entity)
        {
            throw new NotImplementedException();
        }

        public override void delEntity(object pk)
        {
            throw new NotImplementedException();
        }

        public override List<ActividadEmpresa> getEntities()
        {
            return em.ActividadEmpresas.ToList<ActividadEmpresa>(); ;
        }

        public override ActividadEmpresa getEntity(object pk)
        {
            throw new NotImplementedException();
        }

        public override bool isEntity(object pk)
        {
            throw new NotImplementedException();
        }

        public override void updEntity(object pk, ActividadEmpresa entity ) => throw new NotImplementedException();
    }
}
