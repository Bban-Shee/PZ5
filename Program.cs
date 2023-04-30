using System;
using System.Collections.Generic;

namespace PZ5
{
    class Program
    {
        //Створення перерахування з бітовими прапорцями, у якому зберігаються назви 8 дисциплін професійної підготовки – по 4 дисципліни освітніх ступенів «бакалавр» і «магістр»
        [Flags]
        public enum Disciplines
        {
            None = 0b00000000,

            ForeignLangugeForProfessionalUse = 0b00000001,
            ComputerDiscreteMathematics = 0b00000010,
            InformationTechnologiesInProfessionalActivity = 0b00000100,
            BasicsOfProgramming = 0b00001000,

            EnglishForInformationTechnologies = 0b00010000,
            FunctionalAndLogicalProgramming = 0b00100000,
            InformationSystemDesignTechnologies = 0b01000000,
            SoftwareTestingAutomation = 0b10000000,

            Bachelor = ForeignLangugeForProfessionalUse | ComputerDiscreteMathematics | InformationTechnologiesInProfessionalActivity | BasicsOfProgramming,
            Master = EnglishForInformationTechnologies | FunctionalAndLogicalProgramming | InformationSystemDesignTechnologies | SoftwareTestingAutomation
        }
        static void Main(string[] args)
        {
            //Виведення прізвища автора програми
            Console.WriteLine("Автор програми: Гнатченко А.Д.");
            //Виведення переліку дисциплін окремо по кожному освітньому ступеню
            Console.WriteLine("\nДисциплiни освiтнього ступеня «Бакалавр»:");
            Console.WriteLine("1. Iноземна мова за професiйним спрямуванням");
            Console.WriteLine("2. Комп’ютерна дискретна математика");
            Console.WriteLine("3. Iнформацiйнi технологiї у професiйнiй дiяльностi");
            Console.WriteLine("4. Основи програмування ");

            Console.WriteLine("\nДисциплiни освiтнього ступеня «Магiстр»:");
            Console.WriteLine("1. Англiйська мова iнформацiйних технологiй");
            Console.WriteLine("2. Функцiональне та логiчне програмування");
            Console.WriteLine("3. Технологiї проектування iнформацiйних систем");
            Console.WriteLine("4. Автоматизацiя тестування програмного забезпечення\n");
            //Обрання освітнього ступеня
            Console.WriteLine("\nОберiть освiтнiй ступiнь:");
            Console.WriteLine("1. Бакалавр");
            Console.WriteLine("2. Магiстр");
            int choice = 0;
            var degree = Console.ReadLine();
            bool isNumber = int.TryParse(degree, out choice);
            //Перевірка правильності введених данних 
            while (!isNumber || (choice != 1 && choice != 2))
            {
                Console.WriteLine("Ви помилились, введiть 1 або 2!");
                degree = Console.ReadLine();
                isNumber = int.TryParse(degree, out choice);
            }
            //Обрання дисциплін в залежності від освітнього ступеня
            Console.WriteLine("Оберiть дисциплiни:");
            switch (choice)
            {
                case 1:
                    Console.WriteLine("1. Iноземна мова за професiйним спрямуванням");
                    Console.WriteLine("2. Комп’ютерна дискретна математика");
                    Console.WriteLine("3. Iнформацiйнi технологiї у професiйнiй дiяльностi");
                    Console.WriteLine("4. Основи програмування ");
                    break;
                case 2:
                    Console.WriteLine("1. Англiйська мова iнформацiйних технологiй");
                    Console.WriteLine("2. Функцiональне та логiчне програмування");
                    Console.WriteLine("3. Технологiї проектування iнформацiйних систем");
                    Console.WriteLine("4. Автоматизацiя тестування програмного забезпечення");
                    break;
            }
        Input:
            string text = Console.ReadLine();
            char[] n = text.ToCharArray();
            var numbers = new List<int>();
            for (int i = 0; i < n.Length; i++)
            {
                bool isDigit = Char.IsDigit(n[i]);
                int t = n[i] - 48;
                if ((i != 0) && (n[i - 1] == '-') && isDigit) numbers.Add(0 - t);
                else if (isDigit) numbers.Add(t);
            }
            uint counter = 0;
            //Перевірка правильності введених данних
            if (numbers.Count > 0)
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] < 1 || numbers[i] > 4) counter++;

                }
                if (counter >= 1)
                {
                    if (numbers.Count == 1 && counter == 1) Console.WriteLine("Введене вами число не входить у наведений перелiк. Оберiть дисциплiни ще раз!");
                    else if (numbers.Count > 1 && counter == 1) Console.WriteLine("Одне з чисел, якi ви ввели, не входить у наведений перелiк. Оберiть дисциплiни ще раз!");
                    else if (counter > 1) Console.WriteLine("Деякi з введених вами чисел не входять у наведений перелiк. Оберiть дисциплiни ще раз!");
                    else goto Output;
                    goto Input;
                }
            }
            else
            {
                Console.WriteLine("Ви ввели некоректне значення. Спробуйте ще раз!");
                goto Input;
            }
        Output:
            //Виведення обраних дисциплін та освітнього ступеня з застосуванням констант 
            if (numbers.Count > 1) Console.Write("Обранi дисциплiни: ");
            else Console.Write("Обрана дисциплiна: ");
            int subject = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                switch (choice)
                {
                    case 1:
                        subject = (int)Math.Pow(2, numbers[i] - 1);
                        break;
                    case 2:
                        subject = (int)Math.Pow(2, numbers[i] + 3);
                        break;
                }
                switch (subject)
                {
                    case 0b00000001:
                        Console.Write("Iноземна мова за професiйним спрямуванням");
                        break;
                    case 0b00000010:
                        Console.Write("Комп’ютерна дискретна математика");
                        break;
                    case 0b00000100:
                        Console.Write("Iнформацiйнi технологiї у професiйнiй дiяльностi");
                        break;
                    case 0b00001000:
                        Console.Write("Основи програмування");
                        break;
                    case 0b00010000:
                        Console.Write("Англiйська мова iнформацiйних технологiй");
                        break;
                    case 0b00100000:
                        Console.Write("Функцiональне та логiчне програмування");
                        break;
                    case 0b01000000:
                        Console.Write("Технологiї проектування iнформацiйних систем");
                        break;
                    case 0b10000000:
                        Console.Write("Автоматизацiя тестування програмного забезпечення");
                        break;
                }
                if (i != (numbers.Count - 1)) Console.Write(", ");
                else Console.Write(".\n");
            }
            if ((((Disciplines)subject & Disciplines.Bachelor) != 0) && numbers.Count > 1) Console.WriteLine("Обранi дисциплiни належать до освiтнього ступеня «Бакалавр».");
            else if ((((Disciplines)subject & Disciplines.Master) != 0) && numbers.Count > 1) Console.WriteLine("Обранi дисциплiни належать до освiтнього ступеня «Магiстр».");
            else if ((((Disciplines)subject & Disciplines.Bachelor) != 0) && numbers.Count == 1) Console.WriteLine("Обрана дисциплiна належить до освiтнього ступеня «Бакалавр».");
            else Console.WriteLine("Обрана дисциплiна належить до освiтнього ступеня «Магiстр».");
        }
    }
}