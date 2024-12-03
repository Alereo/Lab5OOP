using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MullayarovLab5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Group_Mullayarov group = new Group_Mullayarov();
            string temp;
            int res;

            while (true)
            {
                funcs.Menu();
                temp = Console.ReadLine();

                try
                {
                    res = funcs.CheckInt(temp);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка ввода");
                    continue;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Ошибка ввода");
                    continue;
                }

                switch (res)
                {
                    case 1:
                        group.add_student();
                        break;
                    case 2:
                        group.add_headman(); 
                        break;
                    case 3:
                        group.PrintStudents();
                        break;
                    case 4:
                        group.PrintFileGroup();
                        break;
                    case 5:
                        group.ReadFileGroup();
                        break;
                    case 6:
                        group.DeleteGroup();
                        break;
                    case 0:
                        group.DeleteGroup();
                        return ;
                    default:
                        Console.WriteLine("Неверный ввод");
                        break;
                }
            }
        }
    }
}
