using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
            Cliente cQry = em.Clientes.Where(q => q.RutCliente == (string)pk).First<Cliente>();
            if (cQry == null)
            {
                throw new ArgumentException("Cliente no encontrado");
            }
            else
            {
                return cQry;
            }

        }

        public override bool isEntity(object pk)
        {
            if(em.Clientes.Where(q => q.RutCliente == (string)pk).Count() == 0)
            
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override void updEntity(object pk, Cliente clUpdt)
        {
            Cliente cQry = em.Clientes.Where(q => q.RutCliente == (string)pk).First<Cliente>();
            if (cQry == null)
            {
                throw new ArgumentException("Cliente no encontrado");
            }
            else
            {
                cQry.NombreContacto = clUpdt.NombreContacto;
                cQry.RazonSocial = clUpdt.RazonSocial;
                cQry.Direccion = clUpdt.Direccion;
                cQry.Telefono= clUpdt.Telefono;
                cQry.MailContacto = clUpdt.MailContacto;
                cQry.TipoEmpresa = clUpdt.TipoEmpresa;
                cQry.ActividadEmpresa = clUpdt.ActividadEmpresa;
                
                em.SaveChanges();

            }
        }


    }
}
