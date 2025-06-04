using static System.Formats.Asn1.AsnWriter;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System;

namespace SpellCheckerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = createDictionary();
            //1. Take a user input of a word an check if it has been spelled correctly

            //2. Take a string of words as a user input and check they have all been spelled correctly

            //3.Create a spelling score based on the percentage of words spelled correctly

            //4.Create a new list of words that have been spelled incorrectly and save it in a new file

            //Challenge - Hard task

            //Try to work out which words the user is trying to spell by looking for similarities in
            //the spelling and ask the user did they mean that.

            //Add these suggested words to a spelling list that the user can save as a file to work on
            //their own spelling

            //1
            //Console.WriteLine("Enter a word");
            //string word = Console.ReadLine().ToUpper();
            //bool valid = false;
            //for (int i = 0; i < words.Length; i++)
            //{
            //    if (words[i] == word)
            //    {
            //        valid = true;
            //    }
            //}
            //if (valid == true)
            //{
            //    Console.WriteLine("Spelled correctly");
            //}
            //else
            //{
            //    Console.WriteLine("Spelled incorrectly");
            //}

            //2, 3 and 4
            double validCount = 0;
            Console.WriteLine("Enter some words");
            string[] input = Console.ReadLine().Split(' ');
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < words.Length; j++)
                {
                    if (input[i].ToUpper() == words[j])
                    {
                        validCount++;
                    }
                }
            }

            double percentage = (validCount / input.Length) * 100;
            Console.WriteLine(validCount);
            Console.WriteLine(input.Length);
            Console.WriteLine(percentage);

            if (validCount == input.Length)
            {
                Console.WriteLine("All spelled correctly");
                Console.WriteLine($"Your percentage is {percentage}%");
            }
            else
            {
                Console.WriteLine($"{input.Length - validCount} spelled incorrectly");
                Console.WriteLine($"Your percentage is {percentage}%");
            }

            int x = 0;
            int temp = 1;
            while (x != input.Length)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (temp == x)
                    {
                        StreamWriter fileToWrite = new StreamWriter("C:\\Users\\rubya\\Source\\Repos\\spell-checker-task-21rabson\\SpellCheckerTask\\WrongWords.txt", true);
                        fileToWrite.WriteLine(input[i+1]);
                        fileToWrite.Close();
                    }
                    temp = x;

                    for (int j = 0; j < words.Length; j++)
                    {
                        if (input[i].ToUpper() == words[j])
                        {
                            x++;
                        }
                    }
                }
            }


            //StreamWriter fileToWrite = new StreamWriter("WrongWords.txt", true);
            //fileToWrite.WriteLine("Some text added to a file");
            //string output = "This text written needs to be written to file";
            //fileToWrite.WriteLine(output);
            //fileToWrite.Close(); // saves the file




        }
        static string[] createDictionary()
        {
            using StreamReader words = new("WordsFile.txt");
            int count = 0;
            string[] dictionaryData = new string[178636];
            while (!words.EndOfStream)
            {

                dictionaryData[count] = words.ReadLine();
                count++;
            }
            words.Close();
            return dictionaryData;
        }

        

    }
}
