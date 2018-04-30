using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace MenuCUI
{
    public class MainMenu : IMenuDisplay
    {
        Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private MainMenu() { }
        private static readonly Lazy<MainMenu> lazy
            = new Lazy<MainMenu>(() => new MainMenu());
        public static MainMenu Instance { get { return lazy.Value; } }

        public void Display()
        {
            try
            {
                bool Stay = true;
                string retry = "";
                do
                {
                    Console.Clear();
                    Console.WriteLine("Welcome to Restaurant Reviews and Raves!");
                    Console.WriteLine("Select one option below.\n" +
                        "1. See top 3 restaurants.\n" +
                        "2. Search for a restaurant.\n" +
                        "3. Display all restaurants.\n" +
                        "Press escape to exit." + retry);
                    retry = "";
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            Top3Menu.Instance.Display();
                            retry = "";
                            break;
                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:
                            SearchMenu.Instance.Display();
                            retry = "";
                            break;
                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:
                            SearchMenu.Instance.Display();
                            retry = "";
                            break;
                        case ConsoleKey.Escape:
                            Console.WriteLine("\n Exiting...");
                            Stay = false;
                            break;
                        default:
                            retry = " Please try again.";
                            break;
                    }
                } while (Stay);
            }
            catch (IndexOutOfRangeException iore)
            {
                logger.Error(iore, iore.Message);
            }
            catch (ArgumentException ae)
            {

                logger.Error(ae, ae.Message);
            }
            catch (Exception e)
            {
                logger.Error(e, e.Message);
            }
        }
    }
}
