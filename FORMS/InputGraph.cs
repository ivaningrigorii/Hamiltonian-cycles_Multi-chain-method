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
    public partial class InputGraph : Form
    {
        public FormOutputGraphs formOut { get; set; }
        public bool newGraf;
        private Graphics g;
        public IMathElement graph { get; set; }
        public InputGraph()
        {
            InitializeComponent();
            this.FormClosing += showClosingMessage;
            newGraf = true;
            g = pictureBox1.CreateGraphics();
        }

        //заполнение табл на форме
        private void AddCowRow(int n)
        {
            DataBank.boolNewList = false;
            newGraf = false;
            DataGridViewColumn column;
            for (int i = 0; i < n; i++)
            {
                column = new DataGridViewTextBoxColumn();

                column.DataPropertyName = Convert.ToString(i+1);
                column.Name = Convert.ToString(i+1);
                column.Width = 19;
                dataGridView1.Columns.Add(column);

                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].HeaderCell.Value = Convert.ToString(i + 1);
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dataGridView1[i, j].Value = Convert.ToString(0);
                }
            }
        }
        //очистка табл на форме
        private void ClearDataView()
        {
            int k = 0;
            k = dataGridView1.ColumnCount;
            if (k != 0)
            {
                for (int i = 0; i < k; i++)
                    dataGridView1.Columns.RemoveAt(0);
            }
            dataGridView1.Columns.Clear();

        }
        //сравнение матриц
        private bool ComparisonMatrix(int[,] matrix)
        {
            bool res = true;
            for (int i = 0; i < graph.LengthGrathRowsAndCows; i++)
            {
                for (int j = 0; j < graph.LengthGrathRowsAndCows; j++)
                {
                    if (matrix[i, j] != graph.adjacencyMatrix[i, j])
                        res = false;
                }
            }
            return res;
        }
        //значения для рисования или создания
        private void ValuesForWork(out int[,] matrix, out int length)
        {
            if (dataGridView1.ColumnCount == 0)
            {
                throw new Exception("Таблица матрицы не создана!");
            }

            length = dataGridView1.ColumnCount;
            matrix = new int[length, length];

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (dataGridView1[j, i].Value == null)
                    {
                        throw new Exception("Не все значения введены!");
                    }

                    int a = Convert.ToInt32(dataGridView1[j, i].Value.ToString());
                    if (a != 0 && a != 1)
                    {
                        throw new Exception("Значения могут быть только 0 или 1!");
                    }
                    matrix[i, j] = a;
                }
            }

        }
        //рисование
        private void drawingGraph()
        {
            try
            {
                int lenght; int[,] matrix;
                ValuesForWork(out matrix, out lenght);
                IMathElement timeGraph = new Orgraph() { adjacencyMatrix = matrix, LengthGrathRowsAndCows = lenght };
                timeGraph.show(g);

                g.Clear(Color.White);
                timeGraph.show(g);
            }
            catch (Exception exp)
            {
                MessageBox.Show($"{exp.Message}!", "Ошибка ввода!");
            }
        }

        //создание(обновление) графа
        private void makeGraph()
        {
            try
            {
                newGraf = false;
                int length; int[,] matrix;
                ValuesForWork(out matrix, out length);

                if (graph == null || length != graph.LengthGrathRowsAndCows || (!ComparisonMatrix(matrix)))
                {
                    graph = new Orgraph { LengthGrathRowsAndCows = length, adjacencyMatrix = (int[,])matrix.Clone() };
                    newGraf = true;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show($"{exp.Message}!", "Ошибка ввода!");
            }
            
        }
        //переход на след форму
        private void nextForm(bool button)
        {
            if (formOut == null)
            {
                formOut = new FormOutputGraphs();
            }

            formOut.StartPosition = FormStartPosition.Manual;
            formOut.Location = this.Location;
            formOut.Show();
            formOut.formIn = this;

            if (!button)
            {
                if (DataBank.boolNewList == true)
                {
                    formOut.newList();
                }
            }
            this.Hide();


        }
        //->
        private void buttonArrowRightClick(object sender, EventArgs e)
        {
            if (DataBank.listOfCycles!=null)
            {
                MessageBox.Show("Чтобы изменить значения необходимо нажать" +
                    "\t\nна кнопку расчёта циклов!", "Старые значения циклов");
                nextForm(true);
            }
            else
                MessageBox.Show("Значений быть не может!\t\nПрограмма не расчитала циклы!", "Ограничение!");
        }
        //(-)
        private void buttonShowGrindClick(object sender, EventArgs e)
        {
            drawingGraph();
        }
        //NEW
        private void button2MakeTabelForGrindView(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Прошлые данные о прошлом графе будут удалены!" +
                "\t\nВы желаете продолжить?", "Предупреждение", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == result)
            {
                this.textBox1.Text = "";
                ClearDataView();
                g.Clear(Color.White);
                AddCowRow(Convert.ToInt32(numericUpDown1.Value));
            }
            
        }
        
        //LIST
        private void buttonMakeList(object sender, EventArgs e)
        {
            try
            {
                makeGraph();
                if (newGraf == true)
                {
                    this.UseWaitCursor = true;
                    textBox1.Text = "Идёт обработка данных!";
                    MultiСhainMethod method = new MultiСhainMethod((int[,])graph.adjacencyMatrix.Clone(), graph.LengthGrathRowsAndCows);
                    DataBank.listOfCycles = method.CreateCyclesFromMainGraph();
                    DataBank.boolNewList = true;
                    this.UseWaitCursor = false;
                    textBox1.Text = "Готово!";
                    nextForm(false);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show($"{exp.Message}!", "Ошибка ввода!");
            }
        }






        private void CreatorToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void AboutMathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdditionalInformation.AboutMath();
        }
    }
}
















//                                                       демонстрация программы