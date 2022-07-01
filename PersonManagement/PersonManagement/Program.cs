using System;
using System.Collections.Generic;

namespace PersonManagement
{
    internal class Program
    {

        public static List<Person> persons { get; set; } = new List<Person>();

        static void Main(string[] args)
        {



            Console.WriteLine("Our available commands :");
            Console.WriteLine("/add-new-person");
            Console.WriteLine("/remove-person-by-fin");
            Console.WriteLine("/show-persons");
            Console.WriteLine("/exit");
            Console.WriteLine("/remove-all-persons");
            Console.WriteLine("/remove-by-ID");

            while (true)
            {
                Console.WriteLine();
                Console.Write("Enter command : ");
                string command = Console.ReadLine();

                if (command == "/add-new-person")
                {
                    Console.Write("Please add person's name :");
                    string name = Console.ReadLine();

                    Console.Write("Please add person's surname :");
                    string lastName = Console.ReadLine();

                    Console.Write("Please add person's FIN code :");
                    string fin = Console.ReadLine();

                    Person person = new Person(name, lastName, fin);
                    persons.Add(person);

                    Console.WriteLine(person.GetInfo() + " - Added to system.");

                }
                else if (command == "/remove-person-by-fin")
                {
                    Console.Write("To remove person, please enter his/her FIN code : ");
                    string fin = Console.ReadLine();
                    for (int i = 0; i < persons.Count; i++)
                    {
                        if (persons[i].FIN == fin)
                        {
                            Console.WriteLine(persons[i].GetInfo());
                            persons.RemoveAt(i);
                            Console.WriteLine("Person removed successfully");
                        }
                    }

                }
                else if (command == "/remove-all-persons")
                {
                    for (int i = persons.Count - 1; i >= 0; i--)
                    {
                        persons.RemoveAt(i);

                    }

                }
                else if (command == "/remove-by-ID")
                {
                    Console.Write("To remove person, please enter his/her ID code : ");
                    uint id =Convert.ToUInt32(Console.ReadLine());
                    for (int i = 0; i < persons.Count; i++)
                    {
                        if (persons[i].ID == id)
                        {                         
                            persons.RemoveAt(i);
                            Console.WriteLine("Person removed successfully");
                        }
                    }
                }
                else if (command == "/show-persons")
                {
                    Console.WriteLine("Persons in database : ");
                    foreach (Person person in persons)
                    {
                        Console.WriteLine(person.GetInfo());
                    }
                }
                else if (command == "/exit")
                {
                    Console.WriteLine("Thanks for using our application!");
                    break;
                }
                else
                {
                    Console.WriteLine("Command not found, please enter command from list!");
                    Console.WriteLine();
                }
            }
        }
        public static void GetAddedPerson(string name, string lastName, string fin)
        {
            Person person = new Person(name, lastName, fin);
            persons.Add(person);
        }

    }

    class Person
    {
        private static uint CounterID = 1;
        public uint ID { get; private set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FIN { get; set; }

        public Person(string name, string lastName, string fin)
        {
            Name = name;
            LastName = lastName;
            FIN = fin;
            ID = CounterID++;
        }

        public string GetFullName()
        {
            return Name + " " + LastName;
        }

        public string GetInfo()
        {
            return ID + " " + Name + " " + LastName + " " + FIN;
        }


    }
}
