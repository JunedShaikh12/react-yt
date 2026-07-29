using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    public class NotificationFactory
    {
        public static INotification GetNotification(string type)
        {
            switch(type.ToLower())
            {
                case "email":
                    return new EmailNotification();

                case "sms":
                    return new SmsNotification();

                case "whatsapp":
                    return new WhatsAppNotification();
                default:
                    throw new Exception("INVALID TYPE");
            }
        }
    }
}
