using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TextChat
{
    public class InputHandler
    {
        string[] badWords = { "fuck", "shit" };

        public void Output(string input, ref bool exitCondition)
        {
            switch (input.Substring(1, input.Length - 1).ToLower())
            {
                case "help":
                    Console.Write("\n");
                    Console.WriteLine("!filter : Filters the given text.");
                    Console.WriteLine("!time : Prints current time.");
                    Console.WriteLine("!date : Prints current date");
                    Console.WriteLine("!read : Outputs the contents of a file from a directory.");
                    Console.WriteLine("!fgcolor : Changes text color.");
                    Console.WriteLine("!bgcolor : Changes background color.");
                    Console.WriteLine("!cls : Clears the screen.");
                    Console.WriteLine("!quit : Exits the program.");
                    Console.WriteLine("!motivation : Provides a motivational speech.");
                    Console.Write("\n");
                    break;
                case "time": Console.WriteLine(DateTime.Now.Hour + ":" + DateTime.Now.Minute); break;
                case "date": Console.WriteLine(DateTime.Now.DayOfWeek + ", " + DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year); break;
                case "filter":
                    {
                        Console.Write("type >");
                        string newInput = Console.ReadLine();
                        for (int i = 0; i < badWords.Length; i++)
                        {
                            string pattern = @"\b" + string.Join(@"{1,}\s*", badWords[i].ToCharArray()) + @"{1,}\b";
                            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
                            newInput = regex.Replace(newInput, match => { return new string('*', match.Length); });
                        }
                        Console.WriteLine("Filtered: " + newInput);
                    }
                    break;
                case "fgcolor": Console.ForegroundColor = NewColorEntry(); break;
                case "bgcolor": Console.BackgroundColor = NewColorEntry(); break;
                case "read":
                    {
                        Console.Write("directory >");
                        string filePath = Console.ReadLine();
                        if (File.Exists(filePath))
                            if (Path.GetExtension(filePath) == ".txt")
                            {
                                string contents = System.IO.File.ReadAllText(filePath);
                                Console.WriteLine(contents);
                            }
                            else Console.WriteLine("The specified file cannot be read.");
                        else Console.WriteLine("Could not find the specified file.");
                    }
                    break;
                case "cls": Console.Clear(); break;
                case "quit": exitCondition = true; break;
                case "motivation": Console.WriteLine(MotivationalSpeech()); break;
                default: Console.WriteLine("Command not recognized."); break;
            }
        }
        public ConsoleColor NewColorEntry()
        {
            Console.Write("color name >");
            string colorName = Console.ReadLine();
            try
            {
                return (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colorName);
            }
            catch (System.ArgumentException e)
            {
                Console.WriteLine("Color not found.");
                Console.WriteLine("Possible colors include:");
                Console.WriteLine("Black       DarkBlue");
                Console.WriteLine("DarkGreen   DarkCyan");
                Console.WriteLine("DarkRed     DarkMagenta");
                Console.WriteLine("DarkYellow  Gray");
                Console.WriteLine("DarkGray    Blue");
                Console.WriteLine("Green       Cyan");
                Console.WriteLine("Red         Magenta");
                Console.WriteLine("Yellow      White");
                return Console.ForegroundColor;
            }
        }
        public string MotivationalSpeech()
        {
            Random rng = new Random();

            string getRandomWord(string[] wordBank) { return wordBank[rng.Next(0, wordBank.Length)]; }

            string finalString = "";

            string[] nouns = {
            "life",
            "happiness",
            "appreciation",
            "freedom",
            "success",
            "spirit",
            "depression",
            "wisdom",
            "motivation",
            "journey",
            "faith",
            "hopefulness",
            "goals",
            "optimism",
            "advantage",
            "benefit",
            "bliss",
            "bonus",
            "friend",
            "companionship",
            "passion",
            "celebration",
            "confidence",
            "devotion",
            "doubt",
            "wonder"};

            string[] verbs = { "live", "be", "do", "are", "want", "think", "aren't", "take", "like", "have" };

            string[] adjectives = { "strong", "kind", "loving", "understanding", "successful", "happy", "courageous", "adventurous", "compassionate", "exuberant", "reliable" };

            string[] transitions = { " and", " with", " without", ",", " or", " after", " therefore", " as a result,", " before", " finally" };

            string[] ownership = { "your", "our", "their", "my" };

            string[] pronouns = { "you", "we", "they", "I" };

            string NewVerbFragment() //"want optimism"
            {
                string result = "";
                result += getRandomWord(verbs) + " ";
                result += getRandomWord(nouns);
                return result;
            }
            string NewCharacterizerReference() //"your happiness"
            {
                string result = "";
                result += getRandomWord(ownership) + " ";
                result += getRandomWord(nouns);
                return result;
            }
            string NewNounLink() //"happiness and strength"
            {
                string result = "";
                result += getRandomWord(nouns) + " ";
                result += getRandomWord(transitions) + " ";
                result += getRandomWord(nouns);
                return result;
            }
            string NewPronounNounLink() //"happiness and strength"
            {
                string result = "";
                result += getRandomWord(pronouns) + " ";
                result += getRandomWord(verbs) + " ";
                result += getRandomWord(nouns);
                return result;
            }
            string NewPronounAdjLink() //"happiness and strength"
            {
                string result = "";
                result += getRandomWord(pronouns) + " ";
                result += getRandomWord(verbs) + " ";
                result += getRandomWord(adjectives);
                return result;
            }
            string NewSentenceStructure()
            {
                string result = "";
                int repetition = rng.Next(1, 3);
                for (int i = 0; i < repetition; i++)
                {
                    switch (rng.Next(1, 6))
                    {
                        default:
                        case 1:
                            result += getRandomWord(pronouns) + " " + NewVerbFragment();
                            break;
                        case 2:
                            result += NewNounLink();
                            break;
                        case 3:
                            result += NewPronounAdjLink();
                            break;
                        case 4:
                            result += NewPronounNounLink();
                            break;
                        case 5:
                            result += NewCharacterizerReference();
                            break;
                    }
                    if (i < repetition - 1)
                        result += getRandomWord(transitions) + " ";
                }
                result += ".";
                return result;
            }

            int sentences = rng.Next(1, 10);
            for (int i = 0; i < sentences; i++)
                finalString += NewSentenceStructure() + " ";

            return finalString;
        }
    }
}