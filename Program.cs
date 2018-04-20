using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvgScruber
{
    public class ScrubSvg
    {
        private static string DESKTOP_DIR = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        static void Main(string[] args)
        {
            // Loop through all SVG files in the Desktop directory
            // C:\Users\Levi\Desktop
            // Get current User from System
            var svgs = new DirectoryInfo(DESKTOP_DIR).GetFiles("*.svg");
            foreach (var svg in svgs)
            {
                var resultXmlDoc = new XmlDocument();

                var svgXml = new XmlDocument();
                svgXml.Load(svg.FullName);
                var viewbox = svgXml.DocumentElement.GetAttribute("viewbox");

                var symbol = resultXmlDoc.CreateElement("symbol");
                symbol.SetAttribute("id", Path.GetFileNameWithoutExtension(svg.FullName));
                symbol.SetAttribute("viewbox", "0 1 2");



                resultXmlDoc.AppendChild(symbol);

                var firstChild = svgXml.DocumentElement.FirstChild;


                resultXmlDoc.Save("test.xml");


            }


        }
    }
}
