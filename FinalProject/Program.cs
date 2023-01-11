using System;

namespace FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = GetUserInfo();
            DisplayUserInfo(user);
        }

        static void DisplayUserInfo((string name, string surname, int age, string[] petsNames, string[] favoriteColorsNames) user)
        {
            Console.WriteLine($"=======================================");
            Console.WriteLine($"Информация о пользователе: ");
            Console.WriteLine($"Имя пользователя: {user.name}");
            Console.WriteLine($"Фамилия пользователя: {user.surname}");
            Console.WriteLine($"Возраст пользователя: {user.age}");

            if(user.petsNames is not null)
            {
                Console.WriteLine($"Количество домашних питомцев пользователя: {user.petsNames.Length}");

                for (int i = 0; i < user.petsNames.Length; i++)
                {
                    Console.WriteLine($"Кличка питомца № {i + 1}: {user.petsNames[i]}");
                }
            } 
            else
            {
                Console.WriteLine($"Количество домашних питомцев пользователя: Отсутствуют");
            }

            if(user.favoriteColorsNames is not null)
            {
                Console.WriteLine($"Количество любимых цветов пользователя: {user.favoriteColorsNames.Length}");

                for (int i = 0; i < user.favoriteColorsNames.Length; i++)
                {
                    Console.WriteLine($"Любимый цвет № {i + 1}: {user.favoriteColorsNames[i]}");
                }
            } 
            else
            {
                Console.WriteLine($"Количество любимых цветов пользователя: Отсутствуют");
            }
            
        }
        static (string name, string surname, int age, string[] petsNames, string[] favoriteColorsNames) GetUserInfo()
        {
            var userName = GetUserName();
            var userSurname = GetUserSurname();
            var age = GetUserAge();
            var isHavePets = IsHavePets();

            int petsCount = 0;
            string[] petsNames = null;

            if (isHavePets)
            {
                petsCount = GetPetsCount();
                petsNames = GetPetsNames(petsCount);
            }

            int favoriteColorsCount = GetFavoriteColorsCount();
            string[] favoriteColorsNames = null;

            if (favoriteColorsCount != 0)
            {
                favoriteColorsNames = GetFavoriteColorsNames(favoriteColorsCount);
            }

            return (userName, userSurname, age, petsNames, favoriteColorsNames);
        }

        static string[] GetFavoriteColorsNames(int favoriteColorsCount)
        {
            string[] favoriteColorsNames = new string[favoriteColorsCount];

            for (int i = 0; i < favoriteColorsCount; i++)
            {
                Console.Write($"Какой ваш любимый цвет №{i + 1} ?: ");
                favoriteColorsNames[i] = Console.ReadLine();
            }
            return favoriteColorsNames;
        }

        static int GetFavoriteColorsCount()
        {
            Console.Write("Сколько у вас любимых цветов?: ");

            while (true)
            {
                var inputMessage = Console.ReadLine();

                if (int.TryParse(inputMessage, out var number) && number >= 0)
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Введённое число некорректное!");
                    Console.Write("Сколько у вас любимых цветов?: ");
                }
            }
        }

        static string[] GetPetsNames(int petsCount)
        {
            string[] petsNames = new string[petsCount];

            for (int i = 0; i < petsCount; i++)
            {
                Console.Write($"Как зовут питомца №{i + 1} ?: ");
                petsNames[i] = Console.ReadLine();
            }

            return petsNames;
        }

        static int GetPetsCount()
        {
            Console.Write("Сколько у вас домашних питомцев?: ");

            while (true)
            {
                var inputMessage = Console.ReadLine();

                if (int.TryParse(inputMessage, out var number) && number > 0)
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Введённое число некорректное!");
                    Console.Write("Сколько у вас домашних питомцев?: ");
                }

            }
        }

        static bool IsHavePets()
        {
            Console.Write("Есть ли у вас домашние питомцы? (Да / Нет): ");

            while (true)
            {
                var inputMessage = Console.ReadLine();

                if(inputMessage == "Да" || inputMessage == "да")
                {
                    return true;
                } 
                else if(inputMessage == "Нет" || inputMessage == "нет")
                {
                    return false;
                } 
                else
                {
                    Console.WriteLine("Введённый ответ некорректный!");
                    Console.Write("Есть ли у вас домашние питомцы? (Да / Нет): ");
                }
            }

        }
        static int GetUserAge()
        {
            Console.Write("Введите ваш возраст: ");

            while (true)
            {
                var inputMessage = Console.ReadLine();

                if(int.TryParse(inputMessage, out var number) && number > 0)
                {
                    return number;
                } 
                else
                {
                    Console.Write("Введённый возраст некорректный! Введите ваш возраст: ");
                }

            }
        }

        static string GetUserName()
        {
            Console.Write("Введите ваше имя: ");
            return Console.ReadLine();
        }

        static string GetUserSurname()
        {
            Console.Write("Введите вашу фамилию: ");
            return Console.ReadLine();
        }
    }
}
