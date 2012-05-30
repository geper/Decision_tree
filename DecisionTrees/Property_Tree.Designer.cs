namespace DecisionTrees
{
    partial class Property_Tree
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Continyu = new System.Windows.Forms.Button();
            this.Save_P = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.Alg_Tree = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown_In = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Out = new System.Windows.Forms.NumericUpDown();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_In)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Out)).BeginInit();
            this.SuspendLayout();
            // 
            // Continyu
            // 
            this.Continyu.Location = new System.Drawing.Point(196, 225);
            this.Continyu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Continyu.Name = "Continyu";
            this.Continyu.Size = new System.Drawing.Size(129, 42);
            this.Continyu.TabIndex = 0;
            this.Continyu.Text = "Продолжить";
            this.Continyu.UseVisualStyleBackColor = true;
            this.Continyu.Click += new System.EventHandler(this.Continyu_Click);
            // 
            // Save_P
            // 
            this.Save_P.Location = new System.Drawing.Point(15, 225);
            this.Save_P.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Save_P.Name = "Save_P";
            this.Save_P.Size = new System.Drawing.Size(161, 42);
            this.Save_P.TabIndex = 0;
            this.Save_P.Text = "Сохранить парматры в файл";
            this.Save_P.UseVisualStyleBackColor = true;
            this.Save_P.Click += new System.EventHandler(this.Save_P_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(15, 185);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(297, 21);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Больше не показывать окно Параметры";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Alg_Tree
            // 
            this.Alg_Tree.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Alg_Tree.Items.AddRange(new object[] {
            "C4.5",
            "ID3"});
            this.Alg_Tree.Location = new System.Drawing.Point(15, 34);
            this.Alg_Tree.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Alg_Tree.Name = "Alg_Tree";
            this.Alg_Tree.Size = new System.Drawing.Size(101, 24);
            this.Alg_Tree.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выберите  алгоритм построения дерева решений";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(265, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Введите количество входных столбцов";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(238, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Введите номер выходного столбца\r\n";
            // 
            // numericUpDown_In
            // 
            this.numericUpDown_In.Location = new System.Drawing.Point(15, 91);
            this.numericUpDown_In.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDown_In.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_In.Name = "numericUpDown_In";
            this.numericUpDown_In.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown_In.TabIndex = 7;
            this.numericUpDown_In.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown_Out
            // 
            this.numericUpDown_Out.Location = new System.Drawing.Point(15, 146);
            this.numericUpDown_Out.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDown_Out.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Out.Name = "numericUpDown_Out";
            this.numericUpDown_Out.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown_Out.TabIndex = 7;
            this.numericUpDown_Out.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // Property_Tree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 272);
            this.Controls.Add(this.numericUpDown_Out);
            this.Controls.Add(this.numericUpDown_In);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Alg_Tree);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.Save_P);
            this.Controls.Add(this.Continyu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Property_Tree";
            this.Text = "Параметры ";
            this.Load += new System.EventHandler(this.Property_Tree_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_In)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Out)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Continyu;
        private System.Windows.Forms.Button Save_P;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox Alg_Tree;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown_In;
        private System.Windows.Forms.NumericUpDown numericUpDown_Out;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}