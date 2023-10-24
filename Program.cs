using System.Collections.Generic;
using task16.Exeptions;
using task16.Models;

namespace task16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Quiz> quizzes = new List<Quiz>();
           

        restartSwitch:
            Console.WriteLine("**************");
            Console.WriteLine("Menu");
            Console.WriteLine("**************");
            Console.WriteLine("[1] Create new quiz");
            Console.WriteLine("[2] Solve a quiz");
            Console.WriteLine("[3] Show quizzes");
            Console.WriteLine("[0] Exit");

            string choice = Console.ReadLine();


            try
            {
                    switch (choice)
                    {
                        case "1":

                            break;
                        case "2":

                            break;
                        case "3":

                            break;
                        case "0":

                            Console.WriteLine("Quiz bitdi.");
                            return;

                        default:
                            Console.WriteLine("Seciminiz duzgun deyil. Duzgun reqem daxil edin .");

                            break;
                    }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            goto restartSwitch;
        }
        public static void CreateQuiz(List<Quiz> quizzes)
        {
            Console.WriteLine("Quizin adini daxil edin:");
            string name = Console.ReadLine().Trim();
            name = char.ToUpper(name[0]) + name.Substring(1).ToLower();
            foreach (var item in quizzes )
            {
                if (item.Name == name)
                {
                    throw new QuizAlreadyExits();
                }
            }
            if (name.Length > 3 && name.Length < 25)
            { List<Question> questions = new();
                Quiz quiz = new(name, questions);
                quizzes.Add(quiz);
            }
            else
            {
                throw new WrongInput("Duzgun deyer daxil edin");
            }
            
        }
    }
}