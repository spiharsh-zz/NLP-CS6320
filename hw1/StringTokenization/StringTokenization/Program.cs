using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;

namespace StringTokenization
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Counting Words");
            DateTime start_at = DateTime.Now;
            TrieNode root = new TrieNode(null, '?');
            Dictionary<DataReader, Thread> readers = new Dictionary<DataReader, Thread>();
            if (args.Length ==0)
            {
                args = new string[]{ }
            }
        }
    }
}
