using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulator_s_Delegatima
{
    public class Kalkulator
    {
        public delegate void NijeBrojDelegat(object sender, EventArgs e);
        public event NijeBrojDelegat NijeBroj;
        
        public string OperandA { get; set; }
        public string OperandB { get; set; }


        public void Izracun( Form1.RacOperacija ro)
        {
            double Prvi;
            double Drugi;

            if (double.TryParse(OperandA, out Prvi) && double.TryParse(OperandB, out Drugi))
            {
                ro(Prvi, Drugi);
            }
                           
            else
            {
                if (NijeBroj != null)
                {
                    NijeBroj(this, new EventArgs());
                }
            }
            

            

        }
        

   
    }

    
}
