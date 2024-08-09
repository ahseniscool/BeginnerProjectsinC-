/************************************************************************************************************************************************
AHSEN JAUHAR MAY 2024
- This was my first ever project using the c# language and any object orientated language in general
- Was a great learning experience, there are obciously quite a few conceptual errors with how classes and objects are used, in such a way where
the project almost seems like a blend of OOP and FP, nonetheless it was a very positive learnign experience
- This was my first time using any form of file storage for a program, was very useful as those skills have been used more in my Algorithms and Data strcutures 
class in sem 2 2024
- If I were to attempt this again I would reogranise alot of the classes to be more OOP based, as well as perhaps attempt to link this to a 
Blazor webapp so that I could produce a webpage.
************************************************************************************************************************************************/

using System;
using System.IO;
using System.Collections.Generic;

using System.Text.Json;
using System.Collections;
using System.Diagnostics;

namespace project
{

    class Program
    {
        static List<Phone> PhoneList = new List<Phone>();
        static string FilePath = @"/Users/ahsenjauhar/Coding/c#/JSON CLASSES.txt";

        private class Phone
        {

            public string Name { get; set; }
            public String Chip { get; set; }
            public string Size { get; set; }
            public int Storage { get; set; }
            public int Memory { get; set; }
            public int Price { get; set; }
            public int ReleaseYear { get; set; }
            public int Stock { get; set; }
            public string OS { get; set; }

            public Phone(string name, string chip, string size, int storage, int memory, int price, int releaseyear, int stock, string os)// contrusctor
            {
                Name = name;
                Chip = chip;
                Storage = storage;
                Memory = memory;
                Price = price;
                ReleaseYear = releaseyear;
                Stock = stock;
                OS = os;
            }
        }
        class Samsung : Phone
        {

            public string Manufacturer = "Samsung";
            public string OS = "Android";

            public Samsung(string name, string chip, string size, int storage, int memory, int price, int releaseyear, int stock,string os) :
                    base(name, chip, size, storage, memory, price, releaseyear, stock,os)
            {

            }
        }

        class Iphone : Phone
        {
            public string Manufacturer = "Apple";
            public string OS = "IOS";

            public Iphone(string name, string chip, string size, int storage, int memory, int price, int releaseyear, int stock,string os) :
                    base(name, chip, size, storage, memory, price, releaseyear, stock,os)
            {

            }
        }

        public static void deserialsier()
        {
            string JsonText = File.ReadAllText(FilePath);
            PhoneList = JsonSerializer.Deserialize<List<Phone>>(JsonText);
        }
        public static void reserailise()
        {
            string reserializedJson = JsonSerializer.Serialize(PhoneList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, reserializedJson);

        }
        static void Main()
        {
            deserialsier();

            while (true) // operations go here 
            {
                Console.WriteLine("\n\n-----------------------------");
                Console.WriteLine("Welcome to our online phone store");
                Console.WriteLine("Please select an option          ");
                Console.WriteLine("iPhones                       (1)");
                Console.WriteLine("Andorid Phones                (2)");
                Console.WriteLine("Search                        (3)");
                Console.WriteLine("Store Settings                (4)");
                Console.WriteLine("Exit                          (5)");
                int UserInput = int.Parse(Console.ReadLine());


                switch (UserInput)
                {
                    case 1:
                        IphoneList(PhoneList);
                        break;

                    case 2:
                        SamsungList(PhoneList);
                        break;

                    case 3:
                        PhoneFinder(PhoneList);
                        break;
                    case 4:
                        StoreSettings();
                        break;
                    case 5:
                        Console.WriteLine("Thank you for shopping with us\n");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option, try again\n");
                        break;

                }

            }

        }
        static void SamsungList(List<Phone> list)
        {
            Console.WriteLine("Avalible Android Phones");
            Console.WriteLine("Type the name of the phone of your choice");
            Console.WriteLine("-----------------------------------------");
            foreach (var Phone in list)
            {
                if ((Phone.OS).Contains("Android") )
                {
                    Console.WriteLine($"{Phone.Name}");
                }

            }

            int found = 0;

            string UserInput = Console.ReadLine();
            foreach (var Phone in list)
            {
                if (UserInput == Phone.Name)
                {
                    found = 1;
                    PrintSpecs(Phone);
                }
            }
            if (found == 0)
            {
                Console.WriteLine("Incorrect name entered");
                return;
            }
            return;


        }

        static void IphoneList(List<Phone> list)
        {


            Console.WriteLine("\n\n-------------------------------------");
            Console.WriteLine("Avalible iPhones");
            Console.WriteLine("Type the name of the phone of your choice");
            Console.WriteLine("-----------------------------------------");
            foreach (var Phone in list)
            {
                if ((Phone.Name).Contains("iPhone") || (Phone.OS).Contains("iOS") )
                {
                    Console.WriteLine($"{Phone.Name}");
                }

            }

            int found = 0;
            string UserInput = Console.ReadLine();


            foreach (var Phone in list)
            {
                if (UserInput == Phone.Name)
                {
                    found = 1;
                    PrintSpecs(Phone);
                }
            }

            if (found == 0)
            {
                Console.WriteLine("Incorrect name entered");
                return;

            }
            return;
        }

        static void PhoneFinder(List<Phone> list)
        {
            Console.WriteLine("Please enter the name of the phone you would like to search for.");
            String UserInput = Console.ReadLine();
            int PhoneCheck = 0;

            if (PhoneCheck == 0)
            {
                Console.WriteLine($"No results for Phones named {UserInput} Found");

            }
            else
            {

            }

        }
        static void PrintSpecs(Phone phone)
        {
            Console.WriteLine("\n\n--------------");
            Console.WriteLine($"Name {phone.Name}");
            Console.WriteLine($"Chip {phone.Chip}");
            Console.WriteLine($"Size {phone.Size}IN x IN");
            Console.WriteLine($"Storage {phone.Storage}GB");
            Console.WriteLine($"Memory {phone.Memory}GB");
            Console.WriteLine($"Price {phone.Price}$");
            Console.WriteLine($"Released {phone.ReleaseYear}");
            Console.WriteLine($"{phone.Stock} Units Remaining");

            PurchasePhone(phone);
            return;
        }
        static void PurchasePhone(Phone TempPhone)
        {
            Console.WriteLine("\n\n----------------------------------------------");
            Console.WriteLine($"Would you like to purchase the {TempPhone.Name}? ");
            Console.WriteLine("Enter Y or N");
            Console.WriteLine("\n\n----------------------------------------------");

            String userinput = Console.ReadLine();


            if (userinput == "Y" || userinput == "y")
            {
                TempPhone.Stock--;
                reserailise();
                Console.WriteLine($"You have purchased the {TempPhone.Name} ");
                Console.WriteLine($"Remaining Stock {TempPhone.Stock}");
                //UpdateFile(PhoneList); removed string version
            }
            else
            {
                Console.WriteLine($"Did not purchase ");
            }
            return;
        }
        static void StoreSettings()
        {
            Console.WriteLine("\n\n----------------------------");
            Console.WriteLine("Store settings                  ");
            Console.WriteLine("Please select an option         ");
            Console.WriteLine("Add a phone to the store     (1)");
            Console.WriteLine("Delete a phone to the store  (2)");
            Console.WriteLine("Exit                         (3)");
            Console.WriteLine("\n\n----------------------------");
            int userinput = int.Parse(Console.ReadLine());
            while (true)
            {
                switch (userinput)
                {
                    case 1:
                        AddPhone(PhoneList);
                        return;
                    case 2:
                        DeletePhone(PhoneList);
                        return;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Invalid option entered, please try again");
                        return;
                }

            }
        }
        static void AddPhone(List<Phone> list)
        {
            Console.WriteLine("Would you like to add an iphone or a samsung phone to the store ? ");
            Console.WriteLine("iPhone  (1)");
            Console.WriteLine("Samsung (2)");
            int userinput = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter phone Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter phone Chip");
            string chip = Console.ReadLine();
            Console.WriteLine("Enter phone Size");
            string size = Console.ReadLine();
            Console.WriteLine("Enter Maximum Phone Storage (GB)");
            int storage = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Maximum Phone Memory (GB)");
            int memory = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Maximum Price (USD)");
            int price = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Release year");
            int releaseyear = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Stock");
            int stock = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Operating system");
            string OS = Console.ReadLine();


            if (userinput == 1)
            {
                PhoneList.Add(new Iphone(name, chip, size, storage, memory, price, releaseyear, stock,OS));
            }
            else
            {
                PhoneList.Add(new Samsung(name, chip, size, storage, memory, price, releaseyear, stock,OS));
            }
            reserailise();
            return;
        }
        static void DeletePhone(List<Phone> list)
        {

            Console.WriteLine("Type in the name of the phone you wish to delete");
            string UserInput = Console.ReadLine();
            int found = 0;

            foreach (var Phone in list)
            {
                if (UserInput == Phone.Name)
                {
                    found = 1;
                    break;
                }
            }


            if (found == 1)
            {
                list.RemoveAll(Phone => Phone.Name == UserInput);
                reserailise();
            }
            else
            {
                Console.WriteLine($"No phone with the name {UserInput} found ");
            }
            return;

        }

    }

}


