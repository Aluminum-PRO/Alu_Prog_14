using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alu_Prog_14
{
    static public class Rooms_Class
    {
        static public void Started_Room()
        {
            Methods_Class.Clear_Console();
            Console.Write(" Вы находитесь в своей комнате\n{0}\n (1)Осмотреть окрестности\n (2)Подойти и открыть шкаф\n (3)Выйти из своей комнаты\n{1}", Variables_Class.Available_Actions, Variables_Class.Waiting_for_a_Response);
            Variables_Class.Selected_Item_Number = Methods_Class.Select_an_Item(3);
            
            if (Variables_Class.Selected_Item_Number == 1)
            {
                Methods_Class.Clear_Console();
                Console.Write("\n Обычная жилая комната, письменный стол возле окна, вдоль стены не большая кушетка и небольшой шкаф мирно стоящий в углу\n{0}", Variables_Class.Press_Enter);
                Console.ReadKey();
            }
            else if (Variables_Class.Selected_Item_Number == 2)
            {
                Methods_Class.Clear_Console();
                Console.Write("\n Вы подошли к шкафу, и открываете дверцы\n{0}", Variables_Class.Press_Enter);
                Variables_Class.Current_Room_Number = 2;
                Console.ReadKey();
            }
            else if (Variables_Class.Selected_Item_Number == 3)
            {
                Methods_Class.Clear_Console();
                Console.Write("\n Вы вышли из своей комнаты\n{0}", Variables_Class.Press_Enter);
                Variables_Class.Current_Room_Number = 2;
                Console.ReadKey();
            }
        }

        static public void Hallway_Room()
        {
            Methods_Class.Clear_Console();
            Console.Write(" Вы находитесь в коридоре\n{0}\n (1)Зайти в свою комнату\n (2)Зайти в Таверну\n{1}", Variables_Class.Available_Actions, Variables_Class.Waiting_for_a_Response);
            Variables_Class.Selected_Item_Number = Methods_Class.Select_an_Item(2);

            if (Variables_Class.Selected_Item_Number == 1)
            {
                Methods_Class.Clear_Console();
                Console.Write("\n Вы заходите в свою комнату\n{0}", Variables_Class.Press_Enter);
                Variables_Class.Current_Room_Number = 1;
                Console.ReadKey();
            }
            else if (Variables_Class.Selected_Item_Number == 2)
            {
                Methods_Class.Clear_Console();
                Console.Write("\n Вы подходите к двери Таверны и открывая дверь, заходите внутрь\n{0}", Variables_Class.Press_Enter);
                Variables_Class.Current_Room_Number = 3;
                Console.ReadKey();
            }
        }

        static public void Tavern_Room()
        {
            Methods_Class.Clear_Console();
            Console.Write(" Вы находитесь в Таверне\n{0}\n (1)Поговорить с Бродягой\n (2)Осмотреть окрестности\n (3)Выйти из Таверны\n{1}", Variables_Class.Available_Actions, Variables_Class.Waiting_for_a_Response);
            Variables_Class.Selected_Item_Number = Methods_Class.Select_an_Item(3);

            
            if (Variables_Class.Selected_Item_Number == 1)
            {
                if (!Variables_Class.Dialogue_With_a_Tramp) Dialogues_Class.Tramp_Dialogue();
                else if (Variables_Class.Dialogue_With_a_Tramp)
                {
                    Methods_Class.Clear_Console();
                    Console.Write(" (Бродяга)| У меня больше ничего нет\n{0}", Variables_Class.Press_Enter);
                    Console.ReadKey();
                }
            }
            else if (Variables_Class.Selected_Item_Number == 2)
            {
                Methods_Class.Clear_Console();
                Console.Write("\n Вечер, тусклые лампочки еле освещают пустые столики. В углу отдыхает Бродяга\n{0}", Variables_Class.Press_Enter);
                Console.ReadKey();
            }
            else if (Variables_Class.Selected_Item_Number == 3)
            {
                Methods_Class.Clear_Console();
                Console.Write("\n Вы выходите из Таверны\n{0}", Variables_Class.Press_Enter);
                Variables_Class.Current_Room_Number = 2;
                Console.ReadKey();
            }
        }
    }
}
