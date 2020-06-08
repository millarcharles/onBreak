using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onBreak.Resources.Errors
{
   public class ValidationResponse
    {

        public bool _successful { get; set; }
        public object _element { get; set; }

        public ValidationResponse()
        {
        }

        public ValidationResponse(bool successful, object element)
        {
            _successful = successful;
            this._element = element;
        }
    }



}
