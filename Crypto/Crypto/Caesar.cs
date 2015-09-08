using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;


namespace Crypto
{
    public class Caesar : ParentCypher
    {
        //private string p_Message;

        //public string Message // нешифрованное сообщение
        //{
        //    get { return p_Message; }
        //    set { p_Message = value; }
        //}

        //private string p_EncryptedMessage;

        //public string EncryptedMessage //шифрованное сообщение
        //{
        //    get { return p_EncryptedMessage; }
        //    set { p_EncryptedMessage = value; }
        //}

        private int _step;

        public int Step // шаг для шифровки и расшифровки
        {
            get { return _step; }
            set { _step = value; }
        }

        #region Нижный регистр
        public static char[] MassLowerCase()
        {
            char[] mass = new char[58];
            char ch;
            int n = 0;
            for (int i = 1072; i <= 1103; i++)//1072-1103 = 32 RUS
            {
                ch = System.Convert.ToChar(i);
                mass[n] = ch;
                n++;
            }
            for (int i = 97; i <= 122; i++)// 26 ENG
            {
                ch = System.Convert.ToChar(i);
                mass[n] = ch;
                n++;
            }
            return mass;
        }

        public static char[] Mass2LowerCase(int step)
        {
            char[] mass = new char[58];
            char ch;
            int i = 1072 + step;
            for (int n = 0; n < 32; n++)
            {
                if (i > 1103)
                    i = 1072;
                ch = System.Convert.ToChar(i);
                mass[n] = ch;
                i++;
            }
            i = 97 + step;
            for (int n = 32; n < 58; n++)
            {
                if (i > 122)
                    i = 97;
                ch = System.Convert.ToChar(i);
                mass[n] = ch;
                i++;
            }
            return mass;

        }
        #endregion

        #region Верхний регистр
        public static char[] MassUpperCase()
        {
            char[] mass = new char[58];
            char ch;
            int n = 0;
            for (int i = 1040; i <= 1071; i++)//1072-1103 RUS
            {
                ch = System.Convert.ToChar(i);
                mass[n] = ch;
                n++;
            }
            for (int i = 65; i <= 90; i++)// ENG
            {
                ch = System.Convert.ToChar(i);
                mass[n] = ch;
                n++;
            }
            return mass;
        }

        public static char[] Mass2UpperCase(int step)
        {
            char[] mass = new char[58];
            char ch;
            //int n = 0;
            int i = 1040 + step;
            for (int n = 0; n < 32; n++)
            {
                if (i > 1071)
                    i = 1040;
                ch = System.Convert.ToChar(i);
                mass[n] = ch;
                i++;
            }
            i = 65 + step;
            for (int n = 32; n < 58; n++)
            {
                if (i > 90)
                    i = 65;
                ch = System.Convert.ToChar(i);
                mass[n] = ch;
                i++;
            }
            return mass;
        }
        #endregion

        public Caesar()//this.Step // конструктор
        {
            Form();
            //this.InputLine = inputLine;
            this.Step = curstep;
        }

        private string EncryptAlg(Caesar code, char[] inputMass) // алгоритм шифровки
        {
            string output;

            char[] outputMass = new char[inputMass.Length];

            char[] ABClower = Caesar.MassLowerCase();
            char[] BCAlower = Caesar.Mass2LowerCase(this.Step);
            char[] ABCupper = Caesar.MassUpperCase();
            char[] BCAupper = Caesar.Mass2UpperCase(this.Step);

            int[] currentPos = new int[inputMass.Length];
            int n = 0;
            int index = 0;
            while (n < inputMass.Length)
            {
                for (int i = 0; i < ABClower.Length; i++)
                {
                    if (inputMass[n] == ABClower[i] || inputMass[n] == ABCupper[i])
                    {
                        if (inputMass[n] == ABClower[i])
                            currentPos[index] = i + 100;
                        else if (inputMass[n] == ABCupper[i])
                            currentPos[index] = i + 1000;
                    }

                    if (inputMass[n] == ' ' || inputMass[n] == '.' ||
                        inputMass[n] == ',' || inputMass[n] == ':' ||
                        inputMass[n] == ';' || inputMass[n] == '?' ||
                        inputMass[n] == '!' || inputMass[n] == '-')
                    {
                        currentPos[index] = (int)inputMass[n];
                    }
                }
                n++;
                index++;

            }
            int ind = 0;
            //char ch = '0';
            while (ind < currentPos.Length)
            {
                for (int i = 0; i < BCAlower.Length; i++)
                {
                    if (currentPos[ind] - 100 == i || currentPos[ind] - 1000 == i)
                    {
                        if (currentPos[ind] - 100 == i)
                            outputMass[ind] = BCAlower[i];
                        else if (currentPos[ind] - 1000 == i)
                            outputMass[ind] = BCAupper[i];
                    }

                    if (currentPos[ind] == 32 || currentPos[ind] == 46 ||
                        currentPos[ind] == 44 || currentPos[ind] == 58 ||
                        currentPos[ind] == 59 || currentPos[ind] == 63 ||
                        currentPos[ind] == 33 || currentPos[ind] == 45)
                    {
                        outputMass[ind] = (char)currentPos[ind];
                    }
                }
                ind++;
            }
            return output = new string(outputMass);
        }

        public int curstep;
        public TextBox textStep;
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

            LinearGradientBrush myBrush = new LinearGradientBrush();
            myBrush.GradientStops.Add(new GradientStop(Colors.White, 0.0));
            myBrush.GradientStops.Add(new GradientStop(Colors.Black, 0.5));
            myBrush.GradientStops.Add(new GradientStop(Colors.Red, 1.0));
            messageWindow.Background = myBrush;

            Grid grid = new Grid();
            grid.ShowGridLines = true;
            RowDefinition rowDef1 = new RowDefinition();
            RowDefinition rowDef2 = new RowDefinition();
            RowDefinition rowDef3 = new RowDefinition();
            grid.RowDefinitions.Add(rowDef1);
            grid.RowDefinitions.Add(rowDef2);
            grid.RowDefinitions.Add(rowDef3);

            Label lab = new Label();
            lab.Content = "Введите шаг";
            lab.FontSize = 14;
            lab.Foreground = new SolidColorBrush(Colors.White);
            lab.HorizontalAlignment = HorizontalAlignment.Center;
            lab.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(lab, 0);

            textStep = new TextBox();
            textStep.Height = 30;
            textStep.Width = 30;
            textStep.HorizontalAlignment = HorizontalAlignment.Center;
            textStep.VerticalAlignment = VerticalAlignment.Center;
            textStep.TextAlignment = TextAlignment.Center;
            Grid.SetRow(textStep, 1);

            Button butOk = new Button();
            butOk.Content = "Ok";
            butOk.Height = 30;
            butOk.Width = 70;
            //butOk.ClickMode = ClickMode.Press;
            butOk.Click += butOk_Click;
            Grid.SetRow(butOk, 2);

            grid.Children.Add(lab);
            grid.Children.Add(textStep);
            grid.Children.Add(butOk);
            messageWindow.Content = grid;

            messageWindow.ShowDialog();

        }

        public override string Encrypt() // шифровка сообщения
        {
            string output = "";

            char[] inputMass = this.Message.ToCharArray();
            int i = 0;

            char[] massUpper = Caesar.MassUpperCase();
            char[] massLower = Caesar.MassLowerCase();

            while (i < 58)
            {
                if (inputMass[0] == massLower[i] || inputMass[0] == massUpper[i])
                {
                    output = EncryptAlg(this, inputMass);
                    break;
                }
                i++;
            }
            return output;
        }

        public override string Decrypt() // расшифровка сообщения
        {
            string output = "";

            char[] inputMass = this.EncryptedMessage.ToCharArray();
            int i = 0;

            char[] massUpper = Caesar.Mass2UpperCase(this.Step);
            char[] massLower = Caesar.Mass2LowerCase(this.Step);

            while (i < 58)
            {
                if (inputMass[0] == massLower[i] || inputMass[0] == massUpper[i])
                {
                    output = DecryptAlg(this, inputMass);
                    break;
                }
                i++;
            }
            return output;
        }

        public string DecryptAlg(Caesar code, char[] inputMass) // алгоритм дешифровки
        {
            string output;

            char[] outputMass = new char[inputMass.Length];

            char[] BCAlower = Caesar.MassLowerCase();
            char[] ABClower = Caesar.Mass2LowerCase(code.Step);
            char[] BCAupper = Caesar.MassUpperCase();
            char[] ABCupper = Caesar.Mass2UpperCase(code.Step);

            int[] currentPos = new int[inputMass.Length];
            int n = 0;
            int index = 0;
            while (n < inputMass.Length)
            {
                for (int i = 0; i < ABClower.Length; i++)
                {
                    if (inputMass[n] == ABClower[i] || inputMass[n] == ABCupper[i])
                    {
                        if (inputMass[n] == ABClower[i])
                            currentPos[index] = i + 100;
                        else if (inputMass[n] == ABCupper[i])
                            currentPos[index] = i + 1000;
                    }

                    if (inputMass[n] == ' ' || inputMass[n] == '.' ||
                        inputMass[n] == ',' || inputMass[n] == ':' ||
                        inputMass[n] == ';' || inputMass[n] == '?' ||
                        inputMass[n] == '!' || inputMass[n] == '-')
                    {
                        currentPos[index] = (int)inputMass[n];
                    }
                }
                n++;
                index++;

            }
            int ind = 0;
            //char ch = '0';
            while (ind < currentPos.Length)
            {
                for (int i = 0; i < BCAlower.Length; i++)
                {
                    if (currentPos[ind] - 100 == i || currentPos[ind] - 1000 == i)
                    {
                        if (currentPos[ind] - 100 == i)
                            outputMass[ind] = BCAlower[i];
                        else if (currentPos[ind] - 1000 == i)
                            outputMass[ind] = BCAupper[i];
                    }

                    if ((char)currentPos[ind] == ' ' || (char)currentPos[ind] == '.' ||
                        (char)currentPos[ind] == ',' || (char)currentPos[ind] == ':' ||
                        (char)currentPos[ind] == ';' || (char)currentPos[ind] == '?' ||
                        (char)currentPos[ind] == '!' || (char)currentPos[ind] == '-')
                    {
                        outputMass[ind] = (char)currentPos[ind];
                    }
                }
                ind++;
            }
            return output = new string(outputMass);
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            if (this.textStep.Text != "")
            {
                curstep = Convert.ToInt32(textStep.Text);
                this.messageWindow.Close();
            }
        }
    }
}
