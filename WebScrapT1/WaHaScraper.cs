using HtmlAgilityPack;

namespace WebScrapT1
{
    internal class WaHaScraper
    {
        private string baseUrl = "nope";//"https://wahapedia.ru/wh40k9ed/factions/aeldari/biel-tan#Stratagems";
        private string selector = "nope";//"//*[@id='wrapper']/div[34]/div";

        public void GetStarategies()
        {
            if (!ReadFile())
            {
                Console.WriteLine("Error occured during variables reading, check if WaHaScrapVars.txt is in" +
                    " desired location, check spelling, check if baseUrl or selectorXpath are missing");
                return;
            }

            var web = new HtmlWeb();
            HtmlDocument document;
            try
            {
                document = web.Load(baseUrl);
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid url address");
                return;
            }
            HtmlNode tableStrategems;
            try
            {
                tableStrategems = document.DocumentNode.SelectSingleNode(selector);
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid selector");
                return;
            }

            var level1Element = tableStrategems.ChildNodes.First();
            foreach (var tableRecord in tableStrategems.ChildNodes)
            {
                WordSplitter ws = new WordSplitter(tableRecord);
                ws.Print();
                Console.WriteLine("");
            }

        }

        public bool ReadFile()
        {
            try
            {
                string fileName = @"WaHaScrapVars.txt";
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    string urlPattern = "baseUrl";
                    string selectorPattern = "selectorXpath";
                    bool urlFlag = false;
                    bool selectorFlag = false;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.StartsWith(urlPattern))
                        {
                            baseUrl = line.Substring(line.IndexOf('=') + 1);
                            urlFlag = true;
                        }
                        if (line.StartsWith(selectorPattern))
                        {
                            selector = line.Substring(line.IndexOf('=') + 1);
                            selectorFlag = true;
                        }
                    }
                    if (urlFlag && selectorFlag)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }
    }
}
