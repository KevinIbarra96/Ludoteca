using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludoteca.Resources
{
    internal class Logs
    {

        private static Logs _instance;
        private string _path = "logs.txt";

        public static Logs Instance
        {
            get => _instance;
        }

        public void Save(string message)
        {
            File.AppendAllText(_path, message);
        }
        
        private Logs() { }
    }
}
