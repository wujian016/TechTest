using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;

namespace Wujian.Tech.Helper
{
    internal class Html
    {
        internal static void Test()
        {
            /*
            https://code.google.com/p/fizzler/
            more tests: https://code.google.com/p/fizzler/source/browse/#hg%2Fsrc%2FFizzler.Tests
             */

            // Load the document using HTMLAgilityPack as normal
            var html = new HtmlDocument();
            html.LoadHtml(@"
  <html>
      <head></head>
      <body>
        <div>
          <p class='content'>Fizzler</p>
          <p>CSS Selector Engine</p></div>
      </body>
  </html>");

            // Fizzler for HtmlAgilityPack is implemented as the 
            // QuerySelectorAll extension method on HtmlNode

            var document = html.DocumentNode;
           
            // yields: [<p class="content">Fizzler</p>]
            var content = document.QuerySelectorAll(".content");

            // yields: [<p class="content">Fizzler</p>,<p>CSS Selector Engine</p>]
            var p = document.QuerySelectorAll("p");

            // yields empty sequence
           var bodyp1 =  document.QuerySelectorAll("body>p");

            // yields [<p class="content">Fizzler</p>,<p>CSS Selector Engine</p>]
           var bodyp2 = document.QuerySelectorAll("body p");

            // yields [<p class="content">Fizzler</p>]
           var firstChild = document.QuerySelectorAll("p:first-child");
        }
    }

}
