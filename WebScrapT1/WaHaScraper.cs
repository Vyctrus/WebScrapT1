using HtmlAgilityPack;

namespace WebScrapT1
{
    internal class WaHaScraper
    {
        private const string BaseUrl = "https://wahapedia.ru/wh40k9ed/factions/aeldari/biel-tan#Stratagems";

        public void GetStarategies()
        {
            var web = new HtmlWeb();
            var document = web.Load(BaseUrl);
            //var selector = "//*[@id='wrapper']/div[31]/div";
            var selector = "//*[@id='wrapper']/div[34]/div";
            var tableStrategems = document.DocumentNode.SelectSingleNode(selector);

            var level1Element = tableStrategems.ChildNodes.First();


            //WordSplitter ws = new WordSplitter(level1Element);
            //ws.Print();
            foreach (var tableRecord in tableStrategems.ChildNodes)
            {
                WordSplitter ws = new WordSplitter(tableRecord);
                ws.Print();
                Console.WriteLine("");
            }
        }
    }
}
