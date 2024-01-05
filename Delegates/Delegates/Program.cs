using System;

namespace Delegates
{

    //Delegates : Static method references 
    class Program
    {
        delegate void LogDel(string text);
        static void Main(string[] args)
        {
            Log log = new Log();
            /* LogDel logdel = new LogDel(LogTextToFile);

             Console.WriteLine("Please Enther the Name :");
             var name = Console.ReadLine();
             logdel(name);

             Console.ReadKey();


            
             LogDel logDel1 = new LogDel(log.LogTextToScreen);
             Console.WriteLine("Enter your Name :");
             var name1 = Console.ReadLine();
             logDel1(name1);

            Log log1 = new Log();
            LogDel ld2 = new LogDel(log1.LogTextToFile);
            Console.WriteLine("Hi hello bolneka time nahi re Nam bata:");
            var name = Console.ReadLine();
            ld2(name);
            Console.ReadKey();*/

            // Multicast delegates:
            // in C# allow you to combine multiple methods into a single delegate
            // and when you invoke the delegate, all the methods it points to are called
            // in the order they were added



            /* LogDel LogTextToScreenDel, LogTextToFileDel;

             LogTextToScreenDel = new LogDel(log.LogTextToScreen);
             LogTextToFileDel = new LogDel(log.LogTextToFile);

             LogDel multiLogDel = LogTextToFileDel + LogTextToScreenDel;*/

            LogDel MultiLogDel = log.LogTextToScreen;
            MultiLogDel += log.LogTextToFile;

            Console.WriteLine("Hi hello bolneka time nahi re Nam bata:");
            var name = Console.ReadLine();
            //MultiLogDel(name);

            LogText(MultiLogDel, name);

            Console.ReadKey();


        }

        static void LogTextToScreen(string text)
        {
            Console.WriteLine($"{DateTime.Now}: {text}");
        }

        static void LogTextToFile(string text)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
            {
                sw.WriteLine($"{DateTime.Now}: {text}");
            }
            
        }

        // Delegates : Inside the Method 

        static void LogText(LogDel logDel,string name)
        {
            logDel(name);
        }
    }

    // Delegates : Instance method references 
    public class Log
    {
        public void LogTextToScreen(string text)
        {
            Console.WriteLine($"{DateTime.Now}: {text}");
        }

        public void LogTextToFile(string text)
        {
           using(StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
            {
                sw.WriteLine($"{DateTime.Now}: {text}");
            }

        }
    }
}