using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.IO;

using WPFExtensions;
using System.Net.Cache;

namespace DecisionTrees
{
    
    
    
    /// <summary>
    /// Загрузка дерева
    /// </summary>
    public partial class UserControl1 : UserControl
    {

        int g;


        public UserControl1()
        {
            InitializeComponent();
            g = this.GetHashCode();
           
            
        }
        public void Load_f(string str)
        {
            // Create source.
            BitmapImage bi = new BitmapImage();

            string adss_png = System.IO.Path.Combine(str, "Resources\\recursion.png");
            string to_adss_png = System.IO.Path.Combine(str, "Resources\\recursion1.png");
          //  string adss_png = System.IO.Path.Combine( ".\\Resources\\recursion.png");
          //  string to_adss_png = System.IO.Path.Combine(".\\Resources\\recursion1.png");

            image1.Source = null;

           // bi.BeginInit();
           // bi.
           //// bi.UriSource = new Uri("");
           // bi.EndInit();

            try
            {
                File.Copy(adss_png, to_adss_png, true);
            }
            catch (Exception e) 
            {
                string g =e.Message;
            }

            // File.Delete(".\\Resources\\recursion1.png");
            bi.BeginInit();
            bi.CacheOption=BitmapCacheOption.OnLoad;
            bi.UriSource = new Uri(to_adss_png);
            // Tells the networking code to ignore the download cache
            bi.UriCachePolicy = new RequestCachePolicy(RequestCacheLevel.BypassCache);
            // Tells our Uri cache to ignore the image we already have for this Uri
            bi.CreateOptions = BitmapCreateOptions.IgnoreImageCache;

            bi.EndInit();
           

            image1.Source = bi;
    

           // image1.Source = null;
           // bi.UriSource = null;
      

        }

        private void image1_Unloaded(object sender, RoutedEventArgs e)
        {
            image1.Source = null;
         
        }


    }
}
