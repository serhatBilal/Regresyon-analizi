namespace Regresyon
{
    public partial class Form1 : Form
    {
        int cmbValue ;
        int counter = 0;
        double a ;   
        double b ;
        public Form1()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox4.Enabled = true;
            button1.Enabled=false;
            comboBox1.Enabled=false;

            cmbValue =  Convert.ToInt32(comboBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(counter < cmbValue)
            {
                counter++;
                listBox1.Items.Add(textBox1.Text);
                label2.Text = (counter+1).ToString() + ".Dönem Satışı";
            }

            if(counter == cmbValue)
            {
                groupBox2.Enabled=true;
                groupBox4.Enabled=false;
                label2.Text = (counter).ToString() + ".Dönem Satışı";
            }

            textBox1.Clear();
            textBox1.Focus();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            double[] x = new double[cmbValue];
            double[] y = new double[cmbValue];
            double[] tahminler = new double[cmbValue];

            double toplamSapma = 0;
            double xToplam =0;
            double yToplam =0;
            double xyToplam =0;
            double xKareToplam =0;

            for(int i = 0; i < cmbValue; i++)
            {
                y[i] = Convert.ToDouble(listBox1.Items[i]);
                x[i] = i+1;
            }

            for(int i = 0;i< cmbValue; i++)
            {
                xToplam += x[i];
                yToplam += y[i];
                xyToplam += x[i] * y[i];
                xKareToplam += x[i] * x[i];
            }

            b = (cmbValue * xyToplam - xToplam * yToplam) / (cmbValue * xKareToplam - xToplam * xToplam);
            a = (yToplam - b * xToplam) / cmbValue;

            label9.Text = a.ToString();
            label6.Text = b.ToString();
            label5.Text = "y = " + a.ToString() + " + " + b.ToString() + "x ";

            for(int i = 0; i < cmbValue; i++)
            {
                double tahmin = a + b * (i + 1);
                tahminler[i] = tahmin;
            }

            for (int i = 0; i < cmbValue; i++)
            {
               toplamSapma += Math.Abs(y[i] - tahminler[i]);
            }

            label10.Text = toplamSapma.ToString();

            double sonrakiDonemtahmini = a + b * (cmbValue + 1);
            label11.Text = sonrakiDonemtahmini.ToString();

            groupBox3.Enabled = true;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(textBox2.Text);
            double tahmin = a + b * x;
            label15.Text = tahmin.ToString();
        }
    }
}