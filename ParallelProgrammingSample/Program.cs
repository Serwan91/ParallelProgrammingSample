using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgrammingSample
{
    class Program
    {
        static int Counter = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("Total Available Processor on this Machine, {0}", Environment.ProcessorCount);
            /* Method ThreadExample creates multilple threads */
            //ThreadExample();

            /* Method ThreadExample creates multilple background threads */
            //BackGroundThreadExample();

            /* Method SynchronizationIssue shows to handle sychronization on shared resources*/
            //SynchronizationIssue();

            /* Lock/Monitor Demo : Lock synchronizes threads access to shared resource within Process*/
            LockDemo.Start();
            Console.WriteLine("Main thread-Id {0} , is existing...", Thread.CurrentThread.ManagedThreadId);
        }

        private static void SynchronizationIssue()
        {
            for (int i = 0; i < 3; i++)
            {
                Thread th = new Thread(SharedResource);
                th.Start();
            }
        }

        private static void SharedResource()
        {
            while (true)
            {
                Counter += 1; // Counter is shared resource but it is already an atomic thing
                Console.WriteLine(" Thread with {0} counting at {1}", Thread.CurrentThread.ManagedThreadId, Counter);
            }
        }

        /// <summary>
        /// Creates background threads on each processor of the machine. 
        /// These threads gets abruptly terminated when Main threads completes
        /// </summary>
        private static void BackGroundThreadExample()
        {
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                // Creating threads on all process to use maximum CPU.
                // Ideally, exausting all CPU processor is not adviceable.
                Thread th = new Thread(printHello);
                th.IsBackground = true;
                th.Start();

            }
        }
        /// <summary>
        /// Creates threads on each processor of the machine. 
        /// This threads keeps executing though the main threads gets complete
        /// </summary>
        private static void ThreadExample()
        {
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                // Creating threads on all process to use maximum CPU.
                // Ideally, exausting all CPU processor is not adviceable.
                Thread th = new Thread(printHello);
                th.Start();

            }
        }

        public static void printHello()
        {
            while(true)
            Console.WriteLine("Hello from Thread Id : {0}",Thread.CurrentThread.ManagedThreadId);
        }

    }
}
