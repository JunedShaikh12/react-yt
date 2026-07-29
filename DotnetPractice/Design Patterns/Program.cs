// See https://aka.ms/new-console-template for more information
using Design_Patterns;

Console.WriteLine("Hello, World!");


Console.WriteLine("Enter Notification Type:");
string type = Console.ReadLine();

INotification notification =
    NotificationFactory.GetNotification(type);

notification.Send();