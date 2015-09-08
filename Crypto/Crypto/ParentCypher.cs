using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    public class ParentCypher
    {

        public string Message; //Незашифрованное сообщение.


       
        public string EncryptedMessage; //Зашифрованное сообщение

       
        public ParentCypher()
        {

        }


        virtual public string Encrypt()
        {
            if (Message != null)
            {
                //Шифрование переменной Message
                //Присвоение EncryptedMessage значению результата шифрования
                return EncryptedMessage;  //Метод возвращает результат кодирования
            }
            else return "No Message found";
        }

        virtual public string Decrypt()
        {
            if (EncryptedMessage != null)
            {
                //Расшифрование переменной EncryptedMessage
                //Присвоение Message значению результата расшифрования
                return Message;  //Метод возвращает результат декодирования
            }
            else return "No EncryptedMessage found";
        } 
    }
}
