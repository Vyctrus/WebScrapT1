using HtmlAgilityPack;

namespace WebScrapT1
{
    internal class NameCostSplitter
    {
        public string Name { get; }
        public string Cost { get; }
        public NameCostSplitter(HtmlNode element)
        {
            string input = element.InnerText;
            var firstDigit = input.FirstOrDefault(c => char.IsDigit(c));
            if (firstDigit != default(char))
            {
                Name = input.Substring(0, input.IndexOf(firstDigit));
                Cost = input.Substring(input.IndexOf(firstDigit));
            }
            else
            {
                Name = "Error in WordSplitter/NameCostSplitter";
                Cost = "Error in WordSplitter/NameCostSplitter";
            }

        }
    }
}
