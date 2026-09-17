using System;
using System.Text;

namespace Laba1
{
    class Program
    {
        static void Task1()
        {
            double m = 16.7;
            double n = 9.44;
            double a = 60.0;

            double y = (Math.Pow(m, 2) - Math.Pow(n, 2)) / Math.Cos(a * (Math.PI / 180.0)) * Math.Sqrt((4.0 / 3) - Math.Pow(Math.Cos(a * (Math.PI / 180.0)), 3));
            Console.WriteLine($"y({m,2:F}, {n,2:F}, {a}) = {y,3:F}");
            return;
        }

        static void Task2()
        {
            string? s;
            double x, y;
            StreamWriter f = new StreamWriter("out.txt");
            StreamReader f1 = new StreamReader("in.txt");
            f.WriteLine("Отримано \n");
        tag0: s = f1.ReadLine();
            if (s == null) goto tag1;
            x = double.Parse(s);
            while(x <= 2)
            {
                y = Math.Pow(Math.Cos(Math.PI * x), 2) - 2;
                f.WriteLine($"для заданої функції Y({x})={y}\n");
                x++;
            }
            goto tag0;
        tag1: f.WriteLine("Розрахував студент Турбаєвська О. С.  \n", s);
            f.Close();
            f1.Close();
            Console.WriteLine("Перевірте файл out.txt");
            return;
        }

        static void Task3()
        {
            int score = 0;
            int ans;
            Console.WriteLine("Перевір свої здібності!");
            Console.WriteLine("1. Професор ліг спати о 8 годині, а встав о 9 годині. Кількість годин сну професору?");
            ans = int.Parse(Console.ReadLine());
            if (ans == 1) score++;

            Console.WriteLine("2. На двох руках десять пальців. Скільки пальців на 10?");
            ans = int.Parse(Console.ReadLine());
            if (ans == 50) score++;

            Console.WriteLine("3. Скільки цифр у дюжині?");
            ans = int.Parse(Console.ReadLine());
            if (ans == 2) score++;

            Console.WriteLine("4. Скільки потрібно зробити розпилів, щоб розпиляти колоду на 12 частин?");
            ans = int.Parse(Console.ReadLine());
            if (ans == 11) score++;

            Console.WriteLine("5. Лікар зробив три уколи в інтервалі 30 хвилин. Скільки часу він витратив?");
            ans = int.Parse(Console.ReadLine());
            if (ans == 30) score++;

            Console.WriteLine("6. Скільки цифр 9 в інтервалі 1100?");
            ans = int.Parse(Console.ReadLine());
            if (ans == 1) score++;

            Console.WriteLine("7. Пастух мав 30 овець. Усі, окрім однієї, розбіглися. Скільки овець лишилося?");
            ans = int.Parse(Console.ReadLine());
            if (ans == 1) score++;

            string result = score switch
            {
                7 => "Геній",
                6 => "Ерудит",
                5 => "Нормальний",
                4 => "Здібності середні",
                3 => "Здібності нижче середнього",
                _ => "Вам треба відпочити!"
            };
            Console.WriteLine($"Результат:{result}");
            return;
        }

        static void Task4()
        {
            string[] data = File.ReadAllLines("input.txt");

            double tank = double.Parse(data[0]); //місткість бака
            double AB = double.Parse(data[1]); //відстань від А до В
            double BC = double.Parse(data[2]); //від А до С
            double weight = double.Parse(data[3]); //вага вантажу
            //--- Перевірка умови ---//
            double cons = weight switch
            {
                <= 500 => 1,
                <= 1000 => 4,
                <= 1500 => 7,
                <= 2000 => 9,
                _ => 0
            };
            if (cons == 0) 
            {
                Console.WriteLine("Політ неможливий: вантаж занадто важкий!");
                return;
            }

            //--- Розрахування витрат ---//
            double fuelAB = AB * cons;
            double fuelBC = BC * cons;
            
            if (fuelAB > tank)
            {
                Console.WriteLine("Політ неможливий: неможливо подолати відстань від A до B!");
                return;
            }
            if (fuelBC > tank)
            {
                Console.WriteLine("Політ неможливий: неможливо подолати відстань від B до C!");
                return;
            }

            double AtBleft = tank - fuelAB; //залишок палива
            double toRefuel = fuelBC - AtBleft; //скільки треба долити
            if (toRefuel < 0) toRefuel = 0;

            Console.WriteLine($"Витрата палива: {cons} л/км");
            Console.WriteLine($"Паливо на відстань А-В: {fuelAB} л");
            Console.WriteLine($"Паливо на відстань В-С: {fuelBC} л");
            Console.WriteLine($"Залишок палива в В: {AtBleft} л");
            Console.WriteLine($"Мінімальна кількість палива для дозаправки: {toRefuel} л");

            return;
        }

        static void Task5()
        {
            double penalty = 20;
            double salary = 1.5;

            Console.WriteLine("Оберіть режим:");
            int r = int.Parse(Console.ReadLine());
            switch (r)
            {
                case 1:
                    Console.WriteLine("Введіть бажаний дохід Васі програміста:");
                    double wish = double.Parse(Console.ReadLine());
                    Console.WriteLine("Введіть кількість його запізнень:");
                    double late = double.Parse(Console.ReadLine());

                    int result = (int)(wish / salary - late * penalty);
                    Console.WriteLine($"Тоді Вася повинен написати {result} рядків коду.");
                    break;
                case 2:
                    Console.WriteLine("Скільки рядків коду написав Вася?");
                    int lines = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введіть бажаний дохід:");
                    double wish2 = double.Parse(Console.ReadLine());

                    int result2 = (int)((lines * salary - wish2) / penalty);
                    if (result2 <= 0) Console.WriteLine("Вася не може запізнитися");
                    else Console.WriteLine($"Вася може запізнитися {result2} разів.");
                    break;
                case 3:
                    Console.WriteLine("Скільки рядків коду написав Вася?");
                    int lines2 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введіть кількість його запізнень:");
                    double late2 = double.Parse(Console.ReadLine());

                    double result3 = lines2 * salary - late2 * penalty;
                    if (result3 <= 0) Console.WriteLine("Вася сидить голодний.");
                    else Console.WriteLine($"Васі заплатять ${result3}.");
                    break;
            }
            return;
        }

        static string Task6(double number)
        {
            if (number % 3 == 0 & number % 5 == 0) return "Fizz Buzz";
            else if (number % 5 == 0) return "Buzz";
            else if (number % 3 == 0) return "Fizz";
            else return Convert.ToString(number);
        }

        static void Task7()
        {
            Console.WriteLine("Введіть дату:");
            string? date = Console.ReadLine();
            string season;
            DateTime myDate;
            if(!DateTime.TryParse(date, out myDate))
            {
                Console.WriteLine("Неправильний формат/дата");
                return;
            }
            else
            {
                if (myDate.Month == 12 || myDate.Month == 1 || myDate.Month == 2) season = "Winter";
                else if (myDate.Month == 3 || myDate.Month == 4 || myDate.Month == 5) season = "Spring";
                else if (myDate.Month == 6 || myDate.Month == 7 || myDate.Month == 8) season = "Summer";
                else season = "Fall";
                Console.WriteLine($"{season}, {myDate.DayOfWeek}");
            }
            return;
        }

        static void Main()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("Оберіть завдання (номер):");
                int r = int.Parse(Console.ReadLine());
                switch (r)
                {
                    case 1:
                        Task1();
                        break;
                    case 2:
                        Task2();
                        break;
                    case 3:
                        Task3();
                        break;
                    case 4:
                        Task4();
                        break;
                    case 5:
                        Task5();
                        break;
                    case 6:
                        Console.WriteLine("Введіть число (від 1 до 100): ");
                        double number = double.Parse(Console.ReadLine());
                        if (number < 1 || number > 100)
                        {
                            Console.WriteLine("Число не задовольняє умови!");
                            break;
                        }
                        Console.WriteLine(Task6(number));
                        break;
                    case 7:
                        Task7();
                        break;
                    default:
                        return;
                };
                Console.ReadKey();
            }
        }
    }
}