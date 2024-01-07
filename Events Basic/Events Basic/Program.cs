//From : Microsoft 
//How to: Raise and Consume Events

using System;
/*
namespace EventsExample1
{
    class Program
    {
        static void Main(string[] args)
        {
            Counter cnt = new Counter(new Random().Next(10));
            cnt.ThresholdReached += c_ThresholdReached;

            Console.WriteLine("Press 'j' key to increase total");
            while(Console.ReadKey(true).KeyChar == 'j')
            {
                Console.WriteLine("Adding One");
                cnt.Add(1);
            }
        }
        static void c_ThresholdReached(object sender, EventArgs e)
        {
            Console.WriteLine("The threshold was reached.");
            Environment.Exit(0);
        }
    }
    class Counter
    {
        private int thresHold;
        private int total;
        public Counter(int th)
        {
            thresHold = th;
        }
        public void Add(int frn)
        {
            total += frn;
            if(total >= thresHold)
            {
                ThresholdReached?.Invoke(this,EventArgs.Empty);
            }
        }
        public event EventHandler ThresholdReached;

    }
}*/

namespace EventsExample2
{
    class Program
    {
        public static void Main(string[] args)
        {
            Counter cnt = new Counter(new Random().Next(10));
            cnt.ThresholdReached += c_ThresholdReached;

            Console.WriteLine("Press 'j' to increase total ..");
            while (Console.ReadKey(true).KeyChar == 'j')
            {
                Console.WriteLine("Adding 1");
                cnt.Add(1);
            }
        }
        static void c_ThresholdReached(object snder, ThresholdReachedEventArgs e)
        {
            Console.WriteLine("The threshold of {0} was reached at {1}.", e.Threshold, e.TimeReached);
        }
    }
    class Counter
    {
        private int threshold;
        private int total;
        public Counter(int th)
        {
            threshold = th;
        }
        public void Add(int frn)
        {
            total += frn;
            if (total >= threshold)
            {
                ThresholdReachedEventArgs arg = new ThresholdReachedEventArgs();
                arg.Threshold = threshold;
                arg.TimeReached = DateTime.Now;
                OnThresholdReached(arg);
            }

        }
        protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
        {
            EventHandler<ThresholdReachedEventArgs> handler = ThresholdReached;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        
        public event EventHandler<ThresholdReachedEventArgs>  ThresholdReached;
    }
    public class ThresholdReachedEventArgs : EventArgs
    {
        public int Threshold { get; set; }
        public DateTime TimeReached { get; set; }
    }

}
