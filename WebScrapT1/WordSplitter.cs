using HtmlAgilityPack;

namespace WebScrapT1
{
    internal class WordSplitter
    {
        string Name { get; }
        string Cost { get; }
        string Faction { get; }
        string Category { get; }
        string Whose { get; }
        string Phase { get; }
        string Text { get; }
        List<string> Keywords { get; }

        public WordSplitter(HtmlNode level1Element)
        {
            List<HtmlNode> level2Elements = new List<HtmlNode>();
            foreach (var element in level1Element.ChildNodes)
            {
                level2Elements.Add(element);
            }
            Keywords = new List<string>();
            NameCostSplitter ncs = new NameCostSplitter(level2Elements[0]);
            this.Name = ncs.Name;
            this.Cost = ncs.Cost;
            FactionCategorySplitter fcs = new FactionCategorySplitter(level2Elements[1]);
            this.Faction = fcs.Faction;
            this.Category = fcs.Category;

            this.Whose = "Marka Magdziaka";
            //level2Elemnets[2] is unimportant description
            PhaseKeywordsSplitter pks = new PhaseKeywordsSplitter(level2Elements[3]);
            this.Phase = pks.Phase;
            this.Text = pks.Text;
            this.Keywords = pks.Keywords;
        }

        public void Print()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Cost: {Cost}");
            Console.WriteLine($"Faction: {Faction}");
            Console.WriteLine($"Category: {Category}");
            Console.WriteLine($"Whose: {Whose}");
            Console.WriteLine($"Phase: {Phase}");
            Console.WriteLine($"Text: {Text}");
            int i = 0;
            foreach (string word in Keywords)
            {
                Console.Write(word + $" {i} ");
                i++;
            }
            Console.WriteLine("");
        }
    }
}
