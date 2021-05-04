using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab9
{
    public partial class Form1 : Form
    {
        int S = 5;
        public Form1()
        {
            InitializeComponent();
        }

        public double[] input_check()
        {
            double[] probs = new double[S];
            try
            {
                probs[0] = Convert.ToDouble(textBox1.Text);
                probs[1] = Convert.ToDouble(textBox2.Text);
                probs[2] = Convert.ToDouble(textBox3.Text);
                probs[3] = Convert.ToDouble(textBox4.Text);

                double sum = probs.Sum();
                probs[4] = 1 - sum;
                textBox5.Text = probs[4].ToString("N3");
            }
            catch
            {
                probs[0] = 0.2;
                probs[1] = 0.2;
                probs[2] = 0.2;
                probs[3] = 0.2;
                probs[4] = 0.2;
                textBox1.Text = probs[0].ToString("N3");
                textBox2.Text = probs[1].ToString("N3");
                textBox3.Text = probs[2].ToString("N3");
                textBox4.Text = probs[3].ToString("N3");
                textBox5.Text = probs[4].ToString("N3");
                label6.Text = "can't convert to double";

            }
            if (probs[4] < 0) label6.Text = "invalid probabilities";
            
            return probs;
        }

        public double[] statistick_count(double[] probs, int number_experiment)
        {
            double[] Statistic = new double[S];
            Random rnd = new Random();
            for (int i = 0; i < number_experiment; i++)
            {
                double A = rnd.NextDouble();
                int event_id = -1;
                do
                {
                    event_id++;
                    A -= probs[event_id];
                } while (A > 0);
                Statistic[event_id]++;
            }
            return Statistic;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6.Text = "ErrorField";
            double[] probs = input_check();
            int max;
            try
            {
                max = Convert.ToInt32(textBox6.Text);
            }
            catch
            {
                max = 5;
                textBox6.Text = "5";
            }

            double[] stat = statistick_count(probs, max);
            for (int i = 0; i < S; i++) stat[i] /= max;


            label7.Text = Convert.ToString(stat[0]);
            label8.Text = Convert.ToString(stat[1]);
            label9.Text = Convert.ToString(stat[2]);
            label10.Text = Convert.ToString(stat[3]);
            label11.Text = Convert.ToString(stat[4]);
        }
    }
}
