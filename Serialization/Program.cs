using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Serialization
{
    class Program
    {
        public struct SampleEnemy
        {
            public string name;
            public float health;
            public float maxHealth;
            public float gold;
            public bool isRare;

            public SampleEnemy(string _name, float _health, float _maxHealth, float _gold, bool _isRare)
            {
                name = _name;
                health = _health;
                maxHealth = _maxHealth;
                gold = _gold;
                isRare = _isRare;
            }
        }
        static void Main(string[] args)
        {
            SampleEnemy enemy = new SampleEnemy("Jongor", 5, 10, 100, true);

            string workingDir = Directory.GetCurrentDirectory();
            string fileDir = workingDir + "\\testTextFile.txt";

            CustomSerializer serializer = new CustomSerializer();
            Console.WriteLine(serializer.Serialize(enemy));
            serializer.SerializeToFile(enemy, fileDir);
            Console.ReadKey();
        }

    }
}
