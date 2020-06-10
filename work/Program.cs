using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace work
{
    class Program
    {
        static List<users> usersList = new List<users>();
        static List <contacts> contactsList = new List<contacts>();
        static void writeContacts()
        {
            try
            {
                Console.WriteLine("Выборка контактов.");
                Console.WriteLine("Начиная с:");
                DateTime from = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("До:");
                DateTime to = DateTime.Parse(Console.ReadLine());
                for (int i = 0; i < contactsList.Count; i++)
                {
                    if (contactsList[i].from.CompareTo(from) >= 0 && contactsList[i].to.CompareTo(to) <= 0 && contactsList[i].difference.TotalMinutes > 10)
                    {
                        Console.WriteLine();
                        Console.WriteLine(contactsList[i].returnValue());
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
        static int count = 0;
        static int countDays_;
        static int countDaysofInfection_;
        static int max;
        static void infected()
        {
            try
            {
                Console.WriteLine("Введите ID нулевого зараженного:");
                string id = Console.ReadLine();
                Console.WriteLine("Введите дату заражения (DD/MM/YYYY hh:mm:ss):");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Введите длительность контакта, при которой происходит заражение:");
                int timeOfContact = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Способность к передаче вируса другому человеку появляется через (дней):");
                int countDays = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Сколько дней вирус будет передаваться:");
                int countDaysOfInfection = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Сколько будет длиться иммунитет (дней):");
                int countDaysOfImunitet = Convert.ToInt32(Console.ReadLine());
                List<infection> infections = new List<infection>();
                infections.Add(new infection(id, date, new DateTime(0), "0"));
                allinfected.Add(new infection(id, date, new DateTime(0), "0"));
                count = 1;
                str = "";
                countDays_ = countDays;
                countDaysofInfection_ = countDaysOfInfection;
                max = 0;
                writeInfected(infections, timeOfContact, countDays, countDaysOfInfection, countDaysOfImunitet);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
        static List<infection> allinfected = new List<infection>();
        static string str = "";
        static void writeInfected(List<infection> infections, int timeOfContact, int countDays, int countDaysOfInfection, int countDaysOfImunitet)
        {
            foreach (infection inf in infections)
            {
                Console.WriteLine(inf.ToString());
                str+=(inf.ToString()) + "\n";
            }
            int co = infections.Count();
            Console.WriteLine("                       ||");
            Console.WriteLine("                       ||");
            Console.WriteLine("                       \\/");
            str += ("                       ||") +"\n";
            str+= ("                       ||") + "\n";
            str +=("                       \\/") + "\n";
            for (int z = 0; z < co; z++)
            {
                DateTime date_d = infections[z].date.AddDays(countDays);
                DateTime dateTo_d = DateTime.Parse(date_d.ToString()).AddDays(countDaysOfInfection);
                for (int i = 0; i < contactsList.Count; i++)
                {
                    if (contactsList[i].from.CompareTo(date_d) >= 0 && contactsList[i].from.CompareTo(dateTo_d) <= 0)
                    {
                        if (contactsList[i].ID1 == infections[z].id && contactsList[i].difference.TotalMinutes > timeOfContact)
                        {
                            DateTime date1 = DateTime.Parse(contactsList[i].from.ToString()).AddMinutes(timeOfContact);
                            if (date1.CompareTo(searchID(contactsList[i].ID2)) > 0)
                            {
                                count++;
                                infections.Add(new infection(contactsList[i].ID2, date1, date1.AddDays(countDaysOfImunitet + countDaysOfInfection + countDays), infections[z].id));
                                allinfected.Add(new infection(contactsList[i].ID2, date1, date1.AddDays(countDaysOfImunitet + countDaysOfInfection + countDays), infections[z].id));

                            }
                            else
                            {
                                //Console.WriteLine($" У {contactsList[i].ID2} иммунитет, который закончиться {searchID(contactsList[i].ID2).ToString()}. Пытаются его заразить {date1.ToString()} ID {infections[z].id}");
                                //str +=($" У {contactsList[i].ID2} иммунитет. Который закончиться {searchID(contactsList[i].ID2).ToString()}. Пытаются его заразить {date1.ToString()} ID {infections[z].id}")+"\n";
                            }
                        }
                        if (contactsList[i].ID2 == infections[z].id && contactsList[i].difference.TotalMinutes > timeOfContact)
                        {
                            DateTime date1 = DateTime.Parse(contactsList[i].from.ToString()).AddMinutes(timeOfContact);
                            if (date1.CompareTo(searchID(contactsList[i].ID1)) > 0)
                            {

                                count++;
                                infections.Add(new infection(contactsList[i].ID1, date1, date1.AddDays(countDaysOfImunitet + countDaysOfInfection + countDays), infections[z].id));
                                allinfected.Add(new infection(contactsList[i].ID1, date1, date1.AddDays(countDaysOfImunitet + countDaysOfInfection + countDays), infections[z].id));
                            }
                            else
                            {
                                //Console.WriteLine($" У {contactsList[i].ID1} иммунитет. Который закончиться {searchID(contactsList[i].ID1).ToString()}. Пытаются его заразить {date1.ToString()} ID {infections[z].id}");
                                //str +=($" У {contactsList[i].ID1} иммунитет. Который закончиться {searchID(contactsList[i].ID1).ToString()}. Пытаются его заразить {date1.ToString()} ID {infections[z].id}")+ "\n";
                            }
                        }
                    }
                }
            }
            for(int i = 0; i<co; i++)
            {
                infections.RemoveAt(0);
            }
            if (infections.Count > max) max = infections.Count();
            if (infections.Count > 0)
                writeInfected(infections, timeOfContact, countDays, countDaysOfInfection, countDaysOfImunitet);
            else
            {
                str += "Болезнь повержена! \n";
                Console.WriteLine("Болезнь повержена!");
            }
        }
        static DateTime searchID(string id)
        {
            for(int i = allinfected.Count-1; i >=0; i--)
            {
                if (id == allinfected[i].id) return allinfected[i].immunitet;
            }
            return new DateTime(0);
        }
        static void Main(string[] args)
        {
            XmlDocument xml = new XmlDocument();
            while (true)
            {
                Console.WriteLine("\n1 - \"big_data.xml\"\n2 - \"small_data.xml\"\nВведите цифру:");
                string z = Console.ReadLine();
                if (z == "1")
                {
                    xml.Load("big_data.xml");
                    break;
                }
                else if (z == "2")
                {
                    xml.Load("small_data.xml");
                    break;
                }
                else
                {
                    Console.WriteLine("Неверное значение.");
                }
            }
            XmlElement xRoot = xml.DocumentElement;
            double age = 0;
            foreach (XmlNode node in xRoot)
            {
                if (node.Name == "Persons")
                {
                    foreach (XmlNode child in node.ChildNodes)
                    {
                        usersList.Add(new users(child.ChildNodes.Item(0).InnerText, child.ChildNodes.Item(1).InnerText, child.ChildNodes.Item(2).InnerText));
                    }
                }
                if(node.Name == "Contacts")
                {
                    foreach (XmlNode child in node.ChildNodes)
                    {
                        contactsList.Add(new contacts(child.ChildNodes.Item(0).InnerText, child.ChildNodes.Item(1).InnerText, child.ChildNodes.Item(2).InnerText, child.ChildNodes.Item(3).InnerText));
                    }
                }
            }
            for(int i = 0; i < usersList.Count; i++)
            {
                age += usersList[i].age;
            }
            Console.WriteLine($"Средний возраст: {age/usersList.Count} лет.");
            while (true)
            {
                Console.WriteLine("\n1 - Выборка контактов \n2 - Запустить модель вируса \nВведите цифру:");
                string x = Console.ReadLine();
                if (x == "1")
                {
                    writeContacts();
                }
                else if (x == "2")
                {
                    infected();
                    Console.WriteLine($"Общее время болезни составило {count * (countDays_ + countDaysofInfection_)} человеко-часов. (Включая инкубационный период болезни)");
                    Console.WriteLine($"Людей заражено на пике эпидемии: {max}");
                    allinfected.Clear();
                    Console.WriteLine("Дерево заражений выгружено в файл \"infection.txt\" в корневой папке программы.");
                    File.WriteAllText("infection.txt", str);
                }
                else
                {
                    Console.WriteLine("Неверное значение.");
                    continue;
                }
            }
        }
    }
}
