using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IniSort
{
    public class CollectionToFile
    {
        public CollectionToFile()
        {
        }
        public static void GetIniFile(List<IniSectionModel> listSection,string path)
        {
            var outputFilePath=path.Replace(".ini", $"_sorted_{DateTime.Now.ToShortTimeString()}.ini");
            StreamWriter write = new StreamWriter($"{outputFilePath}", false, Encoding.Default);
            foreach(var section in listSection)
            {
                write.WriteLine($"[{section.Name}]");
                foreach(var parameter in section.ListValue)
                {
                    write.WriteLine($"{parameter.NameValue}");
                }
            }
            write.Close();
            
            Console.WriteLine($"Создан сортированный файл: {outputFilePath}");
            Console.ReadLine();
        }
    }
}
