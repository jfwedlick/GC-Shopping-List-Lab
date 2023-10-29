using System.Reflection.Metadata.Ecma335;

namespace Shopping_List_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine($"Wecome to my store!");
                GoShopping();
            }
            catch
            {
                Exception ex = new Exception($"You definitely broke something.");
            }
            finally
            {
                Console.WriteLine($"Thank you for shopping with us!");
            }
        }

        static Dictionary<string, decimal> StoreMenu()
        {
            Dictionary<string, decimal> storeMenu = new Dictionary<string, decimal>()
            {
                {"BREAD", 1.00m},
                {"MILK", 1.50m},
                {"EGGS", 2.00m},
                {"BUTTER", 1.25m},
                {"CHEESE", 2.50m},
                {"PASTA", 3.00m},
                {"RICE", 0.50m},
                {"JUICE", 3.00m},
            };
            return storeMenu;
        }

        static void GoShopping()
        {
            Console.WriteLine();
            List<string> chosenItems = CheckMenu();
            CalculateTotal(chosenItems);
            RunAgain();
        }

        static List<string> CheckMenu()
        {
            Dictionary<string, decimal> storeMenu = StoreMenu();

            List<string> chosenItems = new List<string>();

            while (true)
            {
                Console.WriteLine("The following items are currently in stock:");

                foreach (string key in storeMenu.Keys)
                {
                    Console.WriteLine($"{key}");
                }

                Console.WriteLine();
                Console.Write("For which of these items would you like to know the price? ");
                string userInput = Console.ReadLine().Trim().ToUpper();
                Console.WriteLine();

                if (storeMenu.ContainsKey(userInput))
                {
                    Console.WriteLine($"The price of {userInput} is ${storeMenu[userInput]}.");
                    while (true)
                    {
                        Console.Write("Would you like to to add this item to your cart? [Y/N]: ");
                        string userYesorNo = Console.ReadLine().Trim();
                        if (userYesorNo.Equals("y", StringComparison.OrdinalIgnoreCase))
                        {
                            chosenItems.Add(userInput);
                            Console.WriteLine($"{userInput} was successfully added to your cart.");
                            PressAnyKeyToContinue();
                            break;
                        }
                        if (userYesorNo.Equals("n", StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine($"{userInput} was not added to your cart.");
                            PressAnyKeyToContinue();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid selection. Please select [Y/N].");
                            continue;
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Sorry, we don't have {userInput} in stock. Please select an item in stock.");
                    continue;
                }

                while (true)
                {
                    Console.Write("Would you like to add more items to your cart? Y/N: ");
                    string anotherItem = Console.ReadLine().Trim().ToUpper();
                    if (anotherItem == "Y")
                    {
                       break;
                    }
                    if (anotherItem == "N")
                    {
                        Console.WriteLine("We will now calculate your total.");
                        PressAnyKeyToContinue();
                        return chosenItems;
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection. Please select [Y/N].");
                        continue;
                    }
                }
            }
        }

        static void CalculateTotal(List<string> chosenItems)
        {
            Dictionary<string, decimal> storeMenu = StoreMenu();

            Console.WriteLine("Here is everything you ordered: ");
            foreach (string item in chosenItems)
            {
                Console.WriteLine($"{item}: ${storeMenu[item]}");
            }
            IEnumerable<decimal> total = chosenItems.Select(item => storeMenu[item]);
            decimal totalPrice = total.Sum();
            Console.WriteLine($"Your total for this order is {totalPrice}.");
        }

        static void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        static void RunAgain()
        {
            while (true)
            {
                Console.Write("Would you like to go shopping again? [Y/N]: ");
                string userYesorNo = Console.ReadLine().Trim();
                if (userYesorNo.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    GoShopping();
                    break;
                }
                if (userYesorNo.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid selection. Please select [Y/N].");
                    continue;
                }

            }
        }
    }
}