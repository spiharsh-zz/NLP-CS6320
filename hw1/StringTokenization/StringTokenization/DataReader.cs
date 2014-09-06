using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringTokenization
{
    public class DataReader
    {
        static int LOOP_COUNT = 1;
        private TrieNode m_root;
        private string m_path;

        public DataReader(string path,ref TrieNode root)
        {
            m_root = root;
            m_path = path;
        }
        public void ThreadRun()
        {
            for (int i = 0; i < LOOP_COUNT; i++)
            {
                using (FileStream fstream = new FileStream(m_path, FileMode.Open,FileAccess.Read))
                {
                    using (StreamReader sreader = new StreamReader(fstream))
                    {
                        string line;
                        while ((line = sreader.ReadLine())!=null)
                        {
                            char[] delims = { ' ' };
                            string[] chunks = line.Split(delims);
                            foreach (string chunk in chunks)
                            {
                                m_root.AddWord(chunk.Trim());
                            }
                        }
                    }
                }
            }
        }
    }
}
