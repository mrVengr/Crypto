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
using System.Windows.Shapes;

namespace Triterium
{
    /// <summary>
    /// Interaction logic for Excuse.xaml
    /// </summary>
    public partial class Excuse : Window
    {
        public Excuse(Triterius trit)
        {
            InitializeComponent();
            _triterium = trit;
            _triterium.encode_type = "None";
        }
        Triterius _triterium = new Triterius();
    
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(((ComboBoxItem)comboBox.SelectedItem).Name=="Linear")
            {
                AtextBox.IsEnabled = true;
                BtextBox.IsEnabled = true;
                CtextBox.IsEnabled = false;
                KeyWordtextBox.IsEnabled = false;
            }
            if (((ComboBoxItem)comboBox.SelectedItem).Name == "NonLinear")
            {
                AtextBox.IsEnabled = true;
                BtextBox.IsEnabled = true;
                CtextBox.IsEnabled = true;
                KeyWordtextBox.IsEnabled = false;
            }
            if (((ComboBoxItem)comboBox.SelectedItem).Name == "Keyword")
            {
                AtextBox.IsEnabled = false;
                BtextBox.IsEnabled = false;
                CtextBox.IsEnabled = false;
                KeyWordtextBox.IsEnabled = true;
            }
        }

        private void OKbutton_Click(object sender, RoutedEventArgs e)
        {
            if ((ComboBoxItem)comboBox.SelectedItem != null)
            {
                try {_triterium.a = Int32.Parse(AtextBox.Text); } catch  { }
                try { _triterium.b = Int32.Parse(BtextBox.Text); } catch { }
                try { _triterium.c = Int32.Parse(CtextBox.Text); } catch { }
                _triterium.keyword = KeyWordtextBox.Text;
                _triterium.encode_type = ((ComboBoxItem)comboBox.SelectedItem).Name;
            }
            else _triterium.encode_type = "None";
            this.Close();
        }

        private void Cancelbutton_Click(object sender, RoutedEventArgs e)
        {
            _triterium.encode_type = "None";
            this.Close();
        }
    }
}
