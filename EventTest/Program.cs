using System;
using System.Threading;

namespace EventTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press 'a' to simulate a button click");
            if (Console.ReadLine() == "a")
            Click();
        }

        public static void Click()
        {
            var clickAction = new ClickAction();

            //The first time the break point hits, it is instantiating the Event so when the event is fired, it isnt null
            clickAction.ClickEvent += (source, args) => //Set break point here
            {
                Console.WriteLine(args.Title);
            };
            clickAction.Encode(); //Set break point here
        }

    }

    public class ClickAction
    {
        public event EventHandler<MyEventArgs> ClickEvent;

        public void Encode()
        {
            MyEventArgs myEventArgs = new MyEventArgs();
            myEventArgs.Title = "Hello World";

            //This code checks to see if the event is null, and if it isnt, it invokes the event.

            ClickEvent?.Invoke(this, myEventArgs); //set break point here
            // if you hover it, you will see that it isnt null, 
            //thats because it was instantiated in the other method prior to being called

            //*************************************************************
            // if "ClickEvent?.Invoke(this, EventArgs.Empty);" doesnt make sense,
            // you can rewrite it by using the following: 
            // if (ClickEvent != null) ClickEvent(this, EventArgs.Empty)
            //Just replace the two and you will see they do exactly the same thing.
            //*************************************************************

        }
    }

    public class MyEventArgs: EventArgs
    {
        public string Title { get; set; }
    }
}
