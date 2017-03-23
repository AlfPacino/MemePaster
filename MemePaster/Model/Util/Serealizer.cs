using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace MemePaster.Model
{
    public static class Serealizer
    {
        public static void SaveSettings(Settings settings, string fileName)
        {
            using (Stream writer = new FileStream(fileName, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                serializer.Serialize(writer, settings);
            }
        }
        public static Settings OpenSettings(string fileName)
        {
            var settings = new Settings();
            using (Stream writer = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                settings = (Settings)serializer.Deserialize(writer);
            }
            return settings;
        }
    }
}
