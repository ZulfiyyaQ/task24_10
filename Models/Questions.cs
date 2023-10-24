using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task16.Exeptions;

namespace task16.Models
{
    internal class Question
    {
        static int count = 1;
        public int Id { get; }
        public string QuestionText { get; set; } = null!;
        public int TrueVariantId { get; set; }

        public List<string> Variants { get; } = new List<string>();

        public Question(string text, List<string> variants, int trueVariantId)
        {
            Id = count++;
            QuestionText = text;
            Variants = variants;
            TrueVariantId = trueVariantId;
        }
        public static Question CreateQuestion()
        {
        restart:
            Console.WriteLine("Suali daxil edin:");
            string text = Console.ReadLine().Trim();
            text = char.ToUpper(text[0]) + text.Substring(1).ToLower();
            if (text.Length < 3)
            {
                Console.WriteLine("Sualin uzunlugu 3 den qisa olmamalidir");
                goto restart;
            }
            List<string> variants = new List<string>();
            for (int i = 1; i <= 4; i++)
            {
                Console.WriteLine("Variant daxil edin " + i);
                string variant = Console.ReadLine().Trim();
                variant = char.ToUpper(variant[0]) + variant.Substring(1).ToLower(); ;
                if (text.Length == 0)
                {
                    throw new WrongInput ("Variantin uzunlugu 1 den qisa olmamalidir");
                }
                variants.Add(variant);

            }
            Console.WriteLine();
            Console.WriteLine("Duzgun varianti qeyd edin");
            for (int i = 0; i < 4; i++)
            {

                Console.WriteLine($"{i + 1}.{variants[i]}");
            }
            bool isParseVariant = byte.TryParse(Console.ReadLine(), out byte trueVariantId);
            if (!isParseVariant || trueVariantId > 4 || trueVariantId < 1)
            {
                throw new WrongInput("Duzgun eded daxil edin");
            }
            Question question = new Question(text, variants, trueVariantId);
            return question;
        }
    }
}
