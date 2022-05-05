using System;

namespace Alu_Prog_14
{
    static public class Dialogues_Class
    {
        static public void Tramp_Dialogue()
        {
            Methods_Class.Clear_Console();
            Console.Write(" (Вы)| Вы подошли к Бродяге и сказали ему:\"Жизнь или смерть, грязный бродяга!\"\n" +
                " (Бродяга)| Вот возьми всё что у меня есть, только не трогай меня\n" +
                "{0}\n (1)Забрать всё что у него есть\n (2)Оставить бродягу в покое\n{1}", Variables_Class.Available_Actions, Variables_Class.Waiting_for_a_Response);
            while (!Variables_Class.Dialogue_With_a_Tramp)
            {
                Variables_Class.Selected_Item_Number = Methods_Class.Select_an_Item(2);

                if (Variables_Class.Selected_Item_Number == 1)
                {
                    Methods_Class.Clear_Console();
                    bool Result = false, Coincidences = false;
                    foreach (Variables_Class.Inventory i in Variables_Class.inventory)
                    {
                        if (i.empty && i.name == Variables_Class.Item[0].name && i.count < 5)
                        { i.count += Variables_Class.Item[0].count; Result = true; Coincidences = true; }
                    }
                    if (!Coincidences)
                        foreach (Variables_Class.Inventory i in Variables_Class.inventory)
                        {
                            if (!i.empty)
                            {
                                i.empty = true;
                                i.count += Variables_Class.Item[0].count;
                                i.name = Variables_Class.Item[0].name;
                                Result = true;
                            }
                            if (Result) break;
                        }
                    if (!Result) Console.Write("\n (Вы)| Вы забрали у Бродяги 50 Монет, а Медальон взять не получается, так как ваш инвентарь полон\n");
                    else if (Result) Console.Write("\n (Вы)| Вы забрали у Бродяги Медальон и 50 Монет\n");
                    Console.Write(" (Бродяга)| Я теперь умру с голоду\n{0}", Variables_Class.Press_Enter);
                    Variables_Class.Money += 50;
                    Variables_Class.Dialogue_With_a_Tramp = true;
                    Console.ReadKey();
                    break;
                }
                else if (Variables_Class.Selected_Item_Number == 2)
                {
                    Methods_Class.Clear_Console();
                    Methods_Class.Reset(); Variables_Class.is_Menu = true; Variables_Class.Game_is_Started = false;
                    Console.Write("\n (Бродяга)| Бродяга всадил Вам нож в спину как только Вы отвернулись\n\n Игра окончена, вы проиграли\n{0}", Variables_Class.Press_Enter);
                    Console.ReadKey();
                    break;
                }
                else if (Variables_Class.Selected_Item_Number == -1)
                {
                    Console.Write("\n В Диалогах нельзя выйти в меню\n{0}", Variables_Class.Press_Enter);
                    Console.ReadKey();
                }

                Methods_Class.Clear_Console();
                Console.Write(" (Вы)| Вы подошли к Бродяге и сказали ему:\"Жизнь или смерть, грязный бродяга!\"\n" +
                    " (Бродяга)| Вот возьми всё что у меня есть, только не трогай меня\n" +
                    "{0}\n (1)Забрать всё что у него есть\n (2)Оставить бродягу в покое\n{1}", Variables_Class.Available_Actions, Variables_Class.Waiting_for_a_Response); //TODO: После диалога не открывается Escepe и Inventory
            }
        }
    }
}
