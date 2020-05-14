using System;
using System.Collections.Specialized;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace ConsoleApp18
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите строку с датой в формате дд.мм.гггг.: ");
                string text = Convert.ToString(Console.ReadLine());
                string pattern = "[0-3][0-9].[0-1][0-9].[1,2][9,0][0-9][0-9]";

                MatchCollection data;
                Regex reg = new Regex(pattern);
                data = reg.Matches(text);
                DateTime s;

                if (!String.IsNullOrWhiteSpace(text))
                {
                    for (int i = 0; i < data.Count; i++)
                    {
                        if (DateTime.TryParse(data[i].Value, out s))
                        {
                            string next_date = DateTime.Parse(data[i].Value).AddDays(+1).ToShortDateString();
                            text = text.Replace(data[i].Value, next_date);

                        }
                        else
                            text = text.Replace(data[i].Value, "(Дата некорректна!)");
                    }

                    Console.WriteLine("Ваша строка с датой следующего дня: " + text);
                }
                else { throw new Exception(); }
            }
            catch { Console.WriteLine("Строка пуста!"); }
        }
    }
}
