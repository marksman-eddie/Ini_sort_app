using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
namespace IniSort
{
    public class FileToCollection
    {
       public static bool TryGetCollection(string path,out List<IniSectionModel> listSectionModel)
        {
            const string sectionPattern = @"^\[\w+]$";            
            const string paramPattern = @"^\w+=\S+$";
            IniSectionModel sectionName=null;
            int count = 0;
            listSectionModel = new List<IniSectionModel>();
            StreamReader streamRead=null;
            try
            {
                streamRead = new StreamReader(path, Encoding.Default);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }            
            while(!streamRead.EndOfStream)
            {
                count++;
                string row = streamRead.ReadLine();
                if(string.IsNullOrEmpty(row))
                {
                    continue;
                }

                if (Regex.IsMatch(row,sectionPattern,RegexOptions.IgnoreCase))
                {
                    IniSectionModel section = new IniSectionModel() {                    
                        Name = row.Trim(new char[] { ' ', '[', ']' })
                    };
                    listSectionModel.Add(section);
                    sectionName = section;
                    continue;
                }
                if (Regex.IsMatch(row, paramPattern, RegexOptions.IgnoreCase))
                {                    
                    sectionName.ListValue.Add(new IniValueModel { NameValue=row });
                    continue;
                }
                Console.WriteLine($"Некорректный формат строки. строка должна быть формата '[section]' либо 'param=value'.Комментарии и любые другие строки исключены.Так же исключены параметры БЕЗ секции ");
                Console.WriteLine($"некорректное значение: {row} ");
                Console.WriteLine($"номер строки с ошибкой: {count} ");
                Console.ReadLine();
                streamRead.Close();
                return false;                
            }
            streamRead.Close();
            return true;
        }
    }
}
