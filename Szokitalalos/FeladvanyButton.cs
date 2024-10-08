using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;


using Szokitalalos.Interfaces;

namespace Szokitalalos
{
    internal class FeladvanyButton : Button, IViselkedes
    {
        public string Tartalom { get; set; }

        public void Felfed()
        {
            Content = Tartalom;
        }
    }
}
