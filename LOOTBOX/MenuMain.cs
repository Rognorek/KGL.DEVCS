using System;

namespace LOOTBOX
{
    public static class MenuMain
    {
        public static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Добро пожаловать.");
            Console.WriteLine("ИП ЛУТБОКС. Доставка бандеролей.\n\n\n");
            Console.WriteLine("ВЫБЕРЕТЕ РОЛЬ:\n");

            Console.WriteLine("\t1. ПОЛЬЗОВАТЕЛЬ");
            Console.WriteLine("\t2. АДМИНИСТРАТОР");

            Console.WriteLine("\n\n\nНажмите ESC для выхода их программы.");
        }        
    }
}