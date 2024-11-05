using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using NnGames.PoE2.OpenDb.Models;
using System.Text.Json;

namespace NnGames.PoE.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var l = CurrencyDataScraping();
            var a = JsonSerializer.Serialize(l);
            //var l = new List<Currency>();

            //var m = new Currency();
            //m.Name = "Armourer's Scrap";
            //m.StackSize = 40;
            //m.Description = "Improves the quality of an armour";
            //l.Add(m);

            //m = new Currency();
            //m.Name = "Chaos Orb";
            //m.StackSize = 20;
            //m.Description = "Removes a random modifier and augments a rare item with a new random modifier";
            //m.Note = "Right click this item then left click a rare item to applt it.";
            //l.Add(m);

            //Console.WriteLine(JsonSerializer.Serialize(l));

            //var json = EmbeddedResourceUtil.ReadResource("NnGames.PoE2.OpenDb.Jsons.currency.json", Assembly.GetAssembly(typeof(Currency)));
            //var l = JsonSerializer.Deserialize<List<Currency>>(json);

            Console.WriteLine(l);
        }

        static List<Currency> CurrencyDataScraping()
        {
            var web = new HtmlWeb();
            var document = web.Load("https://poe2db.tw/us/Currency");
            var htmlElements = document.DocumentNode.QuerySelectorAll("div.itemBoxContent");

            var l = new List<Currency>();
            foreach (var productHTMLElement in htmlElements)
            {
                var name = HtmlEntity.DeEntitize(productHTMLElement.QuerySelector("span.lc").InnerText?.Trim());
                var stackSize = HtmlEntity.DeEntitize(productHTMLElement.QuerySelector("span.colourDefault").InnerText?.Trim().Replace("1/", string.Empty));
                var description = HtmlEntity.DeEntitize((productHTMLElement.QuerySelector("div.explicitMod")?.InnerText ?? productHTMLElement.QuerySelector("div.implicitMod")?.InnerText)?.Trim());
                var note = HtmlEntity.DeEntitize(productHTMLElement.QuerySelector("div.fst-italic")?.InnerText?.Trim());

                l.Add(new Currency(name, short.Parse(stackSize), description, note));
            }

            return l;
        }
    }
}

//var name = HtmlEntity.DeEntitize(productHTMLElement.QuerySelector("span.lc").Attributes["href"].Value);
//var note = HtmlEntity.DeEntitize(productHTMLElement.QuerySelector(".price").InnerText);