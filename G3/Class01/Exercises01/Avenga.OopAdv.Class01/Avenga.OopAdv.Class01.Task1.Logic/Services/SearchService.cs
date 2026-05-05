using Avenga.OopAdv.Class01.Task1.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenga.OopAdv.Class01.Task1.Logic.Services
{
    public class SearchService
    {
        public Dictionary<string, int> CountAppearancesInText(string text, List<string> searchStrings)
        {
            var searchResults = new Dictionary<string, int>();
            var textArr = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var str in searchStrings)
            {
                var result = Array.FindAll(textArr, _word => _word.Equals(str, StringComparison.OrdinalIgnoreCase));
                searchResults[str] = result.Length;
            }

            return searchResults;
        }

        public List<SearchResult> CountAppearancesInText2(string text, List<string> searchStrings)
        {
            var searchText = text
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            return searchStrings
                .Select(_str => new SearchResult()
                {
                    Name = _str,
                    Appearance = searchText.Count(_word => _word.Equals(_str, StringComparison.OrdinalIgnoreCase))
                })
                .ToList();
        }

        public void CountAppearancesInText3(string text, List<string> searchStrings)
        {
            var searchText = text.Split(" ");

            int counter = 0;
            foreach (var searchStr in searchStrings)
            {
                foreach (var word in searchText)
                {
                    if (word.Trim().ToLower() == searchStr.Trim().ToLower())
                    {
                        counter++;
                    }
                }
                Console.WriteLine(string.Format("Name: {0} is contained {1}", searchStr, counter));
                counter = 0;
            }
        }
    }
}
