using Newtonsoft.Json;
using System;
using System.Numerics;
using System.Xml.Serialization;
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
            Console.WriteLine(File.ReadAllText(path));
            List<string> my_file = new List<string>();
            string b = string.Join(", ", File.ReadAllText(path));

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

                File.Create(save).Close();
                File.WriteAllText(save, JsonConvert.SerializeObject(b));
            }
            else if (save.Contains(".txt")) 
            {
                File.WriteAllText(save, b);
            }
            else if (save.Contains(".xml"))
            {
                ForXml xml_class = new ForXml();
                xml_class.text = b;
                XmlSerializer a = new XmlSerializer(typeof(ForXml));
                using (FileStream peremennaia = new FileStream(save, FileMode.OpenOrCreate))
                {
                    a.Serialize(peremennaia, xml_class);
                }       
            }

        }

    }
}