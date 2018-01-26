using System;
using System.Collections.Generic;
using System.Text;

namespace StaffOrder.Infrastructure.Configurations.ConfigModels
{
    public class AppSettings
    {
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string ApplicationTitle { get; set; }
        public string StringSetting { get; set; }
        public int IntSetting { get; set; }
        public Dictionary<string, MyClass> DictSetting { get; set; } // Dictionaries must have string keys
        public IEnumerable<string> ListOfValues { get; set; }
        public MyEnum AnEnumSwitch { get; set; }

    }

    public class MyClass
    {
        public string Name { get; set; }
        public bool IsEnabled { get; set; } = true;
    }

    public enum MyEnum
    {
        Off = 0,
        On = 1
    }
}
