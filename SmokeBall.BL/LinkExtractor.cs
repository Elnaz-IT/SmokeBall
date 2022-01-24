using SmokeBall.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SmokeBall.BL
{
    internal class LinkExtractor
    {
        public static List<string> ExtractLinks(string html)
        {
            List<string> list = new List<string>();

            Regex regex = new Regex(@"<a href=""/url[\s\S]*?</a>", RegexOptions.Singleline | RegexOptions.CultureInvariant);
            if (regex.IsMatch(html))
            {
                foreach (Match match in regex.Matches(html))
                {
                    list.Add(match.Groups[0].Value);
                }
            }

            return list;
        }

        public static string ExtractSpecialLink(string html)
        {
            try
            {
                var nextKWLocation = html.IndexOf("aria-label=\"Next page\"");
                if (nextKWLocation > 0)
                {
                    var nextATagLocation = html.Substring(0, nextKWLocation).LastIndexOf("<a");
                    var nextATag = html.Substring(nextATagLocation, nextKWLocation - nextATagLocation);
                    var urlStart = nextATag.Substring(nextATag.IndexOf("/search?q="), nextATag.Length - nextATag.IndexOf("/search?q="));

                    var searchUrl = ConfigurationSettings.GoogleBaseURL + urlStart.Substring(0, urlStart.IndexOf("\"")).Replace("amp;", "");
                    return searchUrl;
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                //TODO Logger
                //Logger.log(ex);
                throw;
            }

        }
    }
}
