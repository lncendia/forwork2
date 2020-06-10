using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work
{
    class users
    {
        public string name;
        public string id;
        public int age;
        public List<string> infected = new List<string>();
        public users(string id, string name, string age)
        {
            this.name = name;
            this.age = Convert.ToInt32(age);
            this.id = id;
            Console.WriteLine($"ID: {id}, имя: {name}, возраст: {age}.");
        }
    }
}
