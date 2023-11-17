using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrankenhausverwaltungInWPF
{
    internal class Arzt
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public int AbteilID { get; set; }
        public List<Patient> Patienten { get; set; } = new List<Patient>();

        public override string? ToString()
        {
            return $"{Title} {Firstname} {Lastname}";
        }

        public static bool TryParse(string s, out Arzt p)
        {
            try
            {


                string[] parts = s.Split(';');
                p = new Arzt();

                if (parts.Length >= 5)
                {
                    p.ID = int.Parse(parts[0]);
                    p.Title = parts[1];
                    p.Firstname = parts[2];
                    p.Lastname = parts[3];
                    p.AbteilID = int.Parse(parts[4]);





                    return true;
                }
                else
                {

                    return false;
                }
            }
            catch (Exception e)
            {
                p = null;
                return false;
            }

        }
    }
}
