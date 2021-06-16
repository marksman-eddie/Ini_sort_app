using System;
using System.Collections.Generic;
namespace IniSort
{
    public class IniSectionModel:IComparable<IniSectionModel>
    {
        public string Name { get; set; }
        public List<IniValueModel> ListValue { get; set; } = new List<IniValueModel>();

        public int CompareTo(IniSectionModel section)
        {
            return this.Name.CompareTo(section.Name); 
        }
    }
}
