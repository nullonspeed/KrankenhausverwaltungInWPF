using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrankenhausverwaltungInWPF
{
    internal class Abteilung
    {
        public int ID { get; set; }
        public string Bezeichnung { get; set; }

        public List<Arzt> aerzte { get; set; } = new List<Arzt>();

        public override string? ToString()
        {
            return Bezeichnung;
        }
    }
}
