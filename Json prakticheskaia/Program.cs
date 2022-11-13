using Newtonsoft.Json;
using System;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

namespace Json_prakticheskaia
{
    internal class Program
    {
        string path;
        static ConsoleKeyInfo key;
        static void Main(string[] args)
        {
            path_input();
        }
        static void path_input()
        {
            Console.WriteLine("Ведите путь до файла вместе с названием, который вы хотите открыть");
            string path = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Созранить файл в одном из 3 форматов (txt, json, xml) - F1. Закрыть программу - Escape");
            List<string> my_file = new List<string>();
            string read = Convert.ToString(File.ReadAllText(path));
            Console.WriteLine(read);
            string b = string.Join(", ", read);

            Console.WriteLine(b);

            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.F1)
            {
                Console.Clear();
                save_file(key, my_file, path, b);
            }
            else if (key.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                Console.WriteLine();
                Console.ReadLine();
            }
        }
        /*    
        static void edit_file(string path)
        {
            int position = 2;
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.DownArrow)
                {
                    position++;
                    if (position > 8)
                    {
                        position = 8;
                    }
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    position--;
                    if (position < 2)
                    {
                        position = 2;
                    }
                }
                Console.Clear();
                open_file(path);
                Console.SetCursorPosition(0, position);
                Console.Write("->");
            }
        }*/
        static void save_file(ConsoleKeyInfo key, List<string> my_file, string path, string b)
        {

            Console.WriteLine("Ведите путь до файла вместе с названием, куда вы хотите сохранить");
            string save = Console.ReadLine();
            if (save.Contains(".json"))
            {
                ForJson JSON = new ForJson();
                List<ForJson> forjson = new List<ForJson>();
                string json = JsonConvert.SerializeObject(b);
                File.Create(save).Close();
                File.WriteAllText(save, json);
            }
            else if (save.Contains(".txt")) 
            {
                string txt = Convert.ToString(my_file);
                File.WriteAllText("path", txt);
            }
            else if (save.Contains(".xml"))
            {
                string txt = Convert.ToString(my_file);
                File.WriteAllText("path", txt);
            }

        }
/*        public Class1[] class1s()
        {
            Class1 rectangle = new Class1();
            rectangle.name = "Прямоугольник";
            rectangle.Wigth = 45;
            rectangle.Heigth = 11;

            Class1 square = new Class1();
            square.name = "Квадрат";
            square.Wigth = 15;
            square.Heigth = 15;

            Class1 rectangle2 = new Class1();
            rectangle2.name = "Прямоугольник";
            rectangle2.Wigth = 13;
            rectangle2.Heigth = 17;

            List<Class1> figures = new List<Class1>();
            figures.Add(rectangle);
            figures.Add(square);
            figures.Add(rectangle2);
            return List <> Class1 > ;
        }*/
    }
}