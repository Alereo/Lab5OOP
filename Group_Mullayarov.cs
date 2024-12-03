using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MullayarovLab5
{
    [Serializable]
    [XmlType("Group_Mullayarov")]
    internal class Group_Mullayarov
    {
        List<Student_Mullayarov> students = new List<Student_Mullayarov>();
        public void add_student()
        {
            Student_Mullayarov student = new Student_Mullayarov();
            student.CreateStudent();
            students.Add(student);
        }

        public void add_headman()
        {
            Headman_Mullayarov headman = new Headman_Mullayarov();
            headman.CreateStudent();
            students.Add(headman);
        }
        public void PrintStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Нет студентов");
            }
            else
            {
                foreach (var student in students)
                {
                    student.ShowStudent(); 
                }
            }
        }

        public void DeleteGroup()
        {
            students.Clear();
        }


        public void PrintFileGroup()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Нет данных о студентах для сохранения.");
                return;
            }
            Console.WriteLine("Введите название файла: ");
            string filename = Console.ReadLine() + ".xml";
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            Type[] extraTypes = { typeof(Headman_Mullayarov) };
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student_Mullayarov>), extraTypes);
            using (StreamWriter writer = new StreamWriter(filename))
            {
                try
                {
                    serializer.Serialize(writer, students, ns);
                    Console.WriteLine("Данные были успешно сохранены в файл.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка сохранения данных: {ex.Message}");
                }
            }
        }

        public void ReadFileGroup()
        {
            Console.Write("Введите название файла: ");
            string filename = Console.ReadLine() + ".xml";
            DeleteGroup();
            Type[] extraTypes = { typeof(Headman_Mullayarov) };
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student_Mullayarov>), extraTypes);
            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    students = (List<Student_Mullayarov>)serializer.Deserialize(reader);
                }
                PrintStudents();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки данных: {ex.Message}");
            }
        }
    }
}
