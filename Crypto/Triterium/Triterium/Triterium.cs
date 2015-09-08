using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ParentCrypto;


namespace Triterium
{
   
    public class Triterius : ParentCypher
    {
        public int a { get; set; }
        public int b { get; set; }
        public int c {get;set;}
        public string keyword { get; set; }
        public string encode_type { get; set; }

        public Triterius()
        {
            
        }

        public Window window;
        public Grid grid;
        public TextBox textbox;

        public void Form()
        {
            window = new Window();
            window.Height = 250;
            window.Width = 350;
            window.MaxHeight = 250;
            window.MaxWidth = 350;
            window.MinHeight = 250;
            window.MinWidth = 350;

            LinearGradientBrush myBrush = new LinearGradientBrush();
            myBrush.GradientStops.Add(new GradientStop(Colors.White, 0.0));
            myBrush.GradientStops.Add(new GradientStop(Colors.Black, 0.5));
            myBrush.GradientStops.Add(new GradientStop(Colors.Red, 1.0));
            window.Background = myBrush;

            grid = new Grid();
            grid.ShowGridLines = true;
            RowDefinition rowDef1 = new RowDefinition();
            RowDefinition rowDef2 = new RowDefinition();
            RowDefinition rowDef3 = new RowDefinition();
            grid.RowDefinitions.Add(rowDef1);
            grid.RowDefinitions.Add(rowDef2);
            grid.RowDefinitions.Add(rowDef3);


            window.Content = grid;

            window.ShowDialog();
        }

        public override string Encrypt()
        {

            Excuse ex = new Excuse(this);
            ex.ShowDialog();

            string result = "";

            if (encode_type != "None")
            {
                for (int i = 0; i < Message.Length; ++i)
                {
                    int offset = Offset(i + 1);
                    int L = ((int)Message[i] + offset);
                    L = L % char.MaxValue;                    
                    result += (char)(L);
                }
            }
            if (String.IsNullOrEmpty(result))
                return Message;
            else return result;
        }


        public override string Decrypt()
        {

            string result = "";

            Excuse ex = new Excuse(this);
            ex.ShowDialog();
            if (encode_type != "None")
            {
                for (int i = 0; i < Message.Length; ++i)
                {
                    int offset = Offset(i + 1);
                    int L = ((int)Message[i] - offset);// % 65535;
                    while (L - offset < 0)
                    { L += char.MaxValue ; }
                    L = L % char.MaxValue;

                    result += (char)(L);
                }
            }
            if (String.IsNullOrEmpty(result))
                return Message;
            else return result;
        }




        private int Offset(int pos)
        {
            if (encode_type == "Linear")
                return LinearOffset(pos);
            else if (encode_type == "NonLinear")
                return NonLinearOffset(pos);
            else return WordOffset(pos);
        }

        private int LinearOffset( int pos)
        {
            int result;
            result = a * pos + b;
            return result;
        }
        private int NonLinearOffset(int pos)
        {
            int result;
            result = a * pos * pos + b * pos * c;
            return result;
        }
        private int WordOffset(int pos)
        {
            return (int)keyword[pos % keyword.Length];
        }


        //private int 
    }
}
