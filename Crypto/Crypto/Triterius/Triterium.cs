using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace Crypto
{
   
    public class Triterius : ParentCypher
    {
        public int a { get; set; }
        public int b { get; set; }
        public int c {get;set;}
        public string keyword { get; set; }
        public string encode_type { get; set; }

        public Triterius() { }        

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
        
    }
}
