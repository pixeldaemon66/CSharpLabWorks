using static System.Console;
using static System.Math;
using System.Text;

namespace Lab2
{
    class Program
    {
        static void Task1()
        {
            for (double x = 1; x <= 10; x += 0.5)
            {
                for (int a = 1; a <= 4; a++)
                {
                    double y = -Log(Abs((x + a) / (1 + Pow(x, 2))));
                    Write($"Y({x}, {a}) = {y,3:F}\n");
                }
            }
            return;
        }
        static void Task2()
        {
            double s, u, x, y;
            int k;
            s = 0; //сума
            x = 0.25; //значення х
            u = x; //функція
            k = 1; //номер ітерації
            while (Abs(u) >= 0.000001)
            {
                s += u;
                WriteLine($"Ітерація {k}: S({u}) = {s:F3}");
                u = Pow(-1, k - 1) * (1 + Pow(2, k)) * (Pow(x, k) / k);
                k++;
            }
            y = Log(1 + 3 * x + 2 * Pow(x, 2));
            WriteLine($"Y({x}) = {y:F3}");
            return;
        }

        static void Task3()
        {
            WriteLine("Введіть рівень складності (1-3): ");
            int difficulty = int.Parse(ReadLine());
            int dquestions = 0; //кількість питань
            int dd = 0; //поріг генерації випадкового числа
            int x1, x2, answer, correct;
            //--встановлення рівня складності--//
            switch (difficulty)
            {
                case 1:
                    dquestions = 5;
                    dd = 10;
                    break;
                case 2:
                    dquestions = 10;
                    dd = 90;
                    break;
                case 3:
                    dquestions = 12;
                    dd = 500;
                    break;
                default:
                    break;
            }
            //---------------------------------//
            correct = dquestions; // з кожною помилкою кількість правильних відповідей буде зменшуватись
            do
            {
                Random r = new();
                x1 = r.Next(2, dd);
                x2 = r.Next(2, dd);
                WriteLine($"{x1} x {x2} = ?");
                answer = int.Parse(ReadLine());
                if (x1 * x2 != answer)
                {
                    correct--;
                    WriteLine("Неправильно!");
                }
                else WriteLine("Правильно!");
                dquestions--;
            }
            while (dquestions != 0);
            WriteLine($"Правильних відповідей: {correct}");
            return;
        }

        static void Task4()
        {
            static void Round(int level, int round_number)
            {
                Random r = new();
                string num_GL, answer;
                int guess, p_score = 0, c_score = 0, lives, init_lives, score_mult, left, right;
                
                if(level == 1)
                {
                    lives = 50; //кількість життів
                    left = 1; //початкове число для генерації
                    right = 10; //кінцеве число для генерації
                    score_mult = 5; //множник очок
                }
                else
                {
                    lives = 25;
                    left = 10;
                    right = 100;
                    score_mult = 10;
                }

                init_lives = lives; //початкова кількість життів для нарахування очок комп'ютеру за програш користувача
                int number = r.Next(left, right); //загадане число

                WriteLine($"РІВЕНЬ {level} РАУНД {round_number}");

                do
                {
                    WriteLine($"Ваше число ({left}-{right}):");
                    guess = int.Parse(ReadLine());

                    if(guess != number)
                    {
                        lives--;
                        WriteLine("Неправильно! \n Бажаєте використати підказку? (Натисність ENTER якщо так. Вартість підказки - 1 життя)\n");
                        if(ReadKey().Key==ConsoleKey.Enter)
                        {
                            lives--;
                            num_GL = guess > number ? "МЕНШЕ" : "БІЛЬШЕ"; //порівняння загаданого числа і введеного

                            WriteLine($"Загадане число {num_GL} ніж ваше");
                        }
                        WriteLine("ПРОДОВЖУЄМО ГРУ!");
                    }
                    if(lives == 0)
                    {
                        WriteLine("ВИ ПРОГРАЛИ!");
                        c_score += init_lives * score_mult;
                    }
                }
                while (guess != number);
                WriteLine("Правильно!");
                p_score += lives * score_mult;
                WriteLine($"КІНЕЦЬ РАУНДУ\nОчки\nВи: {p_score} | Комп'ютер: {c_score}\n");
            }

            for(int lvl = 1; lvl <= 2; lvl++)
            {
                for(int r = 1; r <= 3; r++)
                {
                    Round(lvl, r);
                }
                WriteLine("Перейти на другий рівень? (Натисніть ENTER якщо так)\n");
                if (ReadKey().Key != ConsoleKey.Enter) return;
            }
        }
        static void Main()
        {
            InputEncoding = Encoding.UTF8;
            OutputEncoding = Encoding.UTF8;

            while (true)
            {
                WriteLine("Оберіть завдання (1-4): ");
                
                int r = int.Parse(ReadLine());
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
                    default:
                        return;
                }
            }
        }
    }
}