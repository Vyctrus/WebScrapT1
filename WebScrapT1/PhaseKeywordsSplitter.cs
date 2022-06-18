using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace WebScrapT1
{
    internal class PhaseKeywordsSplitter
    {
        public string Text { get; private set; } = "Error";
        public string Phase { get; private set; } = "Error";

        public List<string> Keywords { get; private set; } = new List<string>();

        public PhaseKeywordsSplitter(HtmlNode element)
        {
            string input = element.InnerText;
            Text = input;
            string[] words = input.Split(' ', ',', '.');
            Checker(words);
        }

        private void Checker(string[] words)
        {
            Boolean needPhase = true;
            for (int i = 0; i < words.Length; i++)
            {
                if (needPhase)
                {
                    if (words[i] == "phase")
                    {
                        Phase = words[i - 1];
                        needPhase = false;
                    }
                }
                if (words[i].ToUpper() == words[i] && words[i] != "")
                {
                    Regex reg = new Regex(@"\w*[A-Z]\w*[A-Z]\w*");
                    if (reg.IsMatch(words[i]))
                    {
                        Keywords.Add(words[i]);
                    }
                }
            }
            if (needPhase)
            {
                Phase = "Error";
            }
        }
    }
}