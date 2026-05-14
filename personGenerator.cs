using System;

class personGenerator
{
    static Random numberGen = new Random();

    static void Main(string[] args)
    {
        Console.Title = "Person Generator";
        Console.WriteLine("Press Enter to generate a person. Press Backspace to end.\n");

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
            else { }
        }
    }

    static void PersonGen()
    {
        string[] firstNameOptions = { "Glorpus","Jeremey","Johnny","Alien","Salty","Marmite","Jackinator","Fergie","Terrence","Foobles","Jesussy","Tameron","Pearrick","Samthony","Jerb","Dorito","Baller","Big","Kilgore","Serge","Cumsock","Lil'","Goobie","Unt","Poggies","Linguistin","Napolon","Zamboner","Satan","Waltah","Poig","Hummus" };
        string[] lastNameOptions = { "Goobenstein","Cashew","McNutt","Frederick","Car","Junjimun","White","Baldur","Smithsonian","Bird","Hawk","Dove","Long","Funkytown","Sunch","Vietnam","Gunk","Krunk","Poe","Xalgawrath","Lump","Reddit","Unjewlateor","Mildew","Lagunbath","Narmels","Dunlavey","Frazier","Craig","Hamilicious","Xanax","the Ejackulator" };
        string[] monthOptions = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        int firstNameIndex = numberGen.Next(firstNameOptions.Length);
        int lastNameIndex = numberGen.Next(lastNameOptions.Length);
        int monthIndex = numberGen.Next(monthOptions.Length);
    
        string firstName = firstNameOptions[firstNameIndex];
        string lastName = lastNameOptions[lastNameIndex];
        string month = monthOptions[monthIndex];
        int day = numberGen.Next(1, 32);
        int year = numberGen.Next(1925, 2009);
        int phac = numberGen.Next(100, 1000);
        int ph1 = numberGen.Next(0, 1000);
        int ph2 = numberGen.Next(0, 10000);
        int ssac = numberGen.Next(0, 1000);
        int ss1 = numberGen.Next(0, 100);
        int ss2 = numberGen.Next(0, 10000);

        if (month == "February" && (day > 28))
        {
            day = 28;
        }
        if ((month == "April" || month == "June" || month == "September" || month == "November") && day > 30)
        {
            day = 30;
        }
        
        string name = $"{firstName} {lastName}";
        string phone = $"({phac})-{ph1:D3}-{ph2:D4}";
        string dob = $"{month} {day}, {year}";
        string ssn = $"{ssac:D3}-{ss1:D2}-{ss2:D4}";

        Console.WriteLine($"Name:  {name}\nDoB:   {dob}\nPhone: {phone}\nSSN:   {ssn}\n");
    }
}