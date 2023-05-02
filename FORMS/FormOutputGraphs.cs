using System;
using System.Drawing;
using System.Windows.Forms;

namespace CoursWork_Ivanin_MainFile_CSharp
{
    public partial class FormOutputGraphs : Form
    {
        public Graphics g;
        public InputGraph formIn { get; set; }
        public FormOutputGraphs()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.FormClosing += showClosingMessage;
            g = this.pictureBox1.CreateGraphics();
            
        }

        public void newList()
        {
            this.comboBox1.Items.Clear();
            if (DataBank.listOfCycles.Count != 0)
            {
                for (int i = 0; i < DataBank.listOfCycles.Count; i++)
                {
                    this.comboBox1.Items.Add($"{DataBank.listOfCycles[i].showStringMap()}");
                }
            }
            else
            {
                this.comboBox1.Items.Add("ДЛЯ ДАННОГО ГРАФА НЕТ ЦИКЛОВ!");
            }
            this.comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DataBank.listOfCycles.Count != 0)
            {
                this.g.Clear(Color.White);
                int i = this.comboBox1.SelectedIndex;
                DataBank.listOfCycles[i].show(this.g);
            }
            else
            {
                this.g.Clear(Color.Aquamarine);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formIn.StartPosition = FormStartPosition.Manual;
            formIn.formOut = this;
            formIn.Location = Location;
            formIn.Show();
            this.Hide();
        }

        private void AboutCreatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdditionalInformation.AboutCreator();
        }
        public static void showClosingMessage(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdditionalInformation.AboutProgram();
        }

        private void AboutMathМетодеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdditionalInformation.AboutMath();
        }
    }
}
