using System;
using System.Globalization;
using System.Text.RegularExpressions;

public class funcs
{
    public static int CheckInt(string str)
    {
        if (str.IndexOf('.') != -1)
        {
            Console.WriteLine("Ошибка ввода строки");
            return 0;
        }
        else
        {
            return int.Parse(str);
        }
    }

    public static double CheckDouble(string str)
    {
        return double.Parse(str, CultureInfo.InvariantCulture);
    }

    public static string CheckStr(string str)
    {
        if (str.IndexOf('/') != -1 || str.IndexOf('.') != -1 || Regex.IsMatch(str, "[0-9]"))
        {
            return "Ошибка ввода строки";
        }
        else
        {
            return str;
        }
    }

    public static void Menu()
    {
        Console.WriteLine("1)Добавить студента");
        Console.WriteLine("2)Добавить студента с должностью");
        Console.WriteLine("3)Вывод студентов группы");
        Console.WriteLine("4)Вывод студентов группы в файл");
        Console.WriteLine("5)Ввод студентов из файла");
        Console.WriteLine("6)Очистка списка студентов");
        Console.WriteLine("0)Выход");
    }
}