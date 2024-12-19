using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    internal class EN_Response<T>
    {
        
        private int _rCode;
        private string _rMessage;
        private string _rErrorCode;
        private List<T> _rBody;

        public int Rcode 
        { 
            get; 
            set;
        }
        public string Rmessage { get; set; }
        public string RerrorCode { get; set; }
        public List<T> Rbody { get; set; }
    }
}
