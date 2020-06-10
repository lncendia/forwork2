using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work
{
    class infection
    {
        public string id;
        public string id_infected;
        public DateTime date;
        public DateTime immunitet;
        public infection(string id, DateTime date, DateTime immunitet, string id_infected)
        {
            this.id = id;
            this.date = date;
            this.immunitet = immunitet;
            this.id_infected = id_infected;
        }
        public override string ToString()
        {
            return $"ID {id_infected} заразил ID {id} в {date.ToString()}";
        }
    }
}
