using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task16.Exeptions;

namespace task16.Models
{
    internal class Quiz
    {
        static int count = 1;
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Question> Questions { get; } = new List<Question>();


        public Quiz(string name, List<Question> questions)
        {
            Id = count++;
            Name = name;
            Questions = questions;

        }

        public override string ToString()
        {
            return $"ID {Id}   Name {Name}";
        }
        public static Quiz  CreateQuiz(List<Quiz> quizzes)
        {
            Console.WriteLine("Quizin adini daxil edin:");
            string name = Console.ReadLine().Trim();
            name = char.ToUpper(name[0]) + name.Substring(1).ToLower();
            foreach (var item in quizzes)
            {
                if (item.Name == name)
                {
                    throw new QuizAlreadyExits();
                }
            }
            if (name.Length > 3 && name.Length < 25)
            {
                Console.WriteLine("Nece sual daxil edilecek?");
                bool isParse = byte.TryParse(Console.ReadLine(), out byte count);
                if (!isParse)
                {
                    throw new WrongInput();
                }
                List<Question> list = new List<Question>();
                for (int i = 0; i < count; i++)
                {
                    list.Add(Question.CreateQuestion());
                }

                Quiz quiz = new Quiz(name, list);
                return quiz;
            }
            else
            {
                throw new WrongInput("Duzgun deyer daxil edin");
            }

        }

        public static void SolveQuiz(Quiz quiz)
        {
            byte result = 0;
            Console.WriteLine(quiz.Name);
            
            foreach (Question question in quiz.Questions)
            {
                Console.WriteLine(question.QuestionText);
                Console.WriteLine("\n");
                for (int i = 0; i < question.Variants.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {question.Variants[i]}");

                }
                Console.WriteLine("\n Cavabiniz:");
            restart:
                bool isParse = byte.TryParse(Console.ReadLine(), out byte id);
                if (!isParse || id > 4 || id < 0)
                {
                    Console.WriteLine("Duzgun reqem daxil edin");
                    goto restart;
                }
                if (id == question.TrueVariantId)
                {
                    result++;
                }
            }
            Console.WriteLine($"Neticeniz: \n {result}/{quiz.Questions.Count}");
        }
    }
}
