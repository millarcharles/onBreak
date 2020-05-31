using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace onBreak.ModCliente
{
    public class ClienteViewModel
    {

        private readonly ICollectionView _clienteView;

        public ICollectionView Cliente {

            get { return _clienteView; }
        }


    }
}
