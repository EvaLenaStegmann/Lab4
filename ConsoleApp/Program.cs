using ClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            if (args.Length > 0)
            {
                command = args[0].ToLower();
            }

            switch (command)
            {
                case "":
                    ShowHelp();
                    break;

                case "-lists":
                    GetLists();
                    break;

                case "-words":
                    ListWords(args);
                    break;

                case "-new":
                    if (CreateNewList(args))
                    {
                        AddWords(args);
                    }
                    break;

                case "-add":
                    AddWords(args);
                    break;

                case "-remove":
                    RemoveWords(args);
                    break;

                case "-count":
                    CountWords(args);
                    break;

                case "-practice":
                    Practice(args);
                    break;

                default:
                    ShowHelp("Unknown command, please use one of the following options:", "");
                    break;
            }
        }

        static void ShowHelp()
        {
            ShowHelp("Use any of the following parameters:", "");
        }

        static void ShowHelp(string helpText, string helpTextKey)
        {
            Dictionary<string, string> commandDictionary = new Dictionary<string, string>()
            {
                { "-lists","-lists" },
                { "-new", "-new <list name> <language 1> <language 2> .. <language n> " },
                { "-add", "-add <list name>"},
                { "-remove", "-remove <list name> <language> <word 1> <word 2> .. <word n> "},
                { "-words", "-words <listname> <sortByLanguage>"},
                { "-count", "-count <listname>"},
                { "-practice", "-practice <listname> "},
            };

            Console.WriteLine("");
            Console.WriteLine(helpText);
            if (helpTextKey == "")
            {
                foreach (string command in commandDictionary.Values)
                {
                    Console.WriteLine(command);
                }
            }
            else
            {
                Console.WriteLine(commandDictionary[helpTextKey]);
            }
            Console.WriteLine("");
        }

        static void ShowMessage(string messageText)
        {
            Console.WriteLine("");
            Console.WriteLine(messageText);
            Console.WriteLine("");
        }

        static void GetLists()
        {
            try
            {
                var files = WordList.GetLists();

                if (files.Length > 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("You have the following lists:");
                    foreach (string file in files)
                    {
                        Console.WriteLine(file);
                    }
                    Console.WriteLine("");
                }
                else
                {
                    ShowHelp("You have no lists yet. Use the -new command to create one, as:", "-new");
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Could not get lists: {ex.Message}.");
            }
        }

        static void ListWords(string[] args)
        {
            if (args.Length < 2)
            {
                ShowHelp("You must specify a list name and optionally a language to sort on, as:", "-words");
                return;
            }

            WordList wordList = LoadWordList(args[1]);
            if (wordList == null)
            {
                return;
            }

            try
            {
                int sortingLanguage = 0;
                if (args.Length > 2)
                {
                    sortingLanguage = Array.IndexOf(wordList.Languages, args[2].ToLower());
                    if (sortingLanguage < 0)
                    {
                        ShowMessage($"The language '{args[2]}' wasn't found in '{args[1]}'. The list is sorted on '{wordList.Languages[0]}' instead.");
                        sortingLanguage = 0;
                    }
                }

                Console.WriteLine("");
                ShowRow(wordList.Languages, true);
                wordList.List(sortingLanguage, translations => ShowRow(translations, false));
                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                ShowMessage($"Could not read '{args[1]}': {ex.Message}");
            }
        }

        static WordList LoadWordList(string listName)
        {
            WordList wordList = null;
            try
            {
                wordList = WordList.LoadList(listName);
            }
            catch (FileNotFoundException)
            {
                ShowHelp($"The list '{listName}' wasn't found. Use the -lists command to see which lists you already have, as:", "-lists");
            }
            catch (Exception ex)
            {
                if (ex is FileLoadException || ex is InvalidDataException)
                {
                    ShowMessage(ex.Message);
                }
                else
                {
                    ShowMessage($"Could not read '{listName}': {ex.Message}");
                }
            }

            return wordList;
        }

        static void ShowRow(string[] texts, bool isHeader)
        {
            foreach (var text in texts)
            {
                if (isHeader)
                {
                    Console.Write(text.PadRight(20).ToUpper());
                }
                else
                {
                    Console.Write(text.PadRight(20).ToLower());
                }
            }
            Console.WriteLine("");
        }

        static bool CreateNewList(string[] args)
        {
            if (args.Length < 4)
            {
                ShowHelp("You must specify the name of the new list and at least two languages to create a new list, as:", "-new");
                return false;
            }

            var files = WordList.GetLists();
            foreach(string file in files)
            {
                if (file.ToUpper() == args[1].ToUpper())
                {
                    ShowMessage($"You already have a list called '{file}'. Try another name.");
                    return false;
                }
            }

            var languages = new string[args.Length - 2];
            for (int i = 2; i < args.Length; i++)
            {
                languages[i - 2] = args[i].ToLower();
            }
            try
            {
                var wordList = new WordList(args[1], languages);
                wordList.Save();
            }
            catch (Exception ex)
            {
                if (ex is InvalidDataException || ex is ArgumentException)
                {
                    ShowMessage(ex.Message);
                }
                else
                {
                    ShowMessage($"Couldn't create the list '{args[1]}': {ex.Message}");
                }
                return false;
            }
            return true;
        }

        static void AddWords(string[] args)
        {
            if (args.Length < 2)
            {
                ShowHelp("You must specify a list name to add your new translations to, as:", "-add");
                return;
            }
            WordList wordList = LoadWordList(args[1]);
            if (wordList == null)
            {
                return;
            }

            Console.WriteLine("");
            Console.WriteLine("Just press Enter to stop adding words.");

            try
            {
                int i = 0;
                int noOfAddedWords = 0;

                string translation = "";
                do
                {
                    var translations = new string[wordList.Languages.Length];
                    Console.WriteLine("");
                    Console.WriteLine($"Enter a word in '{wordList.Languages[i]}':");
                    translation = Console.ReadLine();
                    translations[i] = translation.ToLower();
                    i++;

                    while (i < wordList.Languages.Length && translation != "")
                    {
                        Console.WriteLine("");
                        Console.WriteLine($"Enter '{translations[0]}' in '{wordList.Languages[i]}':");
                        translation = Console.ReadLine();
                        translations[i] = translation.ToLower();
                        i++;

                    }

                    if (translations[0] != "")
                    {
                        try
                        {
                            wordList.Add(translations);
                            noOfAddedWords++;
                        }
                        catch (Exception ex)
                        {
                            ShowMessage(ex.Message);
                        }
                    }

                    i = 0;

                } while (translation != "");

                wordList.Save();
                if (noOfAddedWords == 1)
                {
                    Console.WriteLine("1 word was added.");
                }
                else
                {
                    Console.WriteLine($"{noOfAddedWords} words were added.");
                }
                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                ShowMessage($"Could not save your added words in '{args[1]}': {ex.Message}");
            }
        }

        static void RemoveWords(string[] args)
        {
            if (args.Length < 4)
            {
                ShowHelp("You must specify which word(s) to remove, as:", "-remove");
                return;
            }
            WordList wordList = LoadWordList(args[1]);
            if (wordList == null)
            {
                return;
            }

            try
            {
                int translation = Array.IndexOf(wordList.Languages, args[2].ToLower());

                if (translation < 0)
                {
                    ShowHelp($"The language '{args[2]}' wasn't found in '{args[1]}'. You can use the -words command to see the content of the list as:", "-words");
                }
                else
                {
                    int i = 3;
                    List<string> successfulRemoves = new List<string>();
                    List<string> failedRemoves = new List<string>();

                    do
                    {
                        if (wordList.Remove(translation, args[i].ToLower()))
                        {
                            successfulRemoves.Add(args[i]);
                        }
                        else
                        {
                            failedRemoves.Add(args[i]);
                        }

                        i++;
                    } while (i < args.Length);

                    if (successfulRemoves.Count > 0)
                    {
                        wordList.Save();
                        Console.WriteLine("");
                        Console.WriteLine("The following words were successfully removed from the list:");
                        foreach (string word in successfulRemoves)
                        {
                            Console.WriteLine(word);
                        }
                        Console.WriteLine("");
                    }
                    if (failedRemoves.Count > 0)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("NOTE! The following words could not be removed from the list:");
                        foreach (string word in failedRemoves)
                        {
                            Console.WriteLine(word);
                        }
                        Console.WriteLine("");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"An error occurred: {ex.Message}");
            }
        }

        static void CountWords(string[] args)
        {
            if (args.Length < 2)
            {
                ShowHelp("You must specify a list name, as:", "-count");
                return;
            }
            WordList wordList = LoadWordList(args[1]);
            if (wordList == null)
            {
                return;
            }

            ShowMessage($"The list '{args[1]}' contains {wordList.Count()} words.");
        }

        static void Practice(string[] args)
        {
            if (args.Length < 2)
            {
                ShowHelp("You must specify a list name to practice on, as:", "-practice");
                return;
            }
            WordList wordList = LoadWordList(args[1]);
            if (wordList == null)
            {
                return;
            }

            try
            {
                double noOfTries = 0;
                double noOfCorrectTranslations = 0;

                string translation = "";
                do
                {
                    Word word = wordList.GetWordToPractice();
                    Console.WriteLine("");
                    Console.WriteLine($"Write '{word.Translations[word.FromLanguage]}' in '{wordList.Languages[word.ToLanguage]}':");
                    translation = Console.ReadLine();
                    if (translation != "")
                    {
                        if (translation.ToLower() == word.Translations[word.ToLanguage])
                        {
                            Console.WriteLine("Correct!");
                            noOfCorrectTranslations++;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, that was not correct!");
                        }
                        noOfTries++;
                        Console.WriteLine("");
                    }

                } while (translation != "");

                if (noOfTries > 0)
                {
                    Console.WriteLine($"You practiced on {noOfTries} words and had {noOfCorrectTranslations} correct translations " +
                                      $"({(noOfCorrectTranslations / noOfTries) * 100:0}%).");
                    Console.WriteLine("");
                }
            }
            catch (Exception ex)
            {
                if (ex is IndexOutOfRangeException)
                {
                    ShowMessage(ex.Message);
                }
                else
                {
                    ShowMessage($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}