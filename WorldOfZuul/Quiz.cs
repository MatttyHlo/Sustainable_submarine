using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfZuul
{
    public class Quiz
    {
        public string Question;
        public string[] Answers = new string[4];
        public int CorrectAnswerIndex; //Indexing from 1
        public string WrongAnswerMessage;

        public Quiz(string question, string[] answers, int correctAnswerIndex, string wrongAnswerMessage)
        {
            Question = question;
            Answers = answers;
            CorrectAnswerIndex = correctAnswerIndex;
            WrongAnswerMessage = wrongAnswerMessage;
        }
        public void AskQuestion()
        {
            ///Main Quiz logic ///
            
            Console.WriteLine(Question);
            for (int i = 0; i < Answers.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Answers[i]}");
            }

            Console.Write("Please enter the number of your answer: ");
            int playerAnswer = GetInput(4);

            if (playerAnswer == CorrectAnswerIndex)
            {
                Console.WriteLine("Correct!");
                Console.Clear();

            }
            else
            {
                Console.WriteLine(WrongAnswerMessage);
                AskQuestion(); //Recursion for retrying the question
            }
        }

        public static int GetInput(int range)
        {
            ///Input Handling///
            int input;
            try
            {
                input = int.Parse(Console.ReadKey().KeyChar.ToString());  //recieving input
                if (input < 1 || input > range)
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nInvalid input. Please enter a number between 1 and {range}");
                return GetInput(range);
            }

            Console.WriteLine();
            return input;
        }
    }
}
