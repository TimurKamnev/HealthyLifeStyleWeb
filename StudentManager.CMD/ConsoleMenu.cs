namespace StudentManager.CMD
{
    public class ConsoleMenu
    {
        List<string> menuItems;
        int counter = 0;
        public ConsoleMenu(List<string> menuItems)
        {
            this.menuItems = menuItems;
        }

        public int PrintMenu()
        {
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                for (int i = 0; i < menuItems.Count; i++)
                {
                    if (counter == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(menuItems[i]);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.WriteLine(menuItems[i]);
                    }

                }
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    counter--;
                    if (counter == -1) counter = menuItems.Count - 1;
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    counter++;
                    if (counter == menuItems.Count) counter = 0;
                }
            }
            while (key.Key != ConsoleKey.Enter);
            return counter;
        }
    }
}
