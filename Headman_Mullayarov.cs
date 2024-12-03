using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MullayarovLab5
{
    [Serializable]
    public class Headman_Mullayarov : Student_Mullayarov
    {
        public string position { get; set; }
        public int amount_subjects { get; set; }
        public Headman_Mullayarov() { }

        public override void CreateStudent()
        {
            base.CreateStudent();

            string temp;

            Console.Write("Введите должность студента: ");
            temp = Console.ReadLine();
            position = funcs.CheckStr(temp);
            while (position == "Ошибка ввода строки")
            {
                Console.WriteLine(position);
                temp = Console.ReadLine();
                position = funcs.CheckStr(temp);
            }

            Console.Write("Введите количество учебных предметов: ");
            temp = Console.ReadLine();
            while (true)
            {
                try
                {
                    amount_subjects = funcs.CheckInt(temp);
                    if (amount_subjects <= 0)
                    {
                        throw new ArgumentException("Количество предметов должно быть больше 0.");
                    }
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Ошибка ввода: {ex.Message}");
                    Console.Write("Введите количество учебных предметов: ");
                    temp = Console.ReadLine();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка ввода: Неверный формат числа.");
                    Console.Write("Введите количество учебных предметов: ");
                    temp = Console.ReadLine();
                }
            }
        }
        public override void ShowStudent()
        {
            base.ShowStudent();
            Console.WriteLine($"Должность: {position}");
            Console.WriteLine($"Количество предметов: {amount_subjects}");
        }
    }
}
