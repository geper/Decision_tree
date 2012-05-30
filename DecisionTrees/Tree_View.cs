using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DecisionTrees
{
    /// <summary>
    /// Просмотр дерева
    /// </summary>
    public partial class Tree_View : Form
    {
        public Tree_View()
        {
            InitializeComponent();

        }
       /// <summary>
       /// Блокируем кнопку закрытия главного окна
       /// </summary>
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        public UserControl1 UserControl1
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void Tree_View_FormClosing(object sender, FormClosingEventArgs e)
        {
            userControl11.image1.Source = null;
            this.Dispose(true);
        } 

    }
}
