using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MullayarovLab5
{
    [Serializable]
    [XmlInclude(typeof(Headman_Mullayarov))]
    public class Student_Mullayarov
    {
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public double mark { get; set; }
        public Student_Mullayarov() { }
        public virtual void CreateStudent()
        {
            string temp;

            Console.Write("Введите имя студента: ");
            temp = Console.ReadLine();
            name = funcs.CheckStr(temp);
            while (name == "Ошибка ввода строки")
            {
                Console.WriteLine(name);
                temp = Console.ReadLine();
                name = funcs.CheckStr(temp);
            }


            Console.Write("Введите фамилию студента: ");
            temp = Console.ReadLine();
            surname = funcs.CheckStr(temp);
            while (surname == "Ошибка ввода строки")
            {
                Console.WriteLine(surname);
                temp = Console.ReadLine();
                surname = funcs.CheckStr(temp);
            }


            Console.Write("Введите возраст: ");
            temp = Console.ReadLine();
            while (true)
            {
                try
                {
                    age = funcs.CheckInt(temp);
                    if (age < 18)
                    {
                        throw new ArgumentException("Возраст должен быть не меньше 18 лет.");
                    }
                    break; 
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Ошибка ввода: {ex.Message}");
                    Console.Write("Введите возраст: ");
                    temp = Console.ReadLine();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка ввода: Неверный формат возраста.");
                    Console.Write("Введите возраст: ");
                    temp = Console.ReadLine();
                }
            }

            Console.Write("Введите среднюю оценку: ");
            temp = Console.ReadLine();
            while (true)
            {
                try
                {
                    mark = funcs.CheckDouble(temp);
                    if (mark < 0.0 || mark > 5.0)
                    {
                        throw new ArgumentException("Оценка должна быть в диапазоне от 0.0 до 5.0.");
                    }
                    break; 
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Ошибка ввода: {ex.Message}");
                    Console.Write("Введите среднюю оценку: ");
                    temp = Console.ReadLine();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка ввода: Неверный формат оценки.");
                    Console.Write("Введите среднюю оценку: ");
                    temp = Console.ReadLine();
                }
            }
        }
        public virtual void ShowStudent()
        {
            Console.WriteLine($"Имя студента: {name}");
            Console.WriteLine($"Фамилия студента: {surname}");
            Console.WriteLine($"Возраст студента: {age}");
            Console.WriteLine($"Средняя оценка студента: {mark}");
            
        }
    }
}
