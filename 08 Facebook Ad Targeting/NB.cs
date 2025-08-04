using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _08_Facebook_Ad_Targeting
{
    class NB
    {
        int total;
        int totalHam = 0;
        int totalSpam = 0;
        Dictionary<string, int> hamWords = new Dictionary<string, int>();
        Dictionary<string, int> spamWords = new Dictionary<string, int>();

        public NB(string file)
        {
            GetData(file);
        }

        private void GetData(string file)
        {
            foreach (string line in File.ReadLines(file))
            {
                Regex regex = new Regex("[^a-z ]");
                string[] words = regex.Split(line.ToLower());

                if (words[0] == "ham")
                {
                    for (int i = 1; i < words.Length; i++)
                    {
                        if (!hamWords.ContainsKey(words[i])) hamWords[words[i]] = 0;
                        hamWords[words[i]]++;
                    }
                    totalHam++;
                }
                else
                {
                    for (int i = 1; i < words.Length; i++)
                    {
                        if (!spamWords.ContainsKey(words[i])) spamWords[words[i]] = 0;
                        spamWords[words[i]]++;
                    }
                    totalSpam++;
                }
            }
        }

        public double Predict(string sentence) //prediction of spam
        {
            Regex regex = new Regex("[^a-z ]");
            string[] words = regex.Split(sentence.ToLower());

            double upper = 1;
            double lower = 1;
            double prediction = 1;

            foreach ( var word in words)
            {
                if (spamWords.ContainsKey(word)) upper = (double)spamWords[word] / spamWord.Count();
                if (hamWords.ContainsKey(word)) lower = (double)hamWords[word] / totalHam;                
            }

            upper = totalSpam / total;
            lower = totalSpam / total;

            return prediction;
        }

        public bool IsSpam(string sentence)
        {
            if (Predict(sentence) > 1) return true;
            return false;
        }
    }
}
