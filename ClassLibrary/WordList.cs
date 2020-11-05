using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ClassLibrary
{
    public class WordList
    {
        private static readonly string FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Lab4");
        private static readonly char[] WordSeparator = new Char[1] { ';' };

        private List<Word> ListOfWords { get; set; }
        public string Name { get; }
        public string[] Languages { get; }

        static WordList()
        {
            if (!Directory.Exists(FilePath))
            {
                try
                {
                    Directory.CreateDirectory(FilePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating {FilePath} folder: {ex.Message}");
                }
            }
        }

        public WordList(string name, params string[] languages)
        {
            if (name == "" || languages.Length < 2)
            {
                throw new ArgumentException("Name must have a value and there must be at least two languages.");
            }
            if (Array.Exists(languages, lang => lang.Contains(WordSeparator[0].ToString())))
            {
                throw new InvalidDataException($"'{WordSeparator[0]}' is not an allowed character.");
            }
            Name = name;
            Languages = languages;
            ListOfWords = new List<Word>();
        }

        public static string[] GetLists()
        {
            try
            {
                string[] files = Directory.GetFiles(FilePath, "*.dat")
                            .Select(fileName => Path.GetFileNameWithoutExtension(fileName))
                            .ToArray();
                return files;
            }
            catch
            {
                throw;
            }
        }

        public static WordList LoadList(string name)
        {
            WordList wordList = null;
            try
            {
                using (StreamReader sr = new StreamReader(Path.Combine(FilePath, name + ".dat")))
                {
                    string[] languages = null;
                    string line;

                    if ((line = sr.ReadLine()) == null)
                    {
                        throw new FileLoadException($"The file '{name}' does not contain any languages (or words) as expected.");
                    }
                    else if (line.Contains(WordSeparator[0].ToString()))
                    {
                        languages = line.Split(WordSeparator, StringSplitOptions.RemoveEmptyEntries);
                        wordList = new WordList(name, languages);
                    }
                    else
                    {
                        throw new InvalidDataException($"The file '{name}' is not in the expected format.");
                    }

                    while ((line = sr.ReadLine()) != null)
                    {
                        var wordArray = new string[languages.Length];
                        wordArray = line.Split(WordSeparator, StringSplitOptions.RemoveEmptyEntries);
                        if (wordArray.Length == languages.Length)
                        {
                            Word word = new Word(wordArray);
                            wordList.ListOfWords.Add(word);
                        }
                        else
                        {
                            throw new InvalidDataException($"A word in the file '{name}' doesn't have the correct number of translations.");
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

            return wordList;
        }

        public void Save()
        {
            try
            {
                using (StreamWriter sr = new StreamWriter(Path.Combine(FilePath, Name + ".dat")))
                {
                    for (int i = 0; i < Languages.Length; i++)
                    {
                        sr.Write(Languages[i].ToLower() + ";");
                    }
                    sr.WriteLine();

                    for (int i = 0; i < ListOfWords.Count; i++)
                    {
                        for (int j = 0; j < Languages.Length; j++)
                        {
                            sr.Write(ListOfWords[i].Translations[j].ToLower() + ";");
                        }
                        sr.WriteLine();
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public void Add(params string[] translations)
        {
            bool isComplete = true;
            for (int i = 0; i < Languages.Length && isComplete; i++)
            {
                if (translations[i] == "")
                {
                    isComplete = false;
                }
            }
            if (isComplete)
            {
                if (Array.Exists(translations, t => t.Contains(WordSeparator[0].ToString())))
                {
                    throw new InvalidDataException($"'{WordSeparator[0]}' is not an allowed character.");
                }
                else
                {
                    ListOfWords.Add(new Word(translations));
                }
            }
            else
            {
                throw new ArgumentException($"The word '{translations[0]}' was not added since it wasn't translated to all languages.");
            }
        }

        public bool Remove(int translation, string word)
        {
            return ListOfWords.Remove(ListOfWords.Find(x => x.Translations[translation].Equals(word)));
        }

        public int Count()
        {
            return ListOfWords.Count;
        }

        public void List(int sortByTranslation, Action<string[]> showTranslations)
        {
            List<Word> SortedList = ListOfWords.OrderBy(w => w.Translations[sortByTranslation]).ToList();

            foreach (var word in SortedList)
            {
                showTranslations(word.Translations);
            }
        }

        public Word GetWordToPractice()
        {
            if (ListOfWords.Count > 0)
            {
                Random rnd = new Random();
                int index = rnd.Next(ListOfWords.Count);
                int fromLanguage = rnd.Next(Languages.Length);
                int toLanguage;
                do
                {
                    toLanguage = rnd.Next(Languages.Length);
                } while (toLanguage == fromLanguage);

                return (new Word(fromLanguage, toLanguage, ListOfWords[index].Translations));
            }
            else
            {
                throw new IndexOutOfRangeException("The list contains no words to practice on.");
            }
        }
    }
}
