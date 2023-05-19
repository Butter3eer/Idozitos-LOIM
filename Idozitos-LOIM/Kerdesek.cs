using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idozitos_LOIM
{
    internal class Kerdesek
    {
        private int id;
        private string kerdes;
        private string valaszA;
        private string valaszB;
        private string valaszC;
        private string valaszD;
        private string helyesValasz;
        private string kateg;

        public Kerdesek(int id, string kerdes, string valaszA, string valaszB, string valaszC, string valaszD, string helyesValasz, string kateg)
        {
            this.id = id;
            this.kerdes = kerdes;
            this.valaszA = valaszA;
            this.valaszB = valaszB;
            this.valaszC = valaszC;
            this.valaszD = valaszD;
            this.helyesValasz = helyesValasz;
            this.kateg = kateg;
        }

        public int Id { get => id; set => id = value; }
        public string Kerdes { get => kerdes; set => kerdes = value; }
        public string ValaszA { get => valaszA; set => valaszA = value; }
        public string ValaszB { get => valaszB; set => valaszB = value; }
        public string ValaszC { get => valaszC; set => valaszC = value; }
        public string ValaszD { get => valaszD; set => valaszD = value; }
        public string HelyesValasz { get => helyesValasz; set => helyesValasz = value; }
        public string Kateg { get => kateg; set => kateg = value; }
    }
}
