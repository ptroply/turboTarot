using System;
using System.Collections.Generic;
using System.Text;
using TurboTarot.Class;

namespace TurboTarot.Service
{
    public class ConsoleService
    {
        private string[] menuArray { get; } = { "Reveal [Birth] Cards", "Draw [Daily] Card", "View [Spreads]", "[Quit]" };
        private string DrawBirthCards { get; } = "birth";
        private string DrawDailyCard { get; } = "daily";
        private string DrawSpreads { get; } = "spread";
        private string SaveQuit { get; } = "quit";
        private bool IsQuit { get; set; }
        public ConsoleService(TableService table)
        {
            WriteToScreen("TurboTarot v0.0.2 11/xx/2021");
            WriteToScreen("Prototype by Matt Pietropaoli");
            WriteToScreen("");
            WriteToScreen("for entertainment purposes only");
            string userInput = "";
            while(!IsQuit)
            {
                WriteToScreen("");
                GetStringInput("Press enter to continue...");
                ClearScreen();
                WriteToScreen("---------------------");
                WriteToScreen("Welcome to TurboTarot");
                WriteToScreen("---------------------");
                WriteMenu(menuArray);
                WriteToScreen("---------------------");
                userInput = GetStringInput("Choose an option: ").ToLower();
                if (userInput.StartsWith(DrawBirthCards))
                {
                    string birthday = GetStringInput("Enter your birthday: ");
                    for (int i = birthday.Length - 1; i > 0; i--)
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
                else if(userInput.StartsWith(DrawDailyCard))
                {
                    ClearScreen();
                    WriteToScreen("---------------");
                    WriteToScreen("Your Daily Card");
                    WriteToScreen("---------------");
                    WriteToScreen($"[] {table.DrawDailyCard().Name}");
                }
                else if(userInput.StartsWith(DrawSpreads))
                {
                    string[] spreadNames = table.getSpreads();
                    string spreadSelect = "";
                    bool isQuitSpread = false;
                    while(!isQuitSpread)
                    {
                        ClearScreen();
                        WriteToScreen("-------------");
                        WriteToScreen("TAROT SPREADS");
                        WriteToScreen("-------------");
                        WriteMenu(spreadNames);
                        WriteToScreen("-------------");

                        spreadSelect = GetStringInput("Choose an option or [cancel] ").ToLower();
                        for(int i = 0; i < spreadNames.Length; i++)
                        {
                            if (spreadSelect.StartsWith(spreadNames[i].Substring(0, 3).ToLower()))
                            {
                                try
                                {
                                    ClearScreen();
                                    Spread selectedSpread = table.selectSpread(i);
                                    WriteToScreen(selectedSpread.Name);
                                    WriteToScreen("");
                                    string cardStr = "";
                                    for (int j = 0; j < selectedSpread.NumberOfCards; j++)
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
                                    WriteToScreen("");
                                    WriteToScreen(selectedSpread.Description);
                                    WriteToScreen("");

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
                                    GetStringInput("Come back again tomorrow for a new deck []x");
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
                }
                else if(userInput.StartsWith(SaveQuit))
                {
                    IsQuit = true;
                    // quit
                }
                else
                {
                    WriteToScreen("Invalid entry.");
                }
            }
            WriteToScreen("Thanks for playing!");
        }

        // progressive karma system

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
