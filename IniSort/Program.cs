using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IniSort
{
    class Program
    {        
        static void Main(string[] args)
        {
            //Console.WriteLine("Введите директорию расположения *.ini файла для сортировки");
            //string pathToFile = Console.ReadLine();
            //Console.WriteLine("Введите имя *.ini файла для сортировки");
            //string nameFile = Console.ReadLine();
            string pathToFile = "TestIni/testIni.ini";
            if (FileToCollection.TryGetCollection(pathToFile, out var CollectionResult))
            {                
                CollectionResult.Sort();
                foreach (var section in CollectionResult)
                {
                    section.ListValue.Sort();
                }
                CollectionToFile.GetIniFile(CollectionResult, pathToFile);
            }


        }
    }
}
