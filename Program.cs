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
                        Console.Clear();
                        AddQuiz(quizzes);
                        break;
                        case "2":
                        Console.Clear();
                        Quiz.SolveQuiz(SelectQuiz(quizzes));
                        break;
                        case "3":
                        Console.Clear();
                        
                        ShowQuizzes(quizzes);
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
        public static void AddQuiz(List<Quiz> quizzes)
        {
            quizzes.Add(Quiz.CreateQuiz(quizzes));

        }



        public static void ShowQuizzes(List<Quiz> quizzes)          //shamamadan komek aldim , asagidaki kod islemirdi
        {
            if (quizzes != null && quizzes.Count > 0)
            {
                foreach (Quiz quiz in quizzes)
                {
                    Console.WriteLine($"{quiz.Id} --- {quiz.Name}");
                }
            }
            else
            {
                Console.WriteLine("Hec bir quiziniz yoxdur ");
            }
        }  
        //public static void ShowQuizzes(List<Quiz> quizzes)
        //{
        //    if (quizzes == null)
        //    {
        //        Console.WriteLine("Hec bir quiziniz yoxdur");
        //    }
        //    else
        //    {
        //        foreach (Quiz quiz in quizzes)
        //        {
        //            Console.WriteLine(quiz);
        //        }
        //    }
        //}
        public static Quiz SelectQuiz(List<Quiz> quizes)
        {
            Console.WriteLine("Quizin ID sini daxil edin");
            ShowQuizzes(quizes);
            bool isParse = int.TryParse(Console.ReadLine(), out int id);
            if (!isParse)
            {
                throw new WrongInput();
            }
            var quiz = quizes.FirstOrDefault(x => x.Id == id);
            return quiz;


        }
    }
}