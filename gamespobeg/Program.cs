using System;

namespace pobegizdetdoma

{
    class Program
    {
        static void Main(string[] args)
        {
            // Инициализация переменных состояния
            string playerName;
            bool hasArtifact1 = false;
            bool hasArtifact2 = false;
            bool hasArtifact3 = false;
            bool hasKey = false;
            bool hasLockpick = false;
            int ventAttemptCount = 0;

            // Шаг 1: Запрос имени игрока
            Console.WriteLine("Вы просыпаетесь в детдоме и не помните ничего... Как вас зовут?");
            Console.Write("Введите ваше имя: ");
            playerName = Console.ReadLine();
            Console.WriteLine($"\n{playerName}, вы оглядываетесь по сторонам. Вам нужно выбраться отсюда.\n");

            // Главный игровой цикл
            bool isGameRunning = true;
            while (isGameRunning)
            {
                // Главное меню
                Console.WriteLine("\nЧто вы хотите сделать?");
                Console.WriteLine("1. Попробовать открыть дверь");
                Console.WriteLine("2. Заглянуть под кровать");
                Console.WriteLine("3. Осмотреть ящик в углу комнаты");
                Console.WriteLine("4. Проверить вентиляцию");
                Console.WriteLine("5. Взглянуть на тумбочку");
                Console.WriteLine("6. Осмотреть статую рядом с дверью");
                Console.WriteLine("7. Сдаться (выйти из игры)");
                Console.Write("Выберите действие (1-7): ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1": // Дверь
                        if (hasLockpick)
                        {
                            Console.WriteLine($"Вы используете отмычку и щёлкаете замком! {playerName}, вы свободны! Победа!");
                            isGameRunning = false;
                        }
                        else
                        {
                            Console.WriteLine("Дверь прочно заперта. Нужно найти способ открыть её.");
                        }
                        break;

                    case "2": // Кровать
                        if (!hasArtifact1)
                        {
                            hasArtifact1 = true;
                            Console.WriteLine($"{playerName}, вы нашли Пыльный старый амулет!");
                        }
                        else
                        {
                            Console.WriteLine("Под кроватью только пыльные закатки. Больше ничего полезного.");
                        }
                        break;

                    case "3": // Ящик
                        if (hasKey)
                        {
                            if (!hasLockpick)
                            {
                                hasLockpick = true;
                                Console.WriteLine($"{playerName}, вы нашли Прочную отмычку в ящике!");
                            }
                            else
                            {
                                Console.WriteLine("Ящик пуст. Вы уже забрали отмычку.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ящик заперт на висячий замок. Нужен ключ.");
                        }
                        break;

                    case "4": // Вентиляция
                        if (ventAttemptCount < 2)
                        {
                            ventAttemptCount++;
                            Console.WriteLine("Решётка вентиляции не поддаётся. Попробуйте подёргать ещё.");
                        }
                        else if (ventAttemptCount == 2 && !hasArtifact2)
                        {
                            ventAttemptCount++; // Увеличиваем до 3, чтобы больше не спавнить артефакт
                            hasArtifact2 = true;
                            Console.WriteLine($"С третьей попытки решётка поддалась! {playerName}, вы нашли Странный механический шестерёнок!");
                        }
                        else
                        {
                            Console.WriteLine("Вентиляционная шахта пуста. Вы уже забрали шестерёнку.");
                        }
                        break;

                    case "5": // Тумбочка
                        if (!hasArtifact3)
                        {
                            hasArtifact3 = true;
                            Console.WriteLine($"{playerName}, вы нашли Потёртый свиток на тумбочке!");
                        }
                        else
                        {
                            Console.WriteLine("На тумбочке пусто.");
                        }
                        break;

                    case "6": // Статуя
                        if (hasArtifact1 && hasArtifact2 && hasArtifact3)
                        {
                            if (!hasKey)
                            {
                                hasKey = true;
                                Console.WriteLine($"Вы вставляете амулет, шестерёнку и свиток в углубления на статуе. Раздаётся щелчок, и из основания выпадает маленький ключ! {playerName}, вы получили Ключ от ящика!");
                            }
                            else
                            {
                                Console.WriteLine("Статуя уже активирована. Все артефакты на месте.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Старая каменная статуя с тремя углублениями. Похоже, для активации нужно найти и вставить три предмета.");
                        }
                        break;

                    case "7": // Выход
                        Console.WriteLine("Вы решили сдаться..");
                        isGameRunning = false;
                        break;

                    default:
                        Console.WriteLine("Неверный ввод. Попробуйте ещё раз.");
                        break;
                }
            }

            Console.WriteLine("\nСпасибо за игру! Нажмите любую клавишу для выхода.");
            Console.ReadKey();
        }
    }
}