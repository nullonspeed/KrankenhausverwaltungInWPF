using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrankenhausverwaltungInWPF
{
    internal class Patient
    {
        public int SVN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ArztID { get; set; }
        public List<string> Krankheiten { get; set; } = new List<string>();

        public override string? ToString()
        {
            string krankheiten ="";
            int temp = 0;
            foreach(var item in Krankheiten)
            {
                temp++;
                if(temp == Krankheiten.Count)
                {
                    krankheiten += item;
                }
                else
                {
                    krankheiten += item+", ";
                }

            }
            return $"{SVN} {FirstName} {LastName} [{krankheiten}]";
        }
        public static bool TryParse(string s, out Patient p)
        {
            try
            {


                string[] parts = s.Split(';');
                p = new Patient();

                if (parts.Length >= 5)
                {
                    p.SVN = int.Parse(parts[0]);
                    p.FirstName = parts[2];
                    p.LastName = parts[1];
                    p.ArztID = int.Parse(parts[3]);
                   

                       

                        

                       

                        if (parts.Length >= 6)
                        {
                            int temporaryCounter = parts.Length - 5;
                            int temporaryCounterfromZerso = 0;
                            while (temporaryCounterfromZerso != temporaryCounter)
                            {
                                
                            if(parts[5 + temporaryCounterfromZerso]=="" || parts[5 + temporaryCounterfromZerso] == null || parts[5 + temporaryCounterfromZerso] ==" ")
                            {
                                temporaryCounterfromZerso++;
                            }
                            else
                            {
                                p.Krankheiten.Add(parts[5 + temporaryCounterfromZerso]);
                                temporaryCounterfromZerso++;

                            }
                               



                            }


                      



                        return true;

                    }
                    else
                    {
                        return true;
                    }

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
