using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunGame();
        }

        static void RunGame()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Xander's Trivia Game");
            Console.WriteLine("");
            Console.WriteLine("What is your name?: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string playerName = Console.ReadLine();

            bool isPlaying = true;

            while (isPlaying)
            {
                int correctAnswers = 0;

                List<Question> questions = TriviaQuestions();

                for (int i = 0; i < questions.Count; i++)
                {
                    DisplayHUD(playerName, i + 1, correctAnswers, i);
                    bool isCorrect = AskQuestion(questions[i]);

                    if (isCorrect)
                    {
                        correctAnswers++;
                    }
                }

                DisplayFinalScore(playerName, correctAnswers, questions.Count);

                isPlaying = PlayAgainPrompt();
            }
        }

        static void DisplayHUD(string playerName, int questionNumber, int correct, int answered)
        {
            Console.Clear();
            double percent = answered > 0 ? (double)correct / answered * 100 : 0;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("========================================");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Player: " + playerName);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Question: " + questionNumber);

            if (percent == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            else if (percent > 50)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.WriteLine("Current Score: " + percent.ToString("0") + "%");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("========================================");
            Console.ResetColor();
            Console.WriteLine("");

        }

        static bool AskQuestion(Question q)
        {
            Console.WriteLine(q.Text);

            for (int i = 0; i < q.Answers.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {q.Answers[i]}");
            }

            Console.WriteLine();
            Console.Write("Your answer (1-4): ");

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.KeyChar >= '1' && key.KeyChar <= '4')
                {
                    int choice = key.KeyChar - '0';
                    return choice == q.CorrectAnswer;
                }

                Console.Write("Invalid key. Choose 1, 2, 3, or 4: ");
            }
        }

        static List<Question> TriviaQuestions()
        {
            return new List<Question>
            {
                new Question(
                    "Which data type is used to store true or false values in C#?",
                    new string[] { "bool", "int", "char", "float" },
                    1
                ),
                new Question(
                    "What does 'void' mean when declaring a method?",
                    new string[] { "It returns a value", "It doesnt return a value", "It voids a method", "Has no meaning" },
                    2
                ),
                new Question(
                    "Which access modifier makes a member only accessible within its own class?",
                    new string[] { "public", "private", "protected", "internal" },
                    2
                ),
                new Question(
                    "Which loop runs while a condition is true",
                    new string[] { "for", "foreach", "while", "None of the above" },
                    3
                ),
                new Question(
                    "Arrays in C# are:",
                    new string[] { "Fixed size", "Resizable", "Stored on external files", "Only hold numbers" },
                    1
                ),
                new Question(
                    "What is the process of converting a value from one data type to another, such as turning an integer into a string, called?",
                    new string[] { "Looping", "Parsing", "Indexing", "Clamp", },
                    2
                ),
                new Question(
                    "What does the Math.Clamp method do",
                    new string[] { "It rounds a number to the nearest whole number", "It converts a data type to another", "it repeated a value a specified amount of times", "It restricts a value within a specified range", },
                    4
                ),
                new Question(
                    "What is the output of 10 % 3?",
                    new string[] { "1", "0", "3", "10" },
                    1
                ),
                new Question(
                    "What is the symbol to divide in C#",
                    new string[] { "&", "%", "//", "/" },
                    4
                ),
                new Question(
                    "The crabeater seal native to the coast of antartica, eats what?",
                    new string[] { "Crabs", "Penguins", "Krill", "Turtles" },
                    3
                )
            };
        }

        static void DisplayFinalScore(string name, int correct, int total)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("========================================");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(name);

            Console.ResetColor();
            Console.Write(", you scored ");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{correct}/{total}");

            Console.ResetColor();
            Console.WriteLine("!");

            double percent = (double)correct / total * 100;

            if (percent == 100)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Perfect score! Excellent mastery!");
            }
                
            else if (percent >= 80)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Great job! Not too shabby!");
            }
            else if (percent >= 50)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Keep practicing.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Keep studying");
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("========================================");
            Console.WriteLine("");
        }

        static bool PlayAgainPrompt()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Write("Play again?: ");

            Console.ResetColor();
            Console.Write("(");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Y");

            Console.ResetColor();
            Console.Write("/");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("N");

            Console.ResetColor();
            Console.Write("): ");


            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Y)
                {
                    Console.ResetColor();
                    return true;
                }

                if (key.Key == ConsoleKey.N)
                {
                    Console.ResetColor();
                    return false;
                }

                Console.Write("Invalid input. Press Y or N: ");
            }
        }

        class Question
        {
            public string Text { get; }
            public string[] Answers { get; }
            public int CorrectAnswer { get; }

            public Question(string text, string[] answers, int correctAnswer)
            {
                Text = text;
                Answers = answers;
                CorrectAnswer = correctAnswer;
            }
        }


    }
}
