using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuCUI
{
    class SearchMenu : IMenuDisplay, IMenuSelect
    {
        private SearchMenu() { }
        private static readonly Lazy<SearchMenu> lazy 
            = new Lazy<SearchMenu>(() => new SearchMenu());
        public static SearchMenu Instance { get { return lazy.Value; } }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine("Enter your search term here.");
            Console.ReadLine();
        }

        public void Select(int ItemNumber)
        {
            throw new NotImplementedException();
        }
    }
}
