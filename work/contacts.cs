using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work
{
    class contacts
    {
        public DateTime from;
        public DateTime to;
        public string ID1;
        public string ID2;
        public TimeSpan difference;
        public contacts(string from, string to, string ID1, string ID2)
        {
            this.from = DateTime.Parse(from);
            this.to = DateTime.Parse(to);
            this.ID1 = ID1;
            this.ID2 = ID2;
            difference = this.to.Subtract(this.from);
            Console.WriteLine($"Контакт между ID {ID1} и ID {ID2}, продлившийся {difference.ToString()} минут(ы), проходившикй с {from.ToString()} до {to.ToString()}");
        }
        public string returnValue()
        {
            return $"Контакт между ID {ID1} и ID {ID2}, продлившийся {difference.ToString()} минут(ы), проходившикй с {from.ToString()} до {to.ToString()}";
        }
    }
}
