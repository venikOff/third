using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Third_practics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Задание 1.
            ///Выводим наименование программы            
            WriteLine("Определение четного и нечетного числа.");

            ///Просим пользователя ввести число
            Write("Введите число: ");
            int userNumber = int.Parse(ReadLine());

            ///Определяем четность числа
            if (userNumber % 2 == 0)
            {
                WriteLine($"Ваше число {userNumber} - четное.");
            }
            else
            {
                WriteLine($"Ваше число {userNumber} - нечетное.");
            }

            ReadKey();
            Clear();
            #endregion

            #region Задание 2.
            ///Выводим наименование программы
            WriteLine("Подсчет карт в игре 21!");

            ///Даем пояснения по номиналу карт
            WriteLine($"Подсчет карт осуществляется при вводе номинала карты.\n" +
                $"Номинал карты - это ее число или буква.\n" +
                $"В случе если у Вас на руке есть карты с буквенным выражением нобходимо ввести соответсвующую букву.");
            ReadKey();

            ///Даем пояснения по буквенному номиналу карт
            WriteLine($"Буквенное выражение номинала карты:\n" +
                $"Валет - J;\n" +
                $"Дама - Q;\n" +
                $"Король - K;\n" +
                $"Туз - A.");

            ///Запрос по количеству карт на руке
            Write("Сколько у вас карт? - ");
            int userCountCards = int.Parse(ReadLine());

            ///Задаем переменную для общей суммы номиналов карт
            int sumCards = 0;

            ///Цикл для подсчета
            for (int i = 1; i <= userCountCards; i++)
            {
                Write("Введите номинал карты - ");
                string weight = ReadLine();

                switch (weight)
                {
                    case "J":
                    case "Q":
                    case "K":
                    case "A":
                        sumCards = sumCards + 10; break;
                    default:
                        int card = int.Parse(weight);
                        sumCards = sumCards + card; break;
                }

            }

            ///Выводим сумму номиналов карт пользователя
            WriteLine($"Сумма Вших карт - {sumCards}");
            ReadKey();
            Clear();
            #endregion

            #region Задание 3.
            ///Выводим название программы
            WriteLine("Определение простого и составного числа.");

            ///Просим ввести число для определения
            Write("Введите число - ");
            int number = int.Parse(ReadLine());

            ///Задаем переменную для определения простого числа
            bool primeNumber = true;

            ///Цикл для определения
            int a = 2;

            while (a <= number - 1)
            {
                if (number % a == 0)
                {
                    primeNumber = false;
                    break;
                }
                a++;
            }
            ///Выводим результат определения
            if (primeNumber)
            {
                WriteLine($"Ваше число {number} - простое.");
            }
            else
            {
                WriteLine($"Ваше число {number} - составное.");
            }

            ReadKey();
            Clear();
            #endregion

            #region Задание 4.
            ///Выводим название программы
            WriteLine("Определение минимального числа в последовательности");

            ///Запрашиваем колличество чисел в последовательности
            Write("Сколько чисел в последовательности? - ");
            int sequence = int.Parse(ReadLine());

            ///Задаем максимальное число как минимальное
            int MinValue = int.MaxValue;

            ///Цикл определения минимального числа
            for (int check = 1; check <= sequence; check++)
            {
                Write("Введите число - ");
                int chislo = int.Parse(ReadLine());

                if (chislo < MinValue)
                {
                    MinValue = chislo;
                }
            }

            ///Выводим результат
            WriteLine($"Минимальное число в заданной последовательности - {MinValue}");
            ReadKey();
            Clear();

            #endregion

            #region Задание 5.
            ///Выводим название программы и правила игры
            WriteLine($"Ирга - Угадай число!\n" +
                $"Правила игры просты:\n" +
                $"Программа загадывает число в диапазоне от 0 до установленного игроком.\n" +
                $"А игрок пытается угадать загаданное число.\n" +
                $"В случае если иргок не угадывает число, программа дает ответ -\n" +
                $"загаданное число больше или меньше нежели чем то, что предположил игрок.\n" +
                $"Игра продолжается до тех пор пока игрок не отгадает число.\n" +
                $"Если игроку надоело играть - то вводить число не нужно. Просто нажмите Enter.\n" +
                $"Удачи!!"); ReadKey(); Clear();

            ///Запрашиваем у игрока верхний предел 
            WriteLine("Задайте верхний предел диапазона - ");
            int MaxValue = int.Parse (ReadLine());

            ///Создаем переменную с рандомным значением из заданного диапазона
            Random rand = new Random();
            int randomNumber = rand.Next(0, MaxValue);

            ///Предупреждаем игрока, что число загадано
            WriteLine("Число загадано!");

            ///Задаем переменную для цикла
            int b = 1;
            ///Задаем переменную для счетчика попыток
            int score = 1;

            ///Цикл игры
            do
            {
                WriteLine("Введите Ваше предположение - ");
                string input = ReadLine();
                
                ///Проверяем ввел ли игрок число. Если нет, завершаем игру. 
                if (input == string.Empty)
                {
                    WriteLine($"Ты уже сдался,слабак?\n" +
                        $"Хорошо. Загаданное число - {randomNumber}");
                    break;
                }
                
                ///Перемещаем введенное значение в переменую
                int answer = int.Parse(input);

                ///Проверяем угадал ли игрок число
                if (answer > randomNumber)
                {
                    WriteLine("Загаданное число меньше Вашего.");
                    score++;
                }
                else if (answer < randomNumber)
                {
                    WriteLine("Загаданное число больше Вашего.");
                    score++;
                }
                else if (answer == randomNumber)
                {
                    WriteLine($"Вы угадали число!!! Это {randomNumber}!!!\n" +
                        $"Колличество попыток - {score}");
                    score++;
                    
                    ///Когда игрок угадал число прерываем цикл игры
                    b++;
                }
            } while (b == 1);
            
            ReadKey();
            #endregion

        }
    }
}
