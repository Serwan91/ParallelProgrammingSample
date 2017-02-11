using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ParallelProgrammingSample
{
    class MutexDemo
    {

        static string[] Names = { "Pam", "Ben", "Parag", "Ananth" };
        static string Name = "";
        
        
        public static void PrintName()
        {
            Console.WriteLine("Thread Id {0}, Waiting for resource", Thread.CurrentThread.ManagedThreadId);
            {
                
                Name = Names[Utility.Next(0, Names.Length - 1)].ToString();
                Console.WriteLine("Thread Id {0}, Acquired Resource \n Reading : {1}", Thread.CurrentThread.ManagedThreadId, Name);
                Console.WriteLine("Thread Id {0}, Sleeping for : 1 second", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(1000);
                Console.WriteLine("Thread Id {0}, Writing : {1} and exiting resource \n", Thread.CurrentThread.ManagedThreadId, Name);
            }
        }


        public static void Start()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread T = new Thread(PrintName);
                T.Start();
            }
        }

    }
}
