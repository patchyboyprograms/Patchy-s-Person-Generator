using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Linq;

class Person
{
    public string title { get; set; } = "";
    public string name { get; set; } = "";
    public string dob { get; set; } = "";
    public string phone { get; set; } = "";
    public string ssn { get; set; } = "";
    public string blood { get; set; } = "";
    public string height { get; set; } = "";
    public string weight { get; set; } = "";
    public ConsoleColor color { get; set; } = ConsoleColor.White;
}

class personGenerator
{
    static Random numberGen = new Random();
    static List<Person> savedPeople = new List<Person>();
    static List<Person> specialPeople = new List<Person>()
    {
        new Person()
        {
            name = "Jesus Christ II",
            dob = "December 26, 2000",
            phone = "(666)-REA-LGOD",
            ssn = "JC2-69-LOLZ",
            height = "God height, like in space",
            weight = "0 pounds",
            blood = "Rhnull",
            color = ConsoleColor.Yellow
        },
        new Person()
        {
            name = "Glorpius Maximus",
            dob = "March 20, 863",
            phone = "(863)-MAX-1337",
            ssn = "GLOR-PI-US0",
            height = "20 foot, 13 inches",
            weight = "1,337 pounds",
            blood = "ABO+-",
            color = ConsoleColor.DarkMagenta
        },
    };
    static Person currentPerson;
    static string spj = "savedPeople.json";

    static void StartMsg()
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("*PATCHY'S PERSON GENERATOR*");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Enter to generate a person. Backspace to end. 'S' to save. 'L' to load. 'Z' to delete.");
    }

    static void Main(string[] args)
    {
        LoadFromFile();
        Console.Title = "Person Generator";
        StartMsg();

        bool cont = true;

        while (cont == true)
        {
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
            {
                PersonGen();
            }
            else if (key.Key == ConsoleKey.Backspace)
            {
                cont = false;
            }
            else if (key.Key == ConsoleKey.S)
            {
                Console.Clear();
                if (currentPerson == null)
                {
                    Console.WriteLine("You gotta generate a person first, bro. Jesus Christ.\n");
                    StartMsg();
                }
                else
                {
                    Console.Write($"Enter title to save {currentPerson.name} as: ");
                    string personTitle = Console.ReadLine();
                    if (savedPeople.Any(savedPerson => savedPerson.title == personTitle))
                    {
                        Console.WriteLine("This title already exists, you can't do that, man.");
                        StartMsg();
                    }
                    else if (string.IsNullOrWhiteSpace(personTitle))
                    {
                        Console.WriteLine("You gotta type something, guy.\n");
                        StartMsg();
                    }
                    else
                    {
                        currentPerson.title = personTitle;
                        Person savedPerson = currentPerson;
                        savedPeople.Add(savedPerson);
                        SaveToFile();

                        Console.WriteLine("Saved to your PC.\n");
                        StartMsg();
                    }
                }
            }
            else if (key.Key == ConsoleKey.L)
            {
                Console.Clear();
                ListSaved();

                Console.Write("\nEnter title to load: ");
                string personToLoad = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(personToLoad))
                {
                    Console.WriteLine("You gotta TYPE the title. Like actually enter the letters.\n");
                    StartMsg();
                }
                else
                {
                    Person loadedPerson = savedPeople.Find(savedPerson => savedPerson.title == personToLoad);
                    if (loadedPerson == null)
                    {
                        Console.WriteLine("That's not a valid title, man. The list is right above this >:(\n");
                        StartMsg();
                    }
                    else
                    {
                        Person specialMatch = specialPeople.Find(n => n.name == loadedPerson.name);
                        if (specialMatch != null)
                        {
                            Console.ForegroundColor = specialMatch.color;
                        }
                        
                        Console.WriteLine($"\nName:   {loadedPerson.name}\nDoB:    {loadedPerson.dob}\nPhone:  {loadedPerson.phone}\nSSN:    {loadedPerson.ssn}\nHeight: {loadedPerson.height}\nWeight: {loadedPerson.weight}\nBlood:  {loadedPerson.blood}\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        StartMsg();
                    }
                }
            }
            else if (key.Key == ConsoleKey.Z)
            {
                Console.Clear();
                ListSaved();

                Console.Write("\nEnter title to delete: ");
                string personToKill = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(personToKill))
                {
                    Console.WriteLine("You gotta TYPE the title. Like actually enter the letters.\n");
                    StartMsg();
                }
                else
                {
                    Person deadPerson = savedPeople.Find(savedPerson => savedPerson.title == personToKill);
                    if (deadPerson == null)
                    {
                        Console.WriteLine("That's not a valid title, man. The list is right above this >:(\n");
                        StartMsg();
                    }
                    else
                    {
                        savedPeople.Remove(deadPerson);
                        SaveToFile();

                        Console.WriteLine($"You have murdered {deadPerson.name}.\n");
                        StartMsg();
                    }
                }
            }
            else { }
        }
    }

    static void PersonGen()
    {
        int specialChance = numberGen.Next(0, 100);
        if (specialChance == 0)
        {
            Person special = specialPeople[numberGen.Next(specialPeople.Count)];

            Console.ForegroundColor = special.color;
            Console.WriteLine($"\nName:   {special.name}\nDoB:    {special.dob}\nPhone:  {special.phone}\nSSN:    {special.ssn}\nHeight: {special.height}\nWeight: {special.weight}\nBlood:  {special.blood}");
            Console.ForegroundColor = ConsoleColor.White;

            Person n = new Person();
            n.name = special.name;
            n.dob = special.dob;
            n.phone = special.phone;
            n.ssn = special.ssn;
            n.height = special.height;
            n.weight = special.weight;
            n.blood = special.blood;

            currentPerson = n;
        }
        else
        {
            string[] firstNameOptions = { "Feronius", "Jeremey", "Johnny", "Alien", "Salty", "Marmite", "Jackinator", "Fergie", "Terrence", "Foobles", "Jesussy", "Tameron", "Pearrick", "Samthony", "Jerb", "Dorito", "Baller", "Big", "Kilgore", "Serge", "Cumsock", "Lil'", "Goobie", "Unt", "Poggie", "Linguistin", "Napolon", "Zamboner", "Satan", "Waltah", "Poig", "Hummus", "Loo-key", "Bogan", "Karmic", "Jarvis", "Linus", "Bimbo", "Onkibent", "Nurmbul", "Scrumtuddle", "Larry", "Ankle", "Flurbie", "Markus", "Agent", "Zarbel", "Kim", "Dronald", "Querf", "Baby", "Patchy", "Lopsided", "Azula", "Mickey", "Baja", "Banana", "Pim", "Swedish", "Porkinator" };
            string[] lastNameOptions = { "Goobenstein", "Cashew", "McNutt", "Frederick", "Car", "Junjimun", "White", "Baldur", "Smithsonian", "Bird", "Hawk", "Dove", "Long", "Funkytown", "Sunch", "Vietnam", "Gunk", "Krunk", "Poe", "Xalgawrath", "Lump", "Reddit", "Unjewlateor", "Mildew", "Lagunbath", "Narmels", "Dunlavey", "Frazier", "Craig", "Hamilicious", "Xanax", "the Ejackulator", "Fanning", "Kirbs", "Tromp", "Munkihunk", "Loog", "Clapper", "Blast", "Reagun", "Prumple", "Boggles", "Forty-Seven", "Buchanan", "Vikavub", "Jones", "Williams", "Dom", "Deryl", "Curdle", "Boobies", "Honkledonkledoo", "Jong-Oon", "Italy", "Teletubbie", "Dildo", "Dompler", "Pimling", "Milkertonishkovski", "Fish" };
            string[] monthOptions = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            string[] bloodTypeOptions = { "O-", "O+", "B-", "B+", "A-", "A+", "AB-", "AB+" };

            int firstNameIndex = numberGen.Next(firstNameOptions.Length);
            int lastNameIndex = numberGen.Next(lastNameOptions.Length);
            int monthIndex = numberGen.Next(monthOptions.Length);
            int bloodTypeIndex = numberGen.Next(bloodTypeOptions.Length);

            string firstName = firstNameOptions[firstNameIndex];
            string lastName = lastNameOptions[lastNameIndex];
            string month = monthOptions[monthIndex];
            string blood = bloodTypeOptions[bloodTypeIndex];

            int day = numberGen.Next(1, 32);
            int year = numberGen.Next(1925, 2009);
            int phac = numberGen.Next(100, 1000);
            int ph1 = numberGen.Next(0, 1000);
            int ph2 = numberGen.Next(0, 10000);
            int ssac = numberGen.Next(0, 1000);
            int ss1 = numberGen.Next(0, 100);
            int ss2 = numberGen.Next(0, 10000);
            int ft = numberGen.Next(3, 8);
            int inc = numberGen.Next(1, 13);
            int lbs = numberGen.Next(60, 251);

            if ((month == "February") && (day > 28))
            {
                day = 28;
            }
            if ((month == "April" || month == "June" || month == "September" || month == "November") && (day > 30))
            {
                day = 30;
            }
            if (inc > 11)
            {
                ft += 1;
                inc = 0;
            }

            string name = $"{firstName} {lastName}";
            string phone = $"({phac})-{ph1:D3}-{ph2:D4}";
            string dob = $"{month} {day}, {year}";
            string ssn = $"{ssac:D3}-{ss1:D2}-{ss2:D4}";
            string height = $"{ft} foot, {inc} inches";
            string weight = $"{lbs} pounds";

            Console.WriteLine($"\nName:   {name}\nDoB:    {dob}\nPhone:  {phone}\nSSN:    {ssn}\nHeight: {height}\nWeight: {weight}\nBlood:  {blood}");

            Person n = new Person();
            n.name = name;
            n.dob = dob;
            n.phone = phone;
            n.ssn = ssn;
            n.height = height;
            n.weight = weight;
            n.blood = blood;

            currentPerson = n;
        }
    }

    static void SaveToFile()
    {
        string json = JsonSerializer.Serialize(savedPeople);
        File.WriteAllText(spj, json);
    }

    static void LoadFromFile()
    {
        if (File.Exists(spj))
        {
            string json = File.ReadAllText(spj);
            savedPeople = JsonSerializer.Deserialize<List<Person>>(json);
        }
    }
    
    static void ListSaved()
    {
        Console.WriteLine("Saved:");
        foreach (Person savedPerson in savedPeople)
        {
            Console.WriteLine(savedPerson.title);
        }
    }
}
