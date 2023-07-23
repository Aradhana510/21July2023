using System;
using System.Text.RegularExpressions;

namespace TextProcessingWithRegex
{
    class Program
    {
        static void Main()
        {
            // Step 3: Prompt the user to enter a piece of text
            Console.WriteLine("Enter a piece of text:");
            string inputText = Console.ReadLine();

            // Step 4: Process the input text and display the results
            int wordCount = CountWords(inputText);
            string[] emails = FindEmailAddresses(inputText);
            string[] mobileNumbers = ExtractMobileNumbers(inputText);

            Console.WriteLine("\nResults:");
            Console.WriteLine($"Word Count: {wordCount}");

            if (emails.Length > 0)
            {
                Console.WriteLine("\nEmail Addresses:");
                foreach (string email in emails)
                {
                    Console.WriteLine(email);
                }
            }
            else
            {
                Console.WriteLine("\nNo email addresses found.");
            }

            if (mobileNumbers.Length > 0)
            {
                Console.WriteLine("\nMobile Numbers:");
                foreach (string number in mobileNumbers)
                {
                    Console.WriteLine(number);
                }
            }
            else
            {
                Console.WriteLine("\nNo mobile numbers found.");
            }

            // Step 5: Custom Regex Search
            Console.WriteLine("\nEnter a custom regular expression to search for patterns:");
            string customRegex = Console.ReadLine();
            string[] customMatches = PerformCustomRegexSearch(inputText, customRegex);

            if (customMatches.Length > 0)
            {
                Console.WriteLine("\nCustom Regex Search Results:");
                foreach (string match in customMatches)
                {
                    Console.WriteLine(match);
                }
            }
            else
            {
                Console.WriteLine("\nNo matches found for the custom regex.");
            }
        }

        // Step 2: Method to count words in the input text
        static int CountWords(string inputText)
        {
            string[] words = inputText.Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }

        // Step 3: Method to find email addresses in the input text
        static string[] FindEmailAddresses(string inputText)
        {
            const string emailPattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}\b";
            MatchCollection matches = Regex.Matches(inputText, emailPattern);
            string[] emails = new string[matches.Count];

            for (int i = 0; i < matches.Count; i++)
            {
                emails[i] = matches[i].Value;
            }

            return emails;
        }

        // Step 4: Method to extract mobile numbers from the input text
        static string[] ExtractMobileNumbers(string inputText)
        {
            const string mobileNumberPattern = @"\b\d{10}\b";
            MatchCollection matches = Regex.Matches(inputText, mobileNumberPattern);
            string[] mobileNumbers = new string[matches.Count];

            for (int i = 0; i < matches.Count; i++)
            {
                mobileNumbers[i] = matches[i].Value;
            }

            return mobileNumbers;
        }

        // Step 5: Method to perform custom regex search on the input text
        static string[] PerformCustomRegexSearch(string inputText, string customRegex)
        {
            MatchCollection matches = Regex.Matches(inputText, customRegex);
            string[] customMatches = new string[matches.Count];

            for (int i = 0; i < matches.Count; i++)
            {
                customMatches[i] = matches[i].Value;
            }

            return customMatches;
        }
    }
}