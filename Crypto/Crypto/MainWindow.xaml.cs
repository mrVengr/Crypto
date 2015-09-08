using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
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
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using SmtPop;
using System.IO;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Net.Sockets;


namespace Crypto
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



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbCodeName.Items.Add("Caesar");
        }

        private void Send(string Text)
        {
            SmtpClient Smtp = new SmtpClient("smtp.yandex.ru", 25);
            Smtp.Credentials = new NetworkCredential("khapilins@yandex.ru", "271044kot");
            Smtp.EnableSsl = true;

            MailMessage message = new MailMessage();
            message.From = new System.Net.Mail.MailAddress("khapilins@yandex.ru");
            message.To.Add(new System.Net.Mail.MailAddress("shpyta-gleb@mail.ru"));
            message.Subject = "Test";
            message.Body = Text;

            Smtp.Send(message);
        }

        private void Parse()
        {
            TcpClient tcpclient = new TcpClient(); // create an instance of TcpClient
            tcpclient.Connect("pop.mail.ru", 995); // HOST NAME POP SERVER and gmail uses port number 995 for POP 
            System.Net.Security.SslStream sslstream = new SslStream(tcpclient.GetStream()); // This is Secure Stream // opened the connection between client and POP Server
            sslstream.AuthenticateAsClient("pop.mail.ru"); // authenticate as client 
            //bool flag = sslstream.IsAuthenticated; // check flag 
            System.IO.StreamWriter sw = new StreamWriter(sslstream); // Asssigned the writer to stream
            System.IO.StreamReader reader = new StreamReader(sslstream); // Assigned reader to stream
            sw.WriteLine("USER shpyta-gleb@mail.ru"); // refer POP rfc command, there very few around 6-9 command
            sw.Flush(); // sent to server
            sw.WriteLine("PASS utybfkmyjcnm321");
            sw.Flush();
            sw.WriteLine("RETR 5");
            sw.Flush();
            sw.WriteLine("Quit "); // close the connection
            sw.Flush();
            string str = string.Empty;
            string strTemp = string.Empty;

            while ((strTemp = reader.ReadLine()) != null)
            {
                if (".".Equals(strTemp))
                {
                    break;
                }
                if (strTemp.IndexOf("-ERR") != -1)
                {
                    break;
                }
                str += strTemp;
            }

            MessageBox.Show(str);
        }




        private void ButtonEncrypt_Click(object sender, RoutedEventArgs e)
        {
            string CryptoClass = cbCodeName.Text;
            if (CryptoClass != "")
            {
                Type T = Type.GetType("Crypto." + CryptoClass);
                object Obj = Activator.CreateInstance(T);
                ((ParentCypher)Obj).Message = tbMessage.Text;
                string messageToSend = ((ParentCypher)Obj).Encrypt();
                //Send("lolo");
                MessageBox.Show(messageToSend);
            }
            else MessageBox.Show("Choose CryptoClass");

        }

        private void ButtonDecrypt_Click(object sender, RoutedEventArgs e)
        {
            Parse();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Send("kawaii");
        }



    }
}
