using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulator_s_Delegatima
{
    public partial class Form1 : Form
    {

        public delegate double RacOperacija(double prvi, double drugi);
        
        public Form1()
        {
            InitializeComponent();
        }

        public double Zbroji(double prvi, double drugi)
        {
            lblRez.Text = (prvi + drugi).ToString();
            return prvi + drugi;
        }
        public double Oduzmi(double prvi, double drugi)
        {
            lblRez.Text = (prvi - drugi).ToString();
            return prvi - drugi;
        }

        public double Pomnozi(double prvi, double drugi)
        {
            lblRez.Text = (prvi * drugi).ToString();
            return prvi * drugi;
        }
        public double Podijeli(double prvi, double drugi)
        {
            if (drugi==0)
            {
                lblRez.Text = "Nije dozvoljeno dijeljenje s nulom";
                return 0;
            }
            else
            {
                lblRez.Text = (prvi / drugi).ToString();
                return prvi / drugi;
            }
           
        }
        public void btnIzracunaj_Click(object sender, EventArgs e)
        {
            RacOperacija ro;
            Kalkulator calc = new Kalkulator();

            calc.NijeBroj += new Kalkulator.NijeBrojDelegat(onNijeBroj);

            calc.OperandA = txt1.Text;
            calc.OperandB = txt2.Text;

            //ajkula.Vrsta = (Vrsta)Enum.Parse(typeof(Vrsta), cbPopis.SelectedItem.ToString());
            switch (cbOperacija.SelectedItem)
            {
                case "+":
                    calc.Izracun(Zbroji);
                    break;
                case "-":
                    calc.Izracun(Oduzmi);
                    break;
                case "*":
                    calc.Izracun(Pomnozi);
                    break;
                case "/":

                    calc.Izracun(Podijeli);
                    break;
                default:
                    MessageBox.Show("Nije izabrana operacija", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void onNijeBroj(object sender, EventArgs e)
        {
            lblRez.Text = "Greška";
            MessageBox.Show("Svi operandi nisu brojevi", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt1.Text = "";
            txt2.Text = "";
            lblRez.Text = "";
            cbOperacija.SelectedIndex= -1;
        }
    }
}
