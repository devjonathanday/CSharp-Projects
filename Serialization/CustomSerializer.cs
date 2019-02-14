using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Serialization
{
    public class CustomSerializer
    {
        public string Serialize(object obj)
        {
            var myType = obj.GetType();
            IList<FieldInfo> fieldList = new List<FieldInfo>(myType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public));
            string output = "";
            foreach (var field in fieldList)
                output += field.Name + "=" + field.GetValue(obj) + "\n";
            return output;
        }
        public void SerializeToFile(object obj, string fileDir)
        {
            string dataToWrite = Serialize(obj);
            FileStream fs = new FileStream(fileDir, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);
            string[] lines = dataToWrite.Split('\n');
            for (int i = 0; i < lines.Length; i++)
                sw.Write(lines[i] + "\n");
            sw.Flush(); fs.Flush(); sw.Close(); fs.Close(); //Flushing and closing
        }
    }
}