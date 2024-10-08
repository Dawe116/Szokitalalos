using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szokitalalos.Controllers
{
    internal class SzoController
    {
        public List<string> SzoListFromFile()
        {
            List<string> list;
            try
            {
                string[] sorok = File.ReadAllLines("szavak.txt");
                list = new List<string>(sorok);
            }
            catch (Exception e) {
                list = new List<string>();
                list.Add(e.Message);
            }

            return list;
        }
    }
}
