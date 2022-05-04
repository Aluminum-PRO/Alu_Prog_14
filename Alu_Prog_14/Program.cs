using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Alu_Prog_14
{
    public class Inventory
    {
        public bool empty;
        public int count;
        public string name;
    }

    class Program
    {
        #region Variables
        static public string Main_Patch, Ver, Selected_Item_Text;
        static public string Version_Info_Text = "\n Управление игрой происходит цифрами (\"1\" или \"NumPud1\" или \"F1\")\n \"Escape\" - Главное меню\n\n", Available_Actions = " Доступные действия:", Waiting_for_a_Response = " Ожидание ответа: ", Press_Enter = " Нажмите любую клавишу для продолжения...\n";
        static public int Selected_Item_Number = 0, Current_Room_Number = 1;
        static public bool Game_is_Started = false, is_Menu = true;
        static public List<Inventory> Item = new List<Inventory>();

        #endregion

        static void Game_Settings()
        {
            Item.Add(new Inventory() { empty = true, count = 1, name = "шляпа" });
            Item.Add(new Inventory() { empty = true, count = 1, name = "камень" });
            Item.Add(new Inventory() { empty = true, count = 1, name = "меч" });

            List<Inventory> inventory = new List<Inventory>();

            for (int i = 0; i <= 10; i++)
            {
                inventory.Add(new Inventory());
            }

            inventory.Insert(0, Item[0]);

            foreach (Inventory i in inventory)
            {
                //Console.WriteLine(i.empty);
                //Console.WriteLine(i.count);
                //Console.WriteLine(i.name);
            }
        }

        static void Main(string[] args)
        {
            Load();
            Game_Settings();
            if (args.Length == 0)
            { }

            while (true)
            {
                if (is_Menu) Main_Menu();
                else if (!is_Menu) Game();
            }
        }

        static void Game()
        {
            if (is_Menu) Main_Menu();
            else if (!is_Menu)
            {
                if (Current_Room_Number == 1) Rooms_Class.Started_Room();
                else if (Current_Room_Number == 2) Rooms_Class.Hallway_Room();
                else if (Current_Room_Number == 3) Rooms_Class.Tavern_Room();
            }
        }

        static void Load()
        {
            Main_Patch = Assembly.GetExecutingAssembly().Location;
            FileVersionInfo myFileVersionInfo_App = FileVersionInfo.GetVersionInfo(Main_Patch);
            Ver = myFileVersionInfo_App.FileVersion;
            if (Convert.ToInt32(Ver.Split('.')[0]) != 0)
                Ver += ".Release";
            else if (Convert.ToInt32(Ver.Split('.')[1]) != 0)
                Ver += ".Beta";
            else if (Convert.ToInt32(Ver.Split('.')[2]) != 0)
                Ver += ".Alpha";
            else if (Convert.ToInt32(Ver.Split('.')[3]) != 0)
                Ver += ".Pre-Alpha";
            Ver = " Ver." + Ver;
            Console.Write(Ver + Version_Info_Text);
        }

        static void Main_Menu()
        {
            Clear_Console();
            if (!Game_is_Started)
            {
                Console.Write(" Главное меню:\n (1)Начать игру\n (2)Выйти из игры\n{0}", Waiting_for_a_Response);
                Selected_Item_Number = Select_an_Item(2);
                if (Selected_Item_Number == 1) { is_Menu = false; Game_is_Started = true; }
                else if (Selected_Item_Number == 2) Environment.Exit(0);
            }
            else if (Game_is_Started)
            {
                Console.Write(" Главное меню:\n (1)Продолжить игру\n (2)Начать новую игру\n (3)Выйти из игры\n{0}", Waiting_for_a_Response);
                Selected_Item_Number = Select_an_Item(3);
                if (Selected_Item_Number == 1) is_Menu = false;
                else if (Selected_Item_Number == 2) { Reset(); is_Menu = false; Game_is_Started = true; }
                else if (Selected_Item_Number == 3) Environment.Exit(0);
            }
        }

        static void Reset()
        {
            Selected_Item_Number = 0; Current_Room_Number = 1;
            Game_is_Started = false; is_Menu = true;
        }

        static public int Select_an_Item(int Count_Item)
        {
            int Selected_Item;
            Selected_Item_Text = Console.ReadKey().Key.ToString();
            if (Selected_Item_Text == "Escape" && !is_Menu)
            { is_Menu = true; return -1; }
            int.TryParse(String.Join("", Selected_Item_Text.Where(c => char.IsDigit(c))), out Selected_Item);
            bool is_Converted = Selected_Item != 0;
            bool is_In_Range = Selected_Item >= 1 && Selected_Item <= Count_Item;

            while (!is_Converted || !is_In_Range)
            {
                Console.Write("\n Неизвестная команда: \"{0}\"\n{1}", Selected_Item_Text, Waiting_for_a_Response);
                Selected_Item_Text = Console.ReadKey().Key.ToString();
                int.TryParse(String.Join("", Selected_Item_Text.Where(c => char.IsDigit(c))), out Selected_Item);
                Console.Write(Selected_Item.ToString());
                is_Converted = Selected_Item != 0;
                is_In_Range = Selected_Item >= 1 && Selected_Item <= Count_Item;
            }
            return Selected_Item;
        }

        static public void Clear_Console()
        {
            Console.Clear();
            Console.Write(Ver + Version_Info_Text);
        }
    }
}
