using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Alu_Prog_14
{
    public static class Methods_Class
    {
        public static void Game_Settings()
        {
            Variables_Class.Item.Add(new Variables_Class.Inventory() { empty = true, count = 1, name = "Медальон" });

            for (int i = 0; i <= 3; i++)
            {
                Variables_Class.inventory.Add(new Variables_Class.Inventory());
            }
            for (int i = 0; i <= 9; i++)
            {
                Variables_Class.chest.Add(new Variables_Class.Inventory());
            }
        }

        public static void Game()
        {
            if (Variables_Class.is_Menu) Main_Menu();
            else if (!Variables_Class.is_Menu)
            {
                if (Variables_Class.Current_Room_Number == 1) Rooms_Class.Started_Room();
                else if (Variables_Class.Current_Room_Number == 2) Rooms_Class.Hallway_Room();
                else if (Variables_Class.Current_Room_Number == 3) Rooms_Class.Tavern_Room();
            }
        }

        public static void Load()
        {
            Variables_Class.Main_Patch = Assembly.GetExecutingAssembly().Location;
            FileVersionInfo myFileVersionInfo_App = FileVersionInfo.GetVersionInfo(Variables_Class.Main_Patch);
            Variables_Class.Ver = myFileVersionInfo_App.FileVersion;
            if (Convert.ToInt32(Variables_Class.Ver.Split('.')[0]) != 0)
                Variables_Class.Ver += ".Release";
            else if (Convert.ToInt32(Variables_Class.Ver.Split('.')[1]) != 0)
                Variables_Class.Ver += ".Beta";
            else if (Convert.ToInt32(Variables_Class.Ver.Split('.')[2]) != 0)
                Variables_Class.Ver += ".Alpha";
            else if (Convert.ToInt32(Variables_Class.Ver.Split('.')[3]) != 0)
                Variables_Class.Ver += ".Pre-Alpha";
            Variables_Class.Ver = " Zuoya Ver." + Variables_Class.Ver;
            Console.Write(Variables_Class.Ver + Variables_Class.Version_Info_Text);
        }

        public static void Main_Menu()
        {
            Clear_Console();
            if (!Variables_Class.Game_is_Started)
            {
                Console.Write(" Главное меню:\n (1)Начать игру\n (2)Выйти из игры\n{0}", Variables_Class.Waiting_for_a_Response);
                Variables_Class.Selected_Item_Number = Select_an_Item(2);
                if (Variables_Class.Selected_Item_Number == 1) { Variables_Class.is_Menu = false; Variables_Class.Game_is_Started = true; }
                else if (Variables_Class.Selected_Item_Number == 2) Environment.Exit(0);
            }
            else if (Variables_Class.Game_is_Started)
            {
                Console.Write(" Главное меню:\n (1)Продолжить игру\n (2)Начать новую игру\n (3)Выйти из игры\n{0}", Variables_Class.Waiting_for_a_Response);
                Variables_Class.Selected_Item_Number = Select_an_Item(3);
                if (Variables_Class.Selected_Item_Number == 1) Variables_Class.is_Menu = false;
                else if (Variables_Class.Selected_Item_Number == 2) { Reset(); Variables_Class.is_Menu = false; Variables_Class.Game_is_Started = true; }
                else if (Variables_Class.Selected_Item_Number == 3) Environment.Exit(0);
            }
            if (Variables_Class.Selected_Item_Number == -1)
            {
                Clear_Console();
                Console.Write("\n В главном меню нельзя ещё раз открыть меню\n{0}", Variables_Class.Press_Enter);
                Console.ReadKey();
            }
            else if (Variables_Class.Selected_Item_Number == -2)
            {
                Clear_Console();
                Console.Write("\n В главном меню нельзя открыть инвентарь\n{0}", Variables_Class.Press_Enter);
                Console.ReadKey();
            }
        }

        public static void Show_Inventory()
        {
            Clear_Console();
            Console.Write("\n Ваш инвентарь:\n {0} Монет\n", Variables_Class.Money);
            foreach (Variables_Class.Inventory i in Variables_Class.inventory)
            {
                if (!i.empty) Console.Write(" В этом слоту пусто\n");
                else if (i.empty) Console.Write(" {0} {1}\n", i.count, i.name);
            }
            Console.Write("{0}", Variables_Class.Press_Enter);
            Console.ReadKey();
        }

        public static void Show_Chest()
        {
            Clear_Console();
            Console.Write("\n Ваши предметы в шкафу:\n");
            foreach (Variables_Class.Inventory i in Variables_Class.chest)
            {
                if (!i.empty) Console.Write(" В этом слоту пусто\n");
                else if (i.empty) Console.Write(" {0} {1}\n", i.count, i.name);
            }
            Console.Write(" {0}\n (1)Положить предметы в шкаф\n (2)Взять предметы из шкафа\n (3)Закрыть шкаф\n{1}", Variables_Class.Available_Actions, Variables_Class.Waiting_for_a_Response);
            Variables_Class.Selected_Item_Number = Select_an_Item(3);

            if (Variables_Class.Selected_Item_Number == 1)
            {
                Clear_Console();
                Console.Write("\n 1\n{0}", Variables_Class.Press_Enter);
                Console.ReadKey();
            }
            else if (Variables_Class.Selected_Item_Number == 2)
            {
                Clear_Console();
                Console.Write("\n 2\n{0}", Variables_Class.Press_Enter);
                Console.ReadKey();
            }
            else if (Variables_Class.Selected_Item_Number == 2)
            {
                Clear_Console();
                Console.Write("\n 3\n{0}", Variables_Class.Press_Enter);
                Console.ReadKey();
            }
        }

        public static void Reset()
        {
            Variables_Class.Selected_Item_Number = 0; Variables_Class.Current_Room_Number = 1; Variables_Class.Money = 0;
            Variables_Class.Game_is_Started = false; Variables_Class.is_Menu = true; Variables_Class.Dialogue_With_a_Tramp = false;
            foreach (Variables_Class.Inventory i in Variables_Class.inventory)
            {
                i.empty = false; i.count = 0; i.name = "";
            }
            foreach (Variables_Class.Inventory i in Variables_Class.chest)
            {
                i.empty = false; i.count = 0; i.name = "";
            }
        }

        public static int Select_an_Item(int Count_Item)
        {
            Variables_Class.Selected_Item_Text = Console.ReadKey().Key.ToString();
            if (Variables_Class.Selected_Item_Text == "Escape")
            { Variables_Class.is_Menu = true; return -1; }
            else if (Variables_Class.Selected_Item_Text == "I")
            { if (!Variables_Class.is_Menu) Show_Inventory(); return -2; }
            int.TryParse(string.Join("", Variables_Class.Selected_Item_Text.Where(c => char.IsDigit(c))), out int Selected_Item);
            bool is_Converted = Selected_Item != 0;
            bool is_In_Range = Selected_Item >= 1 && Selected_Item <= Count_Item;

            while (!is_Converted || !is_In_Range)
            {
                Console.Write("\n Неизвестная команда: \"{0}\"\n{1}", Variables_Class.Selected_Item_Text, Variables_Class.Waiting_for_a_Response);
                Variables_Class.Selected_Item_Text = Console.ReadKey().Key.ToString();
                int.TryParse(string.Join("", Variables_Class.Selected_Item_Text.Where(c => char.IsDigit(c))), out Selected_Item);
                is_Converted = Selected_Item != 0;
                is_In_Range = Selected_Item >= 1 && Selected_Item <= Count_Item;
            }
            return Selected_Item;
        }

        public static void Clear_Console()
        {
            Console.Clear();
            Console.Write(Variables_Class.Ver + Variables_Class.Version_Info_Text);
        }
    }
}
