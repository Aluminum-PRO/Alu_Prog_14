using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alu_Prog_14
{
    static public class Variables_Class
    {
        public class Inventory
        {
            public bool empty = false;
            public int count = 0;
            public string name;
        }

        static public string Main_Patch, Ver, Selected_Item_Text;
        static public string Version_Info_Text = "\n Управление игрой происходит цифрами (\"1\" или \"NumPud1\" или \"F1\")\n \"Escape\" - Главное меню\n \"I\" - Открыть инвентарь\n\n", Available_Actions = " Доступные действия:", Waiting_for_a_Response = " Ожидание ответа: ", Press_Enter = " Нажмите любую клавишу для продолжения...\n";
        static public int Selected_Item_Number = 0, Current_Room_Number = 1, Money = 0;
        static public bool Game_is_Started = false, is_Menu = true, Dialogue_With_a_Tramp = false;
        static public List<Inventory> Item = new List<Inventory>();
        static public List<Inventory> inventory = new List<Inventory>();
        static public List<Inventory> chest = new List<Inventory>();
    }
}
