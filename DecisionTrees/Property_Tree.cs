using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DecisionTrees
{
    /// <summary>
    /// Окно параметров построения дерева решений
    /// </summary>
    public partial class Property_Tree : Form
    {
        #region параметры
        /// <summary>
        /// Алгоритм построения дерева решений
        /// </summary>
        public String Alg;
     
        /// <summary>
        /// Количество входных параметров
        /// </summary>
        public int Coun_In;
   
        /// <summary>
        /// Количество выходных параметров
        /// </summary>
        public int Coun_Out;
  
        /// <summary>
        /// Показывать окно или нет
        /// </summary>
        public bool Property_View;

        #endregion
        /// <summary>
        /// Инициализация 
        /// </summary>
        public Property_Tree()
        {
            InitializeComponent();
            Alg_Tree.SelectedIndex = 0;
            Property_View = true;
            Load_P();

            toolTip1.SetToolTip(numericUpDown_Out, "введите элемент считая \n пробировать в селпрор");
        }
        private void Property_Tree_Load(object sender, EventArgs e)
        {
            checkBox1.Checked =! Property_View;

           Alg_Tree.Items[Alg_Tree.SelectedIndex] = Alg;
           numericUpDown_In.Text=Coun_In.ToString();
           numericUpDown_Out.Text=Coun_Out.ToString();

        }
        /// <summary>
        /// Сохранение в файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_P_Click(object sender, EventArgs e)
        {
            StreamWriter sr;
            string filename = ".//Resources//Property.txt";
            sr = new   StreamWriter (filename);
            sr.WriteLine(Alg_Tree.Items[Alg_Tree.SelectedIndex]);
            sr.WriteLine(numericUpDown_In.Text);
            sr.WriteLine(numericUpDown_Out.Text);
            sr.Close();
        }
        /// <summary>
        /// Чтение параметров из файла
        /// </summary>
        private void Load_P()
        {
            try
            {
                StreamReader sr;
                string filename = ".//Resources//Property.txt";
                sr = new StreamReader(filename, Encoding.GetEncoding(1251));

                Alg = sr.ReadLine();
                Coun_In = Convert.ToInt32(sr.ReadLine());
                Coun_Out = Convert.ToInt32(sr.ReadLine());

                sr.Close();

                View();
            }
            catch 
            {
                MessageBox.Show("Файл ненайден");
            }
        }
        /// <summary>
        /// Отображаем в компонентах параметры 
        /// </summary>
        private void View()
        {
            numericUpDown_Out.Text = Coun_Out.ToString();
            numericUpDown_In.Text = Coun_In.ToString();
            for (int j = 0; j < Alg_Tree.Items.Count; j++)
            {
                if (Alg_Tree.Items[j].ToString() == Alg)
                {
                    Alg_Tree.SelectedIndex = j;
                }
            }
        }
        /// <summary>
        /// Возврат к главному окну
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Continyu_Click(object sender, EventArgs e)
        {
           
            Property_View = !checkBox1.Checked;
            Alg = Alg_Tree.Items[Alg_Tree.SelectedIndex].ToString();
            Coun_In = Convert.ToInt32(numericUpDown_In.Text);
            Coun_Out = Convert.ToInt32(numericUpDown_Out.Text);
            this.Close();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            e.ToolTipSize = new Size(100, 50);
            var s= e.AssociatedControl;
            if (s != null)
            {
            }
        }
    }
}
