using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Triterium
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string test = "test лол 12312";
        private void button_Click(object sender, RoutedEventArgs e)
        {
            //Triterius t = new Triterius();
            //test = t.Encode(test);
            //MessageBox.Show(test);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            //Triterius t = new Triterius();
            //test = t.Decode(test);
            //MessageBox.Show(test);
        }
    }
}
