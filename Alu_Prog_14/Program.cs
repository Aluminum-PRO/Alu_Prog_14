namespace Alu_Prog_14
{
    class Program
    {
        static void Main(string[] args)
        {
            Methods_Class.Load();
            Methods_Class.Game_Settings();
            if (args.Length == 0)
            { }

            while (true)
            {
                if (Variables_Class.is_Menu) Methods_Class.Main_Menu();
                else if (!Variables_Class.is_Menu) Methods_Class.Game();
            }
        }
    }
}
