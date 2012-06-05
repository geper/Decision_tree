//Decision Trees

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Accord.MachineLearning;
using Accord.MachineLearning.DecisionTrees;
using Accord.MachineLearning.DecisionTrees.Learning;
using Accord.Math;
using Accord.Statistics.Analysis;
using Accord.Statistics.Formats;
using ZedGraph;
using System.Text;
using DecisionTrees;





namespace DecisionTrees
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// отображенийе дерева
        /// </summary>
        Tree_View asd;

        /// <summary>
        /// параметры построения дерева
        /// </summary>
        Property_Tree Tree_property;

       /// <summary>
       /// Дерево решений
       /// </summary>
        private DecisionTree tree;

        string[] sourceColumns;

        /// <summary>
        /// Инициализация 
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            dgvLearningSource.AutoGenerateColumns = true;
            dgvPerformance.AutoGenerateColumns = false;
            Tree_property = new Property_Tree();

            asd = new Tree_View();
            openFileDialog.InitialDirectory = Path.Combine(Application.StartupPath, "Resources");

            toolTip1.SetToolTip(groupBox1, "+/- раскрыть/скрыть узел \n*-раскрыть полностью ветвь");
        }

        internal Drawing Drawing
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
        /// <summary>
        /// Импорт .xls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuFileOpen_Click(object sender, EventArgs e)
        {
            #region загрузка пользователем XLS
            //if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            //{
            //    string filename = openFileDialog.FileName;
            //    string extension = Path.GetExtension(filename);
            //    if (extension == ".xls" || extension == ".xlsx")
            //    {
            //        ExcelReader db = new ExcelReader(filename, true, false);
            //        TableSelectDialog t = new TableSelectDialog(db.GetWorksheetList());

            //        if (t.ShowDialog(this) == DialogResult.OK)
            //        {
            //            DataTable tableSource = db.GetWorksheet(t.Selection);

            //            double[,] sourceMatrix = tableSource.ToMatrix(out sourceColumns);

            //            // Detect the kind of problem loaded.
            //            if (sourceMatrix.GetLength(1) == 2)
            //            {
            //                MessageBox.Show("Недостаточно данных");
            //            }
            //            else
            //            {
            //                this.dgvLearningSource.DataSource = tableSource;
            //                this.dgvTestingSource.DataSource = tableSource.Copy();


            //               // CreateScatterplot(graphInput, sourceMatrix);
            //            }
            //        }
            //    }
            //}
            #endregion
            #region быстрая загрузка
            string filename = ".//Resources//3.xls";

            string extension = Path.GetExtension(filename);

            ExcelReader db = new ExcelReader(filename, true, false);
            //ЛИСТЫ
            string[] sd = db.GetWorksheetList();

            TableSelectDialog t = new TableSelectDialog(sd);

            if (t.ShowDialog(this) == DialogResult.OK)
            {
                //заставка импорт
                System.Windows.SplashScreen splashScreen = new System.Windows.SplashScreen("2.png");
                splashScreen.Show(true);

                DataTable tableSource = db.GetWorksheet(t.Selection);
                double[,] sourceMatrix = tableSource.ToMatrix(out sourceColumns);
                if (sourceMatrix.GetLength(1) == 2)
                {
                    MessageBox.Show("Недостаточно данных");
                }
                else
                {
                    this.dgvLearningSource.DataSource = tableSource;
                    this.dgvTestingSource.DataSource = tableSource.Copy();
                    // CreateScatterplot(graphInput, sourceMatrix);
                }
            }
            # endregion
        }
        /// <summary>
        /// Создание дерева 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, EventArgs e)
        {

           
            try
            {
                if (dgvLearningSource.DataSource == null)
                {
                    MessageBox.Show("Загрузите данные");
                    return;
                }
                if (Tree_property.Property_View == true)
                {
                    Tree_property.ShowDialog();
                }
                // Завершаем операцию с DataGridView
                dgvLearningSource.EndEdit();



                #region Алгоритм С4.5
                ///
                ///Алгоритм С4.5
                ///
                if (Tree_property.Alg == "C4.5")
                {
                    // // создаем матрицу из  data table
                    double[,] sourceMatrix = (dgvLearningSource.DataSource as DataTable).ToMatrix(out sourceColumns);

                    C45Learning c45;

                    // получаем входные значения
                    double[][] inputs = sourceMatrix.Submatrix(null, 0, Tree_property.Coun_In - 1).ToArray();

                    // получаем выходные значения
                    int[] outputs = sourceMatrix.GetColumn(Tree_property.Coun_Out - 1).ToInt32();

                    DecisionVariable[] attributes = new DecisionVariable[Tree_property.Coun_In];

                    for (int j = 0; j < Tree_property.Coun_In; j++)
                    {
                        attributes[j] = new DecisionVariable(dgvLearningSource.Columns[j].Name, DecisionAttributeKind.Continuous);
                    }

                    // создаем дерево решений
                    tree = new DecisionTree(attributes, 60);

                    c45 = new C45Learning(tree);
                    double error = c45.Run(inputs, outputs);
                }
                #endregion

                #region Алгоритм ID3
                ///
                ///Алгоритм ID3
                ///
                if (Tree_property.Alg == "ID3")
                {
                    // создаем матрицу из дататыйбл
                    int[][] arr = (dgvLearningSource.DataSource as DataTable).ToIntArray(sourceColumns);
                    int[,] sourceMatrix = arr.ToMatrix();



                    //// получаем входные значения

                    int[][] inputs = sourceMatrix.Submatrix(null, 0, Tree_property.Coun_In - 1).ToArray();

                    //// получаем выходные значения
                    int[] outputs = sourceMatrix.GetColumn(Tree_property.Coun_In - 1);


                    DecisionVariable[] attributes = new DecisionVariable[Tree_property.Coun_In];

                    for (int j = 0; j < Tree_property.Coun_In; j++)
                    {
                        attributes[j] = new DecisionVariable(j.ToString(), DecisionAttributeKind.Continuous);
                    }

                    // создаем дерево решений
                    tree = new DecisionTree(attributes, 60);

                    ID3Learning id3learning = new ID3Learning(tree);

                    double error = id3learning.Run(inputs, outputs);

                }
                #endregion

                asd.Dispose();
                asd.Close();

                Drawing dr = new Drawing();

                dr.recursion(tree.Root, tree.Root.Branches, 0);
                dr.Save_();

                asd = new Tree_View();
                asd.userControl11.Load_f(Application.StartupPath);

                System.Linq.Expressions.Expression df = tree.ToExpression();

               // выбираем tabe page для просмотра дерева
                tabControl.SelectTab(tabOverview); 

                // отображаем построенной дереыыо решений
                decisionTreeView1.TreeSource = tree;
             //   if (System.IO.Directory.Exists(@".\Resources\recursion2.png"))
             //   {

                    try
                    {
                        File.Copy(@".\Resources\recursion.png", @".\Resources\recursion2.png", true);
                        using (Stream s = File.OpenRead(@".\Resources\recursion2.png"))
                        {
                            pictureBox1.Image = Image.FromStream(s);
                        }
                    }
                    catch (Exception weror)
                    {
                        string a = weror.Message;
                    }

              //  }
               //using (Stream s = File.OpenRead(@".\Resources\recursion2.png"))
               //{
               //    pictureBox1.Image = Image.FromStream(s);
               //}
               

            }
            catch (Exception t)
            {
                MessageBox.Show(t.Message);
            }
        }
       private void btnTestingRun_Click(object sender, EventArgs e)
        {
            if (tree == null || dgvTestingSource.DataSource == null)
            {
                MessageBox.Show("Постройте дерево решений в первую очередь.");
                return;
            }

            //создаем матрицу из  data table
            double[,] sourceMatrix = (dgvLearningSource.DataSource as DataTable).ToMatrix();

           //получаем входные значения
            double[][] inputs = sourceMatrix.Submatrix(null, 0, Tree_property.Coun_In - 1).ToArray();

            //получаем вsходные значения
            int[] expected = new int[sourceMatrix.GetLength(0)];
            for (int i = 0; i < expected.Length; i++)
                expected[i] = (int)sourceMatrix[i, Tree_property.Coun_Out - 1];

            // вычисление
            int[] output = new int[inputs.Length];
            for (int i = 0; i < inputs.Length; i++)
                output[i] = tree.Compute(inputs[i]);


            // Использование матрицы неточностей вычислить  статистические данные.
            ConfusionMatrix confusionMatrix = new ConfusionMatrix(output, expected, 1, 0);
            dgvPerformance.DataSource = new List<ConfusionMatrix> { confusionMatrix };

            foreach (DataGridViewColumn col in dgvPerformance.Columns)
                col.Visible = true;
            Column1.Visible = Column2.Visible = false;

           CreateResultScatterplot(zedGraphControl1, inputs, expected.ToDouble(), output.ToDouble());
        }
        public void CreateScatterplot(ZedGraphControl zgc, double[,] graph)
        {
            GraphPane myPane = zgc.GraphPane;
            myPane.CurveList.Clear();

            // устанавливаем titles
            myPane.Title.IsVisible = false;
            myPane.XAxis.Title.Text = sourceColumns[0];
            myPane.YAxis.Title.Text = sourceColumns[1];


            PointPairList list1 = new PointPairList(); // Z = 0
            PointPairList list2 = new PointPairList(); // Z = 1
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                if (graph[i, 2] == 0)
                    list1.Add(graph[i, 0], graph[i, 1]);
                if (graph[i, 2] == 1)
                    list2.Add(graph[i, 0], graph[i, 1]);
            }

            // Add the curve
            LineItem myCurve = myPane.AddCurve("G1", list1, Color.Blue, SymbolType.Square);
            myCurve.Line.IsVisible = false;
            myCurve.Symbol.Border.IsVisible = false;
            myCurve.Symbol.Fill = new Fill(Color.Blue);

            myCurve = myPane.AddCurve("G2", list2, Color.Green, SymbolType.Square);
            myCurve.Line.IsVisible = false;
            myCurve.Symbol.Border.IsVisible = false;
            myCurve.Symbol.Fill = new Fill(Color.Green);

            //myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45.0f);
            //myPane.Fill = new Fill(Color.White, Color.SlateGray, 45.0f);
            myPane.Fill = new Fill(Color.WhiteSmoke);

            zgc.AxisChange();
            zgc.Invalidate();
        }
        public void CreateResultScatterplot(ZedGraphControl zgc, double[][] inputs, double[] expected, double[] output)
        {
            GraphPane myPane = zgc.GraphPane;
            myPane.CurveList.Clear();

            myPane.Title.IsVisible = false;
            myPane.XAxis.Title.Text = sourceColumns[0];
            myPane.YAxis.Title.Text = sourceColumns[1];

            PointPairList list1 = new PointPairList(); // Z = 0, OK
            PointPairList list2 = new PointPairList(); // Z = 1, OK
            PointPairList list3 = new PointPairList(); // Z = 0, Error
            PointPairList list4 = new PointPairList(); // Z = 1, Error
            for (int i = 0; i < output.Length; i++)
            {
                if (output[i] == 0)
                {
                    if (expected[i] == 0)
                        list1.Add(inputs[i][0], inputs[i][1]);
                    if (expected[i] == 1)
                        list3.Add(inputs[i][0], inputs[i][1]);
                }
                else
                {
                    if (expected[i] == 0)
                        list4.Add(inputs[i][0], inputs[i][1]);
                    if (expected[i] == 1)
                        list2.Add(inputs[i][0], inputs[i][1]);
                }
            }

            LineItem
            myCurve = myPane.AddCurve("G1 Hits", list1, Color.Blue, SymbolType.Diamond);
            myCurve.Line.IsVisible = false;
            myCurve.Symbol.Border.IsVisible = false;
            myCurve.Symbol.Fill = new Fill(Color.Blue);

            myCurve = myPane.AddCurve("G2 Hits", list2, Color.Green, SymbolType.Diamond);
            myCurve.Line.IsVisible = false;
            myCurve.Symbol.Border.IsVisible = false;
            myCurve.Symbol.Fill = new Fill(Color.Green);

            myCurve = myPane.AddCurve("G1 Miss", list3, Color.Blue, SymbolType.Plus);
            myCurve.Line.IsVisible = false;
            myCurve.Symbol.Border.IsVisible = true;
            myCurve.Symbol.Fill = new Fill(Color.Blue);

            myCurve = myPane.AddCurve("G2 Miss", list4, Color.Green, SymbolType.Plus);
            myCurve.Line.IsVisible = false;
            myCurve.Symbol.Border.IsVisible = true;
            myCurve.Symbol.Fill = new Fill(Color.Green);


            //myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45.0f);
            //myPane.Fill = new Fill(Color.White, Color.SlateGray, 45.0f);
            myPane.Fill = new Fill(Color.WhiteSmoke);

            zgc.AxisChange();
            zgc.Invalidate();
        }
        private void process1_Exited(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// О программе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            AboutBox1 About = new AboutBox1();
            About.AccessibleDescription = "Программа для построения деревьев решений";
            About.ShowDialog();
        }

        /// <summary>
        ///  Просмотреть дерево
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            asd.Visible = true;
        }
        /// <summary>
        /// Показать окно свойств для построения дерева
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void показатьОкноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tree_property.ShowDialog();
        }
        /// <summary>
        /// Экспорт картинки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Files png (*.png)|*.png|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string adss_png = Path.Combine(Application.StartupPath, "Resources\\recursion.png");
                string filename = saveFileDialog1.FileName;
                try
                {
                    File.Copy(adss_png, filename, true);
                }
                catch (Exception a)
                {
                    string h = a.Message;
                }
            }
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {


        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            e.ToolTipSize = new Size(200, 70);
            var s = e.AssociatedControl;
        }

        private void decisionTreeView1_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
