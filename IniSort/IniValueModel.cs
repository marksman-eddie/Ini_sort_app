using System;
namespace IniSort
{
    public class IniValueModel:IComparable<IniValueModel>
    {
        public string NameValue { get; set; }

        public int CompareTo(IniValueModel value)
        {
            return this.NameValue.CompareTo(value.NameValue);
        }
    }
}
