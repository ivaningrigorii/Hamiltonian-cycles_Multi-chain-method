using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoursWork_Ivanin_MainFile_CSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += showClosingMessage;

            //0, SystemColors.Control
        }

        private void buttonStartWorkProgram_Click(object sender, EventArgs e)
        {
            InputGraph form2 = new InputGraph();
            form2.StartPosition = FormStartPosition.Manual;
            form2.Location = this.Location;
            form2.Show();
            this.Hide();
        }





        private void AboutCreatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdditionalInformation.AboutCreator();
        }

        private void AboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdditionalInformation.AboutProgram();
        }

        private void AboutMathMethodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdditionalInformation.AboutMath();
        }

        public static void showClosingMessage(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
