using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;
using System.Collections;
using System.Runtime.Intrinsics.X86;

namespace cSharp_Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person(1101, "Omasa", "Male");
            Person person2 = new Person(1239, "Salma", "Female");
            Person person3 = new Person(1834, "Ahmed", "Male");
            Dictionary<long, Person> personMap = new Dictionary<long, Person>();
            //personMap.Add(person1.Id, person1);  //\Add method 1
            //personMap.Add(person2.Id, person2);
            //personMap.Add(person3.Id, person3);
            personMap[person1.Id] = person1; // Add method 2
            personMap[person2.Id] = person2;
            personMap[person3.Id] = person3;
            person1.Gender = "Female"; // Change the gender
            personMap[person1.Id] = person2; // Change something
            personMap.TryAdd(person1.Id, person1); // 
            Person? result = null;

            if (personMap.TryGetValue(person2.Id, out result))
            {
                Console.WriteLine(result);
            }

            // Task 1: Word Frequency Counter
            // Create a program that prompts the user to enter a sentence.
            // The program should count the frequency of each word in the sentence and display the results as a dictionary,
            // where the keys are the unique words and the values are the corresponding frequencies.
            Console.WriteLine("\r\nTask 1: Word Frequency Counter\r\n~~~~~~~~~~~~~~~");
            Console.WriteLine("Enter a sentence: ");
            string sen = Console.ReadLine();

            string[] words = sen.Split(" "); // To remove the space from count.

            Dictionary<string, int> wordFrequency = new Dictionary<string, int>();
            foreach (string word in words)
            {
                string lowerWords = word.ToLower(); // To convert words to lower case
                // To check if the word already exists
                if (wordFrequency.ContainsKey(lowerWords))
                {
                    wordFrequency[lowerWords]++;
                }
                else
                {
                    wordFrequency.Add(lowerWords, 1);
                }
            }
            Console.WriteLine("The frequency of each word in the sentence is:");
            foreach (KeyValuePair<string, int> item in wordFrequency)
            {
                Console.WriteLine("{0} : {1}", item.Key, item.Value);
            }

            // Task 2: Unique Elements
            // Write a function that takes an array of integers as input and returns a HashSet containing only
            // the unique elements from the array. Test the function with different input arrays and print the
            // resulting HashSet.
            Console.WriteLine("\r\nTask 2: Unique Elements\r\n~~~~~~~~~~~~~~~");

            static HashSet<int> GetUniqueElements(int[] array)
            {
                HashSet<int> uniqueElements = new HashSet<int>();

                foreach (int element in array)
                {
                    // Add the element to the HashSet
                    uniqueElements.Add(element);
                }

                // return the HashSet
                return uniqueElements;
            }

            int[] array1 = new int[] { 1, 2, 3, 4, 5 };
            int[] array2 = new int[] { 1, 1, 2, 2, 4, 4 };
            int[] array3 = new int[] { 6, 7, 6, 6, 7 };

            Console.WriteLine("The unique elements in array1 are:");
            DisplayHashSet(GetUniqueElements(array1));
            Console.WriteLine("The unique elements in array2 are:");
            DisplayHashSet(GetUniqueElements(array2));
            Console.WriteLine("The unique elements in array3 are:");
            DisplayHashSet(GetUniqueElements(array3));

            static void DisplayHashSet(HashSet<int> set)
            {
                foreach (int element in set)
                {
                    Console.WriteLine(element);
                }
            }
            // Task 3: Phone Book
            // Create a phone book program that allows users to add, search, and delete contacts.
            // Use a Dictionary to store the contacts, where the keys are the names and the values
            // are the phone numbers.Implement functions to add a contact, search for a contact by name,
            // and delete a contact by name.
            Console.WriteLine("\r\nTask 3: Phone Book\r\n~~~~~~~~~~~~~~~\n");
            Console.WriteLine("    Welcome To    ");
            Console.WriteLine(" +-+-+-+-+-+-+-+-+-+\r\n |W|h|a|t|I|s|F|u|n|\r\n +-+-+-+-+-+-+-+-+-+");
            Console.WriteLine("    Phone Book     \n");
            // Display menu
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. Add a contact");
            Console.WriteLine("2. Search for a contact by name");
            Console.WriteLine("3. Delete a contact by name");
            Console.WriteLine("4. Exit");

            int choice = int.Parse(Console.ReadLine());
            Contacts contacts = new Contacts();
            // Loop until the user chooses to exit '4'
            while (choice != 4)
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter a name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter a number:");
                        string phoneNum = Console.ReadLine();
                        contacts.Add(name, phoneNum);
                        break;

                    case 2:
                        Console.WriteLine("Enter a name:");
                        string searchName = Console.ReadLine();
                        contacts.Search(searchName);
                        break;

                    case 3:
                        Console.WriteLine("Enter a name:");
                        string deleteName = Console.ReadLine();
                        contacts.Remove(deleteName);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }

                Console.WriteLine("Please choose an option:");
                Console.WriteLine("1. Add a contact");
                Console.WriteLine("2. Search for a contact by name");
                Console.WriteLine("3. Delete a contact by name");
                Console.WriteLine("4. Exit");

                choice = int.Parse(Console.ReadLine());
            }
            //Exit message
            Console.WriteLine("Thank you for using WhatIsFun Phone Book.");
        }
    }
}