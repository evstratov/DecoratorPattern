using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    interface INotifier
    {
        void Send(string msg);
    }
    class Notifier: INotifier
    {
        public void Send(string msg)
        {
            Console.WriteLine("Стандарткая отправка почтой");
            Console.WriteLine(msg);
        }
    }

    abstract class Decorator: INotifier
    {
        INotifier wrappee;

        public Decorator(INotifier notifier)
        {
            wrappee = notifier;
        }

        public virtual void Send(string msg)
        {
            wrappee.Send(msg);
        }
    }

    class FacebookNotifier : Decorator
    {
        public FacebookNotifier(INotifier notifier) : base(notifier) { }

        public override void Send(string msg)
        {
            FacebookSend();
            base.Send(msg);
        }
        public void FacebookSend()
        {
            Console.WriteLine("Отправка через Facebook ");
        }
    }
    class SmsNotifier : Decorator
    {
        public SmsNotifier(INotifier notifier) : base(notifier) { }

        public override void Send(string msg)
        {
            SmsSend();
            base.Send(msg);
        }
        public void SmsSend()
        {
            Console.WriteLine("Отправка через SMS ");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            INotifier simpleNotifier = new Notifier();
            simpleNotifier.Send("Only email");
            Console.WriteLine();
            INotifier facebookNotifier = new FacebookNotifier(new Notifier());
            facebookNotifier.Send("Facebook + email");
            Console.WriteLine();
            INotifier fullNotifier = new SmsNotifier(new FacebookNotifier(new Notifier()));
            fullNotifier.Send("Full sending");

            Console.Read();
        }
    }
}
