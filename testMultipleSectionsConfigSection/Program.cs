using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testMultipleSectionsConfiguration
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConfigurationSectionGroup myCustomConfig = config.SectionGroups["MyCustomConfig"];
            foreach (ConfigurationSection section in myCustomConfig.Sections)
            {
                NameValueCollection sectionSettings = ConfigurationManager.GetSection(section.SectionInformation.SectionName) as NameValueCollection;
                foreach (string item in sectionSettings)
                {
                    var value = sectionSettings[item];
                    Console.WriteLine($"{ section.SectionInformation.Name } => { item } : { value }");
                }
            }
            Console.WriteLine("Press any key to conetinue...");
            Console.ReadKey();
        }
    }
}
