using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzleFamilyFeud
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Init();


            Console.ReadLine();
        }

        private static void Init()
        {
            bool valid;

            do
            {
                Console.WriteLine("Would You Like To:\n" +
                    "\n(1) Make Your Own Question?" +
                    "\n(2) View All Questions" +
                    "\n(3) Delete A Question");
                valid = byte.TryParse(Console.ReadLine(), out byte select);

                if (!valid)
                    Console.Clear();

                switch (select)
                {
                    case 1:
                        AddQuestions();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                }

            } while (!valid);

        }
        private static void ResetConsole() => Console.ForegroundColor = ConsoleColor.White;

        private static Tuple<string, List<string>> AddQuestions()
        {
            const char AcceptableSuffix = '?';
            string question;
            bool valid = false;
            do
            {

                do
                {
                    Console.WriteLine("Please Enter The Question");
                    question = Console.ReadLine();
                    if (!question.EndsWith(AcceptableSuffix.ToString()))
                    {
                        Console.WriteLine($"A Question Must End With A \"{AcceptableSuffix}\"");
                        valid = false;
                    }
                    else valid = true;
                } while (!valid);

                Console.WriteLine("How Many Answers Are There?");
                valid = byte.TryParse(Console.ReadLine(), out byte answersCount);

                List<string> answers = new List<string>(answersCount);

                for (byte i = 1; i <= answers.Capacity; ++i)
                {
                    Console.WriteLine($"Please Enter Answer {i}");
                    answers.Add(Console.ReadLine());
                }

                if (!valid)
                {
                    Console.WriteLine("Invalid Choice Please Choose Again", Console.ForegroundColor = ConsoleColor.Red);
                    ResetConsole();
                    continue;
                }
                else
                {
                    Console.WriteLine("Entry Successfully Added", Console.ForegroundColor = ConsoleColor.Green);
                    ResetConsole();
                    return new Tuple<string, List<string>>(question, answers);
                }
            } while (!valid);

            return new Tuple<string, List<string>>(null, null);
        }
    }
}
