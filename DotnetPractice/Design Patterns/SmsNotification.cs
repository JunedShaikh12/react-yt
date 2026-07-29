using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    internal class SmsNotification : INotification
    {
        public void Send()
        {
            Console.WriteLine("Sending SMS Notification...");
        }
    }
}
