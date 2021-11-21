using System;
using System.Collections.Generic;
using System.Text;
using TurboTarot.Class;

namespace TurboTarot.Service
{
    public class ConsoleService
    {
        public ConsoleService(TableService table)
        {
            WriteToScreen("TurboTarot v0.0.1 11/14/2021");
            WriteToScreen("Prototype by Matt Pietropaoli");
            WriteToScreen("");
            WriteToScreen("for entertainment purposes only");
            int userInput = -1;
            while(userInput != 0)
            {
                WriteToScreen("");
                GetStringInput("Press enter to continue...");
                ClearScreen();
                WriteToScreen("---------------------");
                WriteToScreen("Welcome to TurboTarot");
                WriteToScreen("---------------------");
                string[] menuArray = { "Reveal Birth Cards", "Daily Card", "Tarot Spreads", "Quit" };
                WriteMenu(menuArray);
                WriteToScreen("---------------------");
                userInput = GetIntInput("Choose an option: ");
                if(userInput == 1)
                {
                    string birthday = GetStringInput("Enter your birthday (YYYY/MM/DD): ");
                    for(int i = birthday.Length - 1; i > 0; i--)
                    {
                        char c = birthday[i];
                        if (c == '/' || c == '-')
                        {
                            birthday = birthday.Replace(c.ToString(), "");
                        }
                    }
                    try
                    {
                        int.Parse(birthday);
                        ClearScreen();
                        WriteToScreen("----------------");
                        WriteToScreen("Your Birth Cards");
                        WriteToScreen("----------------");
                        foreach (Card card in table.GetBirthCards(birthday))
                        {
                            if (card != null)
                            {
                                WriteToScreen($"[] {card.Name}");
                            }
                        }
                    }
                    catch (Exception)
                    {
                        WriteToScreen("Invalid entry.");
                    }
                }
                else if(userInput == 2)
                {
                    ClearScreen();
                    WriteToScreen("---------------");
                    WriteToScreen("Your Daily Card");
                    WriteToScreen("---------------");
                    WriteToScreen($"[] {table.DrawDailyCard().Name}");
                }
                else if(userInput == 3)
                {
                    int spreadSelect = -1;
                    while(spreadSelect != 0)
                    {
                        ClearScreen();
                        WriteToScreen("-------------");
                        WriteToScreen("TAROT SPREADS");
                        WriteToScreen("-------------");
                        WriteMenu(table.getSpreads());
                        WriteToScreen("-------------");
                        spreadSelect = GetIntInput("Choose an option (0 to cancel): ");
                        if(spreadSelect != 0)
                        {
                            try
                            {
                                ClearScreen();
                                Spread selectedSpread = table.selectSpread(spreadSelect - 1);
                                WriteToScreen("");
                                WriteToScreen(selectedSpread.Name);
                                WriteToScreen("");
                                string cardStr = "";
                                for (int i = 0; i < selectedSpread.NumberOfCards; i++)
                                {
                                    cardStr += "[] ";
                                }
                                WriteToScreen(cardStr);
                                WriteToScreen("");
                                WriteToScreen(selectedSpread.Description);
                                WriteToScreen("");
                                WriteToScreen("Take a moment to think of the subject of your reading.");
                                GetStringInput("Press enter to continue...");
                                ClearScreen();
                                Card[] spread = table.DrawHand(selectedSpread.NumberOfCards);
                                foreach (Card card in spread)
                                {
                                    WriteToScreen($"[] {card.Name}");
                                }
                                WriteToScreen("");
                                GetStringInput("Press enter to continue...");
                            }
                            catch (ArgumentException)
                            {
                                WriteToScreen("Not enough cards left.");
                                GetStringInput("Press enter to continue...");
                                break;
                            }
                            catch (Exception)
                            {
                                WriteToScreen("Invalid entry.");
                                GetStringInput("Press enter to continue...");
                            }
                        }
                    }
                }
                else if(userInput == menuArray.Length)
                {
                    userInput = 0;
                    // quit
                }
                else
                {
                    WriteToScreen("Invalid entry.");
                }
            }
            WriteToScreen("Thanks for playing!");
        }
        public void WriteMenu(string[] menuOptions)
        {
            if (menuOptions != null)
            {
                for (int i = 0; i < menuOptions.Length; i++)
                {
                    string output = $"{i + 1}. {menuOptions[i]}";
                    WriteToScreen(output);
                }
            }
        }
        public string GetStringInput(string prompt)
        {
            Console.Write(prompt);
            string entry = Console.ReadLine();
            return entry;
        }
        public int GetIntInput(string prompt)
        {
            Console.Write(prompt);
            string entry = Console.ReadLine();
            try
            {
                int entryInt = int.Parse(entry);
                return entryInt;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public void WriteToScreen(string output)
        {
            Console.WriteLine(output);
        }
        public void ClearScreen()
        {
            Console.Clear();
        }
    }
}
