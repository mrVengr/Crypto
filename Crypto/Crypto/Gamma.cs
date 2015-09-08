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
    class Gamma : ParentCypher
    {
        private string _passwd;

        public string Passwd // шаг для шифровки и расшифровки
        {
            get { return _passwd; }
            set { _passwd = value; }
        }

        public Gamma()
        {
            Form();

            this.Passwd = curPasswd;
        }


        public override string Encrypt() // шифровка сообщения
        {
            if (Message != null)
            {
                string res = "";
                string currHesh = Convert.ToString(Math.Abs(this.Passwd.GetHashCode()));
                string randp = currHesh;
                while (randp.Length <= this.Message.Length)
                {
                    currHesh = Convert.ToString(Math.Abs(currHesh.GetHashCode()));
                    randp += currHesh;
                }
                for (int i = 0; i < this.Message.Length; i++)
                {
                    res += Convert.ToChar(((int)this.Message[i] + (int)randp[i]) % Char.MaxValue);
                }
                return res;
            }
            else return "No Message found";
        }
        public override string Decrypt() // расшифровка сообщения
        {
            if (EncryptedMessage != null)
            {
                string resMessage = "";
                string currHesh = Convert.ToString(Math.Abs(Passwd.GetHashCode()));
                string randp = currHesh;
                while (randp.Length <= EncryptedMessage.Length)
                {
                    currHesh = Convert.ToString(Math.Abs(currHesh.GetHashCode()));
                    randp += currHesh;
                }
                for (int i = 0; i < EncryptedMessage.Length; i++)
                {
                    resMessage += Convert.ToChar(((int)EncryptedMessage[i] - (int)randp[i] + Char.MaxValue) % Char.MaxValue);
                }
                return resMessage;
            }
            else return "No EncryptedMessage found";
        }

        public string curPasswd;
        public TextBox textPasswd;
        public Window messageWindow;

        public void Form()
        {
            messageWindow = new Window();
            messageWindow.Height = 250;
            messageWindow.Width = 350;
            messageWindow.MaxHeight = 250;
            messageWindow.MaxWidth = 350;
            messageWindow.MinHeight = 250;
            messageWindow.MinWidth = 350;

            Grid grid = new Grid();
            grid.ShowGridLines = true;
            RowDefinition rowDef1 = new RowDefinition();
            RowDefinition rowDef2 = new RowDefinition();
            RowDefinition rowDef3 = new RowDefinition();
            grid.RowDefinitions.Add(rowDef1);
            grid.RowDefinitions.Add(rowDef2);
            grid.RowDefinitions.Add(rowDef3);

            Label lab = new Label();
            lab.Content = "Введите пароль";
            lab.FontSize = 14;
            lab.Foreground = new SolidColorBrush(Colors.White);
            lab.HorizontalAlignment = HorizontalAlignment.Center;
            lab.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(lab, 0);

            textPasswd = new TextBox();
            textPasswd.Height = 30;
            textPasswd.Width = 120;
            textPasswd.HorizontalAlignment = HorizontalAlignment.Center;
            textPasswd.VerticalAlignment = VerticalAlignment.Center;
            textPasswd.TextAlignment = TextAlignment.Center;
            Grid.SetRow(textPasswd, 1);

            Button butOk = new Button();
            butOk.Content = "Ok";
            butOk.Height = 30;
            butOk.Width = 70;
            //butOk.ClickMode = ClickMode.Press;
            butOk.Click += butOk_Click;
            Grid.SetRow(butOk, 2);

            grid.Children.Add(lab);
            grid.Children.Add(textPasswd);
            grid.Children.Add(butOk);
            messageWindow.Content = grid;

            messageWindow.ShowDialog();

        }
        private void butOk_Click(object sender, EventArgs e)
        {
            if (this.textPasswd.Text != "")
            {
                curPasswd = textPasswd.Text;
                this.messageWindow.Close();
            }
        }
    }
}
