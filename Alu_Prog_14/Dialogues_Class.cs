using System;

namespace Alu_Prog_14
{
    static public class Dialogues_Class
    {
        static public void Tramp_Dialogue()
        {
            Program.Clear_Console();
            Console.Write(" (Вы)| Вы подошли к Бродяге и сказали ему:\"Жизнь или смерть, грязный бродяга!\"\n" +
                " (Бродяга)| Вот возьми всё что у меня есть, только не трогай меня\n" +
                "{0}\n (1)Забрать всё что у него есть\n (2)Оставить бродягу в покое\n{1}", Program.Available_Actions, Program.Waiting_for_a_Response);
            while (!Program.Dialogue_With_a_Tramp)
            {
                Program.Selected_Item_Number = Program.Select_an_Item(2);

                if (Program.Selected_Item_Number == 1)
                {
                    Program.Clear_Console();
                    bool Result = false;
                    foreach (Inventory i in Program.inventory)
                    {
                        if (!i.empty)
                        {
                            i.empty = true;
                            i.count += Program.Item[0].count;
                            i.name = Program.Item[0].name;
                            Result = true;
                        }
                        if (Result) break;
                    }
                    if (!Result) Console.Write("\n (Вы)| Вы забрали у Бродяги 50 Монет, а Медальон взять не получается, так как ваш инвентарь полон\n");
                    else if (Result) Console.Write("\n (Вы)| Вы забрали у Бродяги Медальон и 50 Монет\n");
                    Console.Write(" (Бродяга)| Я теперь умру с голоду\n{0}", Program.Press_Enter);
                    Program.Money += 50;
                    Program.Dialogue_With_a_Tramp = true;
                    Console.ReadKey();
                    break;
                }
                else if (Program.Selected_Item_Number == 2)
                {
                    Program.Clear_Console();
                    Program.Reset(); Program.is_Menu = true; Program.Game_is_Started = false;
                    Console.Write("\n (Бродяга)| Бродяга всадил Вам нож в спину как только Вы отвернулись\n\n Игра окончена, вы проиграли\n{0}", Program.Press_Enter);
                    Console.ReadKey();
                    break;
                }
                else if (Program.Selected_Item_Number == -1)
                {
                    Console.Write("\n В Диалогах нельзя выйти в меню\n{0}", Program.Press_Enter);
                    Console.ReadKey();
                }

                Program.Clear_Console();
                Console.Write(" (Вы)| Вы подошли к Бродяге и сказали ему:\"Жизнь или смерть, грязный бродяга!\"\n" +
                    " (Бродяга)| Вот возьми всё что у меня есть, только не трогай меня\n" +
                    "{0}\n (1)Забрать всё что у него есть\n (2)Оставить бродягу в покое\n{1}", Program.Available_Actions, Program.Waiting_for_a_Response); //TODO: После диалога не открывается Escepe и Inventory
            }
        }
    }
}
