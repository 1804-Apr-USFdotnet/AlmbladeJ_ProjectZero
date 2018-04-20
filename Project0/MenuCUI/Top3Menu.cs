using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuCUI
{
    class Top3Menu : IMenuDisplay, IMenuSelect
    {
        private Top3Menu() { }
        private static readonly Lazy<Top3Menu> lazy 
            = new Lazy<Top3Menu>(() => new Top3Menu());
        public static Top3Menu Instance { get { return lazy.Value; } }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine("Here are our top three rated restaurants! " +
                "Press escape to exit to the main menu.");
            Console.ReadKey();
        }

        public void Select(int ItemNumber)
        {
            throw new NotImplementedException();
        }
    }
}
