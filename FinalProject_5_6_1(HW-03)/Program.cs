using System;

class UserData
{
    static void Main()
    {
        var user = EnterUserInformation();
        DisplayUserData(user);
    }
    static (string Name, string SurName, int Age, bool HasPets, string[] PetNames, string[] ColorNames) EnterUserInformation()
    {
        (string Name, string SurName, int Age, bool HasPets, string[] PetNames, string[] ColorNames) User;

        Console.WriteLine("Введите Имя:");
        User.Name = Console.ReadLine();

        Console.WriteLine("Введите Фамилию:");
        User.SurName = Console.ReadLine();

        string ageInput;
        int age;
        do
        {
            Console.WriteLine("Введите возраст цифрами:");
            ageInput = Console.ReadLine();
        } 
        while (!CheckNum(ageInput, out age));

        User.Age = age;
                       
        string answer;
        do
        {
            Console.WriteLine("Есть ли у вас питомцы? (да/нет):");
            answer = Console.ReadLine().ToLower();
        } 
        while (answer != "да" && answer != "нет");

        if (answer == "да")
        {
            User.HasPets = true;
        }
        else
        {
            User.HasPets = false;
        }

        if (User.HasPets)
        {
            int numberOfPets;
            do
            {
                Console.WriteLine("Введите количество питомцев:");
            } while (!CheckNum(Console.ReadLine(), out numberOfPets));

            
           User.PetNames = new string[numberOfPets];
                for (int i = 0; i < numberOfPets; i++)
                {
                    Console.WriteLine("Введите кличку питомца номер {0} :", i + 1);
                    User.PetNames[i] = Console.ReadLine();
                }
                           
        }
        else
        {
            User.PetNames = new string[0]; // Если нет питомцев, создаем пустой массив
        }

        int numberOfColors;
        do
        {
            Console.WriteLine("Введите количество любимых цветов:");
        } while (!CheckNum(Console.ReadLine(), out numberOfColors));

        
        User.ColorNames = new string[numberOfColors];

        for (int i = 0; i < numberOfColors; i++)
        {
            Console.WriteLine("Введите любимый цвет номер {0} :", i + 1);
            User.ColorNames[i] = Console.ReadLine();
        }
        
        return User;
    }

    static bool CheckNum(string input, out int result)
    {
        if (int.TryParse(input, out result) && result > 0)
        {
            return true;
        }
        else
        {
            Console.WriteLine("Введите положительное число цифрами выше 0!!");
            return false;
        }
    }
    static void DisplayUserData((string Name, string surName, int Age, bool haspet, string[] PetName, string[] favcolors) userData)
    {
        Console.WriteLine("Информация о пользователе:");
        Console.WriteLine("Имя: {0}", userData.Name);
        Console.WriteLine("Фамилия: {0}", userData.surName);
        Console.WriteLine("Возраст: {0}", userData.Age);
        Console.WriteLine("Наличие питомца: {0}", userData.haspet);

        if (userData.haspet)
        {
            Console.WriteLine("Имена питомцев:");
            foreach (var petName in userData.PetName)
            {
                Console.WriteLine(petName);
            }
        }

        Console.WriteLine("Любимые цвета:");
        foreach (var color in userData.favcolors)
        {
            Console.WriteLine(color);
        }
    }

}