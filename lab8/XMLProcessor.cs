using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab8
{
    internal static class XMLProcessor
    {
        public static void SaveXML(List<ColorEntry> colors, string filename)
        {
            XElement palette = new XElement("Palette");
            for (int i = 0; i < colors.Count; i++)
            {
                XElement color = new XElement("Color",
                    new XAttribute("id", i),
                    new XElement("RAL", colors[i].id),
                    new XElement("HEX", $"#{colors[i].color.R:X2}{colors[i].color.G:X2}{colors[i].color.B:X2}"),
                    new XElement("RGB", $"({colors[i].color.R},{colors[i].color.G},{colors[i].color.B})")
                    );
                palette.Add(color);
            }
            palette.Save(filename);
        }
        public static List<ColorEntry> LoadXML(string filename)
        {
            List<ColorEntry> colors = new List<ColorEntry>();
            var palette = XElement.Load(filename);
            var colors_xml = palette.Elements("Color");
            foreach ( XElement color_xml in colors_xml)
            {
                colors.Add(new ColorEntry(ColorTranslator.FromHtml((string)color_xml.Element("HEX")), int.Parse((string)color_xml.Element("RAL"))));
            }
            return colors;
        }
    }
}
