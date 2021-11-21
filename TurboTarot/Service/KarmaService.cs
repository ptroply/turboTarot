using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TurboTarot.Class;

namespace TurboTarot.Service
{
    class KarmaService
    {
        public int Value { get; set; }
        private Dictionary<string, int> Record { get; set; }
        private string FilePath { get; set; }
        public KarmaService()
        {
            string directory = Environment.CurrentDirectory;
            string fileName = "score.txt";
            FilePath = Path.Combine(directory, fileName);
            if(!File.Exists(fileName))
            {
                File.Create(fileName);
            }
            try
            {
                using(StreamReader reader = new StreamReader(FilePath))
                {
                    while(!reader.EndOfStream)
                    { 
                        int score = reader.Read();
                        string date = reader.ReadLine();
                        Record[date] = score;
                        Value += score;
                    }
                }
            } catch { throw; }
        }
        public void SaveFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(FilePath, true))
                {
                    foreach(string date in Record.Keys)
                    {
                        writer.WriteLine($"{Record[date]}{date}");
                    }
                }
            } catch { throw; }
        }
        //if file exist
        //else create new file
        //check and store value int -0+
    }
}
