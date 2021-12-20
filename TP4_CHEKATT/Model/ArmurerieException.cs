using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4_CHEKATT
{
    internal class ArmurerieException : Exception
    {
        public ArmurerieException() : base("Cette arme ne provient pas de l'armurerie ! ") { }
    }
}
