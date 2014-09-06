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
                args = new string[] { "SherlockHolmes.txt" };
            }
            if (args.Length >0)
            {
                foreach (string path in args)
                {
                    DataReader new_reader = new DataReader(path, ref root);
                    Thread new_thread = new Thread(new_reader.ThreadRun);
                    readers.Add(new_reader, new_thread);
                    new_thread.Start();
                }
            }

            foreach (Thread t in readers.Values) t.Join();

            DateTime stop_at = DateTime.Now;
            Console.WriteLine("Input data processed in {0} secs", new TimeSpan(stop_at.Ticks - start_at.Ticks).TotalSeconds);
            Console.WriteLine("Most Commonly found words:");

            List<TrieNode> top10_nodes = new List<TrieNode> { root, root, root, root, root, root, root, root, root, root, root, root, root, root, root, root, root, root, root, root, root, root, root, root, root, root, root, root, root, root };
            int distinc_word_count = 0;
            int total_word_count = 0;
            int[] cnt_occurence = new int[3];
            root.GetTopCounts(ref top10_nodes, ref distinc_word_count, ref total_word_count, ref cnt_occurence);
            top10_nodes.Reverse();
            foreach (TrieNode node in top10_nodes)
            {
                Console.WriteLine("{0} - {1} times", node.ToString(), node.m_word_count);
            }

            Console.WriteLine();
            Console.WriteLine("{0} words counted", total_word_count);
            Console.WriteLine("{0} distinct words found", distinc_word_count);
            Console.WriteLine();
            Console.WriteLine("done.");
            Console.ReadLine();
        }
    }
}
