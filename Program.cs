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
            Console.WriteLine("Xander's Trivia Game");
            Console.WriteLine("");
            Console.WriteLine("What is your name?: ");
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
                        correctAnswers++;
                }

                //
            }
        }

        static void DisplayHUD(string playerName, int questionNumber, int correct, int answered)
        {
            Console.Clear();
            double percent = answered > 0 ? (double)correct / answered * 100 : 0;

            Console.WriteLine("========================================");
            Console.WriteLine("Player: " + playerName);
            Console.WriteLine("Question: " + questionNumber);
            Console.WriteLine("Current Score: " + percent.ToString("0") + "%");
            Console.WriteLine("========================================");
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
                )
            };
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
