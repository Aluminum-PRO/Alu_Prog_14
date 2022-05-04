using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Alu_Prog_14
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Variables
            string Main_Patch, Ver, Selected_Item_Text;
            int Selected_Item_Number = 0;
            #endregion

            Load();
            void Load()
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
                Console.Write(" Ver.{0}\n Управление игрой происходит цифрами (\"1\" или \"NumPud1\" или \"F1\")\n\n", Ver);

                if (args.Length == 0)
                    Main_Menu();
            }

            void Main_Menu()
            {
                Console.Write(" Главное меню:\n (1)Начать игру\n (2)Выйти из игры\n Ожидание ответа: ");
                Select_an_Item(out Selected_Item_Number);
                if (Selected_Item_Number == 1)
                    Started_Game();
                else if (Selected_Item_Number == 2)
                    Environment.Exit(0);
                else
                { Console.Write("\n Неизвестная команда: \"{0}\"\n\n", Selected_Item_Text); Main_Menu(); }

            }

            void Select_an_Item(out int Selected_Item)
            {
                Selected_Item_Text = Console.ReadKey().Key.ToString();
                int.TryParse(String.Join("", Selected_Item_Text.Where(c => char.IsDigit(c))), out Selected_Item);
            }

            void Started_Game()
            {

            }

            Main_Menu();
        }
    }
}
