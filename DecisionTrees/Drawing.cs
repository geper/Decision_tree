using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accord.MachineLearning;
using Accord.MachineLearning.DecisionTrees;
using Accord.MachineLearning.DecisionTrees.Learning;
using System.IO;
using System.Windows.Forms;



namespace DecisionTrees
{
    class Drawing
    {

        StringBuilder str;

        List<string> dinosaurs = new List<string>();

        public Drawing()
        {
            str = new StringBuilder();
            dinosaurs.Add("Root");
            str.AppendLine("Root");
        }

        /// <summary>
        /// перебор дерева по веткам
        /// </summary>
        /// <param name="D_Node"></param>
        /// <param name="D_B_N_C"></param>
        /// <param name="l"></param>
        public void recursion(DecisionNode D_Node, DecisionBranchNodeCollection D_B_N_C, int l)
        {
            int j;
            if (D_B_N_C != null)
            {

                for (j = 0; j < D_B_N_C.Count; j++)
                {
                    // MessageBox.Show(D_B_N_C[j].ToString());
                    dinosaurs.Add(D_B_N_C[j].ToString());
                    str.AppendLine(D_B_N_C[j].ToString());

                    recursion(D_B_N_C[j].Parent, D_B_N_C[j].Branches, j);
                }
                dinosaurs.Add("E");
               // dinosaurs.Add(D_Node.ToString());
                str.AppendLine("E");
                str.AppendLine(D_Node.ToString());

            }

            str.AppendLine(D_Node.Branches[l].Output.ToString());
            dinosaurs.Add(D_Node.Branches[l].Output.ToString());

            //dinosaurs.Add(D_Node.Branches[l].Output.ToString());

            dinosaurs.Add("WER");
            str.AppendLine("WER");
            dinosaurs.Add(D_Node.ToString());
            str.AppendLine(D_Node.ToString());


        }
        /// <summary>
        /// Сохранение в файл
        /// </summary>
        public void Save_()
        {
            StreamWriter sr;
            string filename = ".//Resources//recursion.txt";
            sr = new StreamWriter(filename);
            sr.Write(str);
            sr.Close();

            Search_on();
            Str_To_gv(dinosaurs);
        }
        /// <summary>
        /// техт то gv
        /// </summary>
        /// <param name="str_"></param>
        public void Str_To_gv(List <string> str_)
        {

            StringBuilder Str_out = new StringBuilder();
            Str_out.AppendLine("digraph G {");

                for (int i =0;i<str_.Count-1;i++)
                {
                    
                    if (str_[i + 1] == "WER" && str_[i] != "WER" && str_[i] != "E" || str_[i + 1] == "E" && str_[i] != "WER" && str_[i] != "E")
                    {
                        Str_out.AppendLine("\"" +str_[i] + " \nid:"+i.ToString() + "\"");
                        Str_out.AppendLine(";");
                    }
                     if (i + 1 == str_.Count && str_[i] != "WER" && str_[i] != "E")
                    {
                       // Str_out.AppendLine("\"" + str_[i] + "\"");
                        Str_out.AppendLine(";");
                    }
                    //else if (str_[i+1] == "E")
                    //{
                    //    Str_out.AppendLine(str_[i]);
                    //}
                     if (str_[i] != "WER" && str_[i] != "E"&&str_[i + 1] != "WER" && str_[i + 1] != "E" )
                    {
                        Str_out.AppendLine("\""+ str_[i] +"\"");
                      Str_out.AppendLine("->");
                    }
                }
                Str_out.AppendLine("}");

                StreamWriter sr;
                string filename = ".//Resources//recursion.gv";
                sr = new StreamWriter(filename);
                sr.Write(Str_out);
                sr.Close();

                GV_TO_Png();

        }
        /// <summary>
        /// Удаляем совпадения
        /// </summary>
        public void Search_on()
        {  
            int indfg=0;
            dinosaurs.RemoveAt(dinosaurs.Count-1);
           
            for (int l = 0; l < dinosaurs.Count; l++)
            {
                if (dinosaurs[l] == "")
                {
                    dinosaurs.RemoveAt(l);
                }
            }

            for (int j = 0; j < dinosaurs.Count; j++)
            {

                if (dinosaurs[j] == "WER")
                {
                    indfg=j;
                    for (int i = j+1; i < dinosaurs.Count; i++)
                    {
                        if (dinosaurs[i] == "WER")
                        {
                            indfg = 0;
                            break;
                        }
                        if (dinosaurs[i] == "E" || indfg + 1 == dinosaurs.Count)
                        {

                            dinosaurs.RemoveRange(indfg, i - indfg);

                            break;
                        }
                    }
                }

              //  str_.Find(str_[j].ToString());
            }
            for (int z = 0; z < dinosaurs.Count; z++)
            {
                if (dinosaurs[z] == "Root" && z + 1 != dinosaurs.Count)
                {

                    if (dinosaurs[z] == "Root" && dinosaurs[z + 1] == "WER")
                    {
                        dinosaurs.RemoveAt(z);
                    }

                }
                if (dinosaurs[z] == "Root" && z + 1 == dinosaurs.Count)
                {


                    dinosaurs.RemoveAt(z);
                }
                
            }



        }
        /// <summary>
        /// GV to Png
        /// </summary>
        public void GV_TO_Png()
        {
            System.Diagnostics.Process MyProc = new System.Diagnostics.Process();

              
            string adss = Path.Combine(Application.StartupPath, "Resources\\recursion.gv");
            string adss_png = Path.Combine(Application.StartupPath, "Resources\\recursion.png");
          //  string adss_png1 = Path.Combine(Application.StartupPath, "Resources\\recursion1.png");
          // File.Delete(adss_png);

            MyProc.StartInfo.FileName = "dot.exe";
            //MyProc.StartInfo.Arguments = @" -Tpng -o D:\5.png D:\1.gv";
            try
            {
               // File.Delete(adss_png);
                MyProc.StartInfo.Arguments = @" -Tpng -o " + "\"" + adss_png + "\"" + " " + "\"" + adss + "\"";

            }
            catch (IOException e)
            {
            //    MyProc.StartInfo.Arguments = @" -Tpng -o " + "\"" + adss_png1 + "\"" + " " + "\"" + adss + "\"";
            }

          
          
            //MyProc.StartInfo.Arguments = @" -Tpng -o " +  adss_png  + " " + adss;

            bool gj = MyProc.StartInfo.UseShellExecute;
            bool g = MyProc.Start();
        }
    }
}
