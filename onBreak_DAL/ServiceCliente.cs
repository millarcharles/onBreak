using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onBreak_DAL
{
    public class ServiceCliente : AbstractService<Cliente>
    {
        public override void addEntity(Cliente entity)
        {
            em.Clientes.Add(entity);
            em.SaveChanges();
        }

        public override void delEntity(Object pk)
        {
            Cliente cBus = em.Clientes.Where(q => q.RutCliente == (string)pk).First<Cliente>();
            if (cBus == null)
            {
                throw new ArgumentException("Cliente no encontrado");
            }
            else
            {
                em.Clientes.Remove(cBus);
                em.SaveChanges();
            }
        }

        public override List<Cliente> getEntities()
        {
            return em.Clientes.ToList<Cliente>();
        }

        public override Cliente getEntity(object pk)
        {
            Cliente cBus = em.Clientes.Where(q => q.RutCliente == (string)pk).First<Cliente>();
            if (cBus == null)
            {
                throw new ArgumentException("Cliente no encontrado");
            }
            else {
                return cBus;
            }

            }

        public override void updEntity(Cliente entity, object campo)
        {
            throw new NotImplementedException();
        }
    }

  
}
