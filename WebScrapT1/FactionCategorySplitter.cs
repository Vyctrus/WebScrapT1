using HtmlAgilityPack;

namespace WebScrapT1
{
    internal class FactionCategorySplitter
    {
        public string Faction { get; }
        public string Category { get; }
        public FactionCategorySplitter(HtmlNode element)
        {
            string input = element.InnerText;
            //"Aeldari – Battle Tactic Stratagem"
            Faction = input.Substring(0, input.IndexOf(" – "));
            var temp = input.Substring((input.IndexOf(" – ") + 3));
            Category = temp.Replace(" Stratagem", "");
        }
    }
}
